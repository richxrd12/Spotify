using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duracion { get; set; }
        public int IdAlbum { get; set; }
        public string Ruta { get; set; }

        //Hay que añadir la manera de poner la canción aquí abajo (?) para recibir el BLOB .mp3 y poder reproducirlo
        
    }
}
