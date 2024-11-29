using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CEmpresa
    {
        private ArrayList listadoEmpleados  = new ArrayList();
        private ArrayList listadoVehiculos  = new ArrayList();
        private ArrayList listadoDotaciones = new ArrayList();
        // EMPLEADOS
        public CEmpleado BuscarEmpleado(ulong ID)
        {
            foreach(CEmpleado AUX in this.listadoEmpleados)
            {
                if(AUX.getId() == ID)
                {
                    return AUX;
                }
            }
            return null;
        }

        public bool AgregarEmpleado(CEmpleado EMP)
        {
            if(this.BuscarEmpleado(EMP.getId()) == null)
            {
                this.listadoEmpleados.Add(EMP);
                return true;
            }
            return false;
        }

        public string mostrarEmpleados()
        {
            string datos = "";
            
            if(this.listadoEmpleados.Count == 0 ) { return datos = "NO HAY EMPLEADOS REGISTRADOS"; }

            foreach(CEmpleado AUX in this.listadoEmpleados)
            {
                if (AUX is CProfesional)
                {
                    datos += "PROFESIONAL: \n";
                    datos += AUX.ToString() + "\n\n";
                }
                else
                {
                    datos += "CHOFER: \n";
                    datos += AUX.ToString() + "\n\n";
                }
            }
            return datos;
        }

        public bool EliminarEmpleado(ulong ID)
        {
            CEmpleado AUX = this.BuscarEmpleado(ID);
            if(AUX != null)
            {
                if (AUX.getIntDot())
                {
                    CInterfaz.MostrarInfo("EL EMPLEADO INTEGRA UNA DOTACIÓN");
                    return false;
                }
                else
                {
                    this.listadoEmpleados.Remove(AUX);
                    CInterfaz.MostrarInfo("EL EMPLEADO FUE ELIMINADO CON EXITO");
                    return true;
                }
            }
            else
            {
                CInterfaz.MostrarInfo("NO EXISTE EL EMPLEADO");
                return false;
            }
        }

        public string DatosEmpleado(ulong ID)
        {
            string datos = "";
            CEmpleado EMP = this.BuscarEmpleado(ID);
            if (EMP != null)
            {
                if(EMP is CChofer)
                {
                    datos += "CHOFER: " + EMP.getNom() + "\n";
                    foreach(CDotaciones AUX in this.listadoDotaciones)
                    {
                        if(EMP.getId() == AUX.getChofer().getId())
                        {
                            datos += "FECHA: " + AUX.getFecha() + "\n";
                            datos += AUX.getVehiculo().ToString();
                            return datos;
                        }
                    }
                    return datos;
                }
                else
                {
                    datos += "PROFESIONAL: " + EMP.getNom() + "\n";
                    foreach(CDotaciones AUX in this.listadoDotaciones)
                    {
                        if(EMP.getId() == AUX.BuscarProfesional(ID).getId())
                        {
                            datos += "FECHA: " + AUX.getFecha() + "\n";
                            datos += AUX.getVehiculo().ToString() + "\n";
                            return datos;
                        }
                    }
                    return datos;
                }
            }

            datos = "EMPLEADO INEXISTENTE";
            return datos;
        }

        public int CantidadEmpleados() { return this.listadoEmpleados.Count;}

        // VEHICULOS
        public CVehiculo BuscarVehiculo(string PAT)
        {
            foreach(CVehiculo AUX in this.listadoVehiculos)
            {
                if(AUX.getPat() == PAT)
                {
                    return AUX;
                }
            }
            return null;
        }

        public bool AgregarVehiculo(CVehiculo VEH)
        {
            if(this.BuscarVehiculo(VEH.getPat()) == null)
            {
                this.listadoVehiculos.Add(VEH);
                return true;
            }
            return false;
        }

        public void OrdenarVehiculos()
        {
            this.listadoVehiculos.Sort();
        }

        public string mostrarVehiculos()
        {
            string datos = "";

            if (this.listadoVehiculos.Count == 0) { return datos = "NO HAY VEHICULOS REGISTRADOS"; }


            foreach (CVehiculo AUX in this.listadoVehiculos)
            {
                datos += AUX.ToString() + "\n\n";
            }
            return datos;
        }

        // DOTACIONES
        public int CantidadDotaciones() { return this.listadoDotaciones.Count;}
        public void AgregarDotacion(CDotaciones DOT)
        {
            this.listadoDotaciones.Add(DOT);
        }

        public string InfoDotaciones(string FECHA, string PAT)
        {
            string datos = "";
            foreach(CDotaciones AUX in this.listadoDotaciones)
            {
                if(AUX.getVehiculo().getPat() == PAT && AUX.getFecha() == FECHA)
                {
                    datos += AUX.ToString();
                    return datos;
                }
            }

            datos = "NO SE ENCONTRARON DOTACIONES";
            return datos;
        }
    }
}
