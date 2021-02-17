using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Almacenes.Models {
    public class Caja {
        private int _numReferencia;
        private string _contenido;
        private int _valor;
        private Almacen _almacen;
        public int NumReferencia {
            get => _numReferencia;
            set => _numReferencia = value;
        }
        public string Contenido {
            get => _contenido;
            set => _contenido = value;
        }
        public int Valor {
            get => _valor;
            set => _valor = value;
        }
        public Almacen Almacen {
            get => _almacen;
            set => _almacen = value;
        }
    }
}
