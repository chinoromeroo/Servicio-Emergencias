using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CVehiculo:IComparable
    {
        private string patente;
        private string marca;
        private string modelo;
        private string tipo_ambulancia;

        public CVehiculo()
        {
            this.patente = "SIN ASIGNAR";
            this.marca = "SIN ASIGNAR";
            this.modelo = "SIN ASIGNAR";
            this.tipo_ambulancia = "SIN ASINAR";
        }
        public CVehiculo(string PAT, string MARC, string MOD, string AMB)
        {
            this.patente = PAT;
            this.marca = MARC;
            this.modelo = MOD;
            this.tipo_ambulancia = AMB;
        }
        public string getPat() { return this.patente; }
        public string getAmb() { return this.tipo_ambulancia; }

        public override string ToString()
        {
            string datos = "";
            datos += "PATENTE: " + this.patente;
            datos += " - MARCA: " + this.marca;
            datos += " - MODELO: " + this.modelo;
            datos += " - TIPO VEHICULO: " + this.tipo_ambulancia;
            return datos;
        }

        public int CompareTo(object VEH)
        {
            return this.patente.CompareTo(((CVehiculo)VEH).getPat());
        }
    }
}
