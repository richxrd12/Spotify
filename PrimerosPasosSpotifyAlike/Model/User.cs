using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class User
    {
        private string id { get; set; }
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private int idPlaylist { get; set; }
    }
}
