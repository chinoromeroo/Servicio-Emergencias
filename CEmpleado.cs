using System;

namespace Emergencias
{
    class CEmpleado
    {
        private ulong id;
        private string apellido;
        private string nombre;

        private bool integraDotacion;

        // CONSTRUCTOR DEFAUTL
        public CEmpleado()
        {
            this.id = 0;
            this.apellido = "SIN ASIGNAR";
            this.nombre = "SIN ASIGNAR";
        }

        // CONSTRUCTOR CON PARAMETIZACIONES
        public CEmpleado(ulong ID, string APE, string NOM)
        {
            this.id = ID;
            this.apellido = APE;
            this.nombre = NOM;
        }

        // SETTERS
        public void setIntDot(bool VALOR) { this.integraDotacion = VALOR;}
        // GETTERS
        public ulong getId() { return this.id; }
        public string getNom() {  return this.nombre; }
        public bool getIntDot() { return this.integraDotacion; }

        public override string ToString()
        {
            string datos = "";
            datos += "ID: " + this.id;
            datos += " - NOMBRE Y APELLIDO: " + this.apellido + " " + this.nombre;
            return datos;
        }

    }
}
