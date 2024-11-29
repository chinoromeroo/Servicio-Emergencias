using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CChofer:CEmpleado
    {
        private uint registro;
        private string distrito;

        public CChofer(ulong ID, string APE, string NOM, uint REG, string DIST) :base(ID, APE, NOM)
        {
            this.registro = REG;
            this.distrito = DIST;
        }
        public override string ToString()
        {
            string datos = base.ToString();
            datos += " - REGISTRO: " + this.registro;
            datos += " - DISTRITO: " + this.distrito;
            return datos;
        }

    }
}
