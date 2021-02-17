using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Fabricantes.Models {
    public class Fabricante {
        private int _codigo;
        private string _nombre = string.Empty;
        private ICollection<Articulo> _articulos;

        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public ICollection<Articulo> Articulos {
            get => _articulos;
            set => _articulos = value;
        }
    }
}
