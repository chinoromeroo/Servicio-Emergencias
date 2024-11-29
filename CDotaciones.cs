using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CDotaciones
    {
        private ArrayList listaProfesionales = new ArrayList();
        private CVehiculo vehiculo;
        private CChofer chofer;
        public string fecha;

        public CDotaciones()
        {
            this.vehiculo = null;
            this.chofer = null;
            this.fecha = " SIN REGISTRAR ";
        }

        public CDotaciones(CVehiculo VEH, CChofer CHOF, string FECH)
        {
            this.vehiculo = VEH;
            this.chofer = CHOF;
            this.fecha = FECH;
        }
        // SETTERS
        public void setVehiculo(CVehiculo VEHICULO) { this.vehiculo = VEHICULO; }
        public void setChofer (CChofer CHOFER) { this.chofer = CHOFER;}
        public void setFecha (string FECH) { this.fecha = FECH;}
        
        // GETTERS
        public CVehiculo getVehiculo() { return this.vehiculo;}
        public CChofer getChofer() { return this.chofer;} 
        public string getFecha () { return this.fecha; }

        // FUNCIONES
        public CProfesional BuscarProfesional(ulong ID)
        {
            foreach(CProfesional AUX  in this.listaProfesionales)
            {
                if(AUX.getId() == ID)
                {
                    return AUX;
                }
            }
            return null;
        }

        public bool AgregarProfesional(CProfesional PROF)
        {
            if(this.BuscarProfesional(PROF.getId()) == null)
            {
                this.listaProfesionales.Add(PROF);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string datos = "";
            datos += "FECHA: " + this.fecha + "\n";
            datos += " - CHOFER: \n" + "    " + this.chofer + "\n";
            datos += " - PROFESIONALES: \n";
            foreach(CProfesional AUX in this.listaProfesionales)
            {
                datos += "    " + AUX.ToString() + "\n";
            }
            datos += " - VEHICULO: \n" + "    " + this.vehiculo + "\n";
            return datos;
        }
    }
}
