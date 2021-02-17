using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Fabricantes.Models {
    public class Articulo {
        private int _codigo;
        private string _nombre;
        private int _precio;
        private Fabricante _fabricante;
        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public int Precio {
            get => _precio;
            set => _precio = value;
        }
        public Fabricante Fabricante {
            get => _fabricante;
            set => _fabricante = value;
        }
    }
}
