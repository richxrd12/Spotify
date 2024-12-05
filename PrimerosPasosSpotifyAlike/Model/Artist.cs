using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MusicGenre { get; set; }

        //Pendiente porque igual no interesa (?)
        public string? Biography { get; set; }
    }
}
