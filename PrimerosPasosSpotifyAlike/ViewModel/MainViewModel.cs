using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrimerosPasosSpotifyAlike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        //Vamos a implementar aquí el login, ya que es lo principal, después de ahí nos vamos moviendo
        private readonly SpotiDB database;

        public MainViewModel(SpotiDB database)
        {
            this.database = database;
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string loginResponse;

        [RelayCommand]
        public async Task<User> LoginAsync()
        {
            User user;
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                user = null;
                LoginResponse = "Por favor, ingrese de nuevo el email y contraseña.";
                return user;
            }

            user = await database.SelectUser(Email, Password);

            if (user == null)
            {
                LoginResponse = "El email o contraseña no son correctos.";
                return user;
            }

            LoginResponse = "Ha iniciado sesión correctamente";
            return user;

        }
    }
}
