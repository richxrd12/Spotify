using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class SpotiDB
    {
        private static string dbPath;

        private static string cadenaConexion;

        public SpotiDB()
        {
            SetPath();
            cadenaConexion = $"Data Source={dbPath}; Foreign Keys=true;";
        }

        private void SetPath()
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                dbPath = Path.Combine(FileSystem.AppDataDirectory, "mi_sqlite.db");
            }
            else if(DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                dbPath = "C:\\Users\\richa\\Desktop\\Spotify\\PrimerosPasosSpotifyAlike\\miDB.db";
                //dbPath = "C:\\Users\\Cynth\\Documents\\mi_sqlite.db";
                //dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mi_sqlite.db");
            }
            else
            {
                dbPath = "la plataforma :D";
            }
            System.Diagnostics.Debug.WriteLine($"Database path: {dbPath}"); // SOLO EN DEPURACIÓN
        }

        public async Task<int> InsertUser(User user)
        {
            int row = 0;
            using (var connection = new SqliteConnection(cadenaConexion))
            {
                await connection.OpenAsync();
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"INSERT INTO usuarios(nombre, email, pass) VALUES (@nombre, @email, @pass)";
                insertCommand.Parameters.AddWithValue("@nombre", user.Name);
                insertCommand.Parameters.AddWithValue("@email", user.Email);
                insertCommand.Parameters.AddWithValue("@pass", user.Password);

                row = await insertCommand.ExecuteNonQueryAsync();
            }
            return row;
        }

        //Método para cambiar información (supongo que estará un textfield del que podamos recoger la info para poder mandarselo al VM)
        //Método para borrar usuario (por si se quiere dar de baja) **OPCIONAL**

        public async Task<int> InsertPlaylist(Playlist playlist)
        {
            int row = 0;
            using (var connection = new SqliteConnection(cadenaConexion))
            {
                await connection.OpenAsync();
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"INSERT INTO playlist(titulo, descripcion) VALUES (@titulo, @descripcion)";
                insertCommand.Parameters.AddWithValue("@titulo", playlist.Title);
                insertCommand.Parameters.AddWithValue("@descripcion", playlist.Description);

                row = await insertCommand.ExecuteNonQueryAsync();
            }
            return row;
        }

        public async Task<int> InsertSongOnPlaylist(Playlist playlist, Cancion cancion)
        {
            int row = 0;
            using (var connection = new SqliteConnection(cadenaConexion)) 
            {
                await connection.OpenAsync();
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"INSERT INTO listaCanciones(idPlaylist, idCancion) VALUES (@idPlaylist, @idCancion)";
                insertCommand.Parameters.AddWithValue("@idPlaylist", playlist.Id);
                insertCommand.Parameters.AddWithValue("@idCancion", cancion.Id);

                row = await insertCommand.ExecuteNonQueryAsync();
            }
            return row;
        }
    }
}
