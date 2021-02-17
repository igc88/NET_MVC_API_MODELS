using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Almacenes.Models {
    public class Almacen {
        private int _codigo;
        private string _lugar = string.Empty;
        private int _capacidad;
        private ICollection<Caja> _articulos;

        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Lugar {
            get => _lugar;
            set => _lugar = value;
        }
        public int Capacidad {
            get => _capacidad;
            set => _capacidad = value;
        }
        public ICollection<Caja> Articulos {
            get => _articulos;
            set => _articulos = value;
        }
    }
}
