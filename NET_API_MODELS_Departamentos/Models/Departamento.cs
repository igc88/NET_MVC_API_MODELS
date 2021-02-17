using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Departamentos.Models {
    public class Departamento {
        private int _codigo;
        private string _nombre = string.Empty;
        private int _presupuesto;
        private ICollection<Empleado> _empleados;

        public int Codigo {
            get => _codigo;
            set => _codigo = value;
        }
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        public int Presupuesto {
            get => _presupuesto;
            set => _presupuesto = value;
        }
        public ICollection<Empleado> Empleados {
            get => _empleados;
            set => _empleados = value;
        }
    }
}
