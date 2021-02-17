using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Departamentos.Models {
    public class Empleado {
        private int _dni;
        private string _nombre;
        private int _apellido;
        private Departamento _departamento;
        public int DNI {
            get => _dni;
            set => _dni = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public int Apellido {
            get => _apellido;
            set => _apellido = value;
        }
        public Departamento Departamento {
            get => _departamento;
            set => _departamento = value;
        }
    }
}
