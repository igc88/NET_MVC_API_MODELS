using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Peliculas.Models {
    public class Sala {
        private int _codigo;
        private string _nombre;
        private Pelicula _pelicula;
        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }        
        public Pelicula Pelicula {
            get => _pelicula;
            set => _pelicula = value;
        }
    }
}
