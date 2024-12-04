using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class Album
    {
        //Album también debería tener las canciones, no(?)
        private int id { get; set; }
        private string name { get; set; }
        private int releaseYear { get; set; }
        private int artistId { get; set; }
    }
}
