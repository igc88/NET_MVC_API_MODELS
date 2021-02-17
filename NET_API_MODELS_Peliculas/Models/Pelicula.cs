using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Peliculas.Models {
    public class Pelicula {
        private int _codigo;
        private string _nombre = string.Empty;
        private int _calificacionEdad;
        private ICollection<Sala> _salas;

        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public int CalificacionEdad {
            get => _calificacionEdad;
            set => _calificacionEdad = value;
        }
        public ICollection<Sala> Salas {
            get => _salas;
            set => _salas = value;
        }
    }
}
