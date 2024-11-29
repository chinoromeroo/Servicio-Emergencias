using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CProfesional:CEmpleado
    {
        private ushort matricula;
        private string categoria;

        public CProfesional(ulong ID, string APE, string NOM, ushort MATR, string CAT): base(ID, APE, NOM)
        {
            this.matricula = MATR;
            this.categoria = CAT;
        }
        // SETTERS
        public void setCat(string CAT) { this.categoria = CAT; }
        public void setMat(ushort MAT) { this.matricula = MAT; }
        // GETTERS
        public string GetCategoria() { return this.categoria; }
        public ushort getMat () { return this.matricula; }


        public override string ToString()
        {
            string datos = base.ToString();
            datos += " - MATRICULA: " + this.matricula;
            datos += " - CATEGORIA: " + this.categoria;
            return datos;
        }
    }
}
