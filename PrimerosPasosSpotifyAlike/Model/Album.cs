﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerosPasosSpotifyAlike.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int ArtistId { get; set; }
        public List<Cancion> Canciones { get; set; }
    }
}
