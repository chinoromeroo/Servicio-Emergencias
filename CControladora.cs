using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    class CControladora
    {
        public static void Main()
        {
            char opcion;
            CEmpresa empresa = new CEmpresa();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                ulong auxID;
                string auxApe, auxNom, auxCat, auxDist, auxPat, auxMarca, auxMod, auxAmb, auxFecha;
                uint auxReg;
                ushort auxMatr;
                switch(opcion)
                {
                    case 'A':
                        string tipo = CInterfaz.PedirDato(" [A] PARA REGISTRAR UN PROFESIONAL --- [B] PARA REGISTRAR UN CHOFER ");
                        if (tipo.ToUpper() == "A")
                        {
                            auxID = Convert.ToUInt64(CInterfaz.PedirDato(" IDENTIFICACIÓN "));
                            auxApe = CInterfaz.PedirDato(" APELLIDO ");
                            auxNom = CInterfaz.PedirDato(" NOMBRE ");
                            auxMatr = Convert.ToUInt16(CInterfaz.PedirDato(" MATRICULA "));
                            auxCat = "";
                            string CATEGORIA = CInterfaz.PedirDato(" SI ES [A] MEDICO --- [B] ENFERMERO --- [C] PARAMEDICO ");
                            if (CATEGORIA.ToUpper() == "A"){ 
                                auxCat = "Medico"; 
                            } else if (CATEGORIA.ToUpper() == "B") { 
                                auxCat = "Enfermero"; 
                            } else if (CATEGORIA.ToUpper() == "C") { 
                                auxCat = "Paramedico"; 
                            } else
                            {
                                CInterfaz.MostrarInfo(" OPCIÓN INVALIDA ");
                            }

                            if(empresa.BuscarEmpleado(auxID) == null)
                            {
                                empresa.AgregarEmpleado(new CProfesional(auxID, auxApe, auxNom, auxMatr, auxCat));
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("EL EMPLEADO YA FUE REGISTRADO ANTERIORMENTE");
                            }
                        } else if (tipo.ToUpper() == "B")
                        {
                            auxID = Convert.ToUInt64(CInterfaz.PedirDato(" IDENTIFICACIÓN "));
                            auxApe = CInterfaz.PedirDato(" APELLIDO ");
                            auxNom = CInterfaz.PedirDato(" NOMBRE ");
                            auxReg = Convert.ToUInt32(CInterfaz.PedirDato(" REGISTRO "));
                            auxDist = CInterfaz.PedirDato(" DISTRITO ");

                            if(empresa.BuscarEmpleado(auxID) == null)
                            {
                                empresa.AgregarEmpleado(new CChofer(auxID, auxApe, auxNom, auxReg, auxDist));
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("EL EMPLEADO YA FUE REGISTRADO ANTERIORMENTE");
                            }

                        }
                        else
                        {
                            CInterfaz.MostrarInfo("DEBE INGRESAR [A] O [B]");
                        }
                        break;
                    case 'B':
                        CInterfaz.MostrarInfo(empresa.mostrarEmpleados());
                        break;
                    case 'C':
                        auxPat = CInterfaz.PedirDato(" PATENTE ");
                        auxMarca = CInterfaz.PedirDato(" MARCA ");
                        auxMod = CInterfaz.PedirDato(" MODELO ");
                        tipo = CInterfaz.PedirDato(" [A] AUTO --- [B] AMBULANCIA");
                        
                        if(tipo.ToUpper() == "A")
                        {
                            if(empresa.BuscarVehiculo(auxPat) == null)
                            {
                                empresa.AgregarVehiculo(new CVehiculo(auxPat, auxMarca, auxMod, "AUTO"));
                            }
                            else
                            {
                                CInterfaz.MostrarInfo(" EL AUTO YA FUE REGISTRADO ANTERIORMENTE");
                            }
                        } else if (tipo.ToUpper() == "B")
                        {
                            string AMBULANCIA = "";
                            AMBULANCIA = CInterfaz.PedirDato(" [A] EMG --- [B] UTIM --- [C] UCM");
                            if (AMBULANCIA.ToUpper() == "A")
                            {
                                auxAmb = "EMG";
                                if (empresa.BuscarVehiculo(auxPat) == null)
                                {
                                    empresa.AgregarVehiculo(new CVehiculo(auxPat, auxMarca, auxMod, auxAmb));
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo(" LA AMBULANCIA YA FUE REGISTRADA ANTERIORMENTE");
                                }
                            }
                            else if (AMBULANCIA.ToUpper() == "B")
                            {
                                auxAmb = "UTIM";
                                if (empresa.BuscarVehiculo(auxPat) == null)
                                {
                                    empresa.AgregarVehiculo(new CVehiculo(auxPat, auxMarca, auxMod, auxAmb));
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo(" LA AMBULANCIA YA FUE REGISTRADA ");
                                }
                            }
                            else if (AMBULANCIA.ToUpper() == "C")
                            {
                                auxAmb = "UCM";
                                if (empresa.BuscarVehiculo(auxPat) == null)
                                {
                                    empresa.AgregarVehiculo(new CVehiculo(auxPat, auxMarca, auxMod, auxAmb));
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo(" LA AMBULANCIA YA FUE REGISTRADA ");
                                }
                            }
                            else
                            {
                                CInterfaz.MostrarInfo(" OPCIÓN INVALIDA ");
                            }
                        }
                        break;
                    case 'D':
                        empresa.OrdenarVehiculos();
                        CInterfaz.MostrarInfo(empresa.mostrarVehiculos());
                        break;
                    case 'E':
                        if (empresa.CantidadEmpleados() > 0) {
                            auxID = Convert.ToUInt64(CInterfaz.PedirDato(" IDENTIFICACIÓN DEL CHOFER"));
                            CEmpleado auxChofer = empresa.BuscarEmpleado(auxID);
                            if(auxChofer != null)
                            {
                                auxChofer.setIntDot(true);
                                auxFecha = CInterfaz.PedirDato(" FECHA DE LA DOTACIÓN (D/M/Y)");

                                CDotaciones DOT = new CDotaciones();
                                DOT.setFecha(auxFecha);
                                DOT.setChofer((CChofer)auxChofer); // CASTEO PASO DE EMPLEADO A CHOFER

                                int CANTIDAD = int.Parse(CInterfaz.PedirDato(" CANTIDAD DE PROFESIONALES A DERIVAR AL VEHICULO"));
                                for(int i = 0; i < CANTIDAD; i++)
                                {
                                    ulong IDENTIFICACION = ulong.Parse(CInterfaz.PedirDato(" IDENTIFICACIÓN DEL PROFESIONAL"));
                                    CEmpleado auxProf = empresa.BuscarEmpleado(IDENTIFICACION);
                                    if(auxProf != null)
                                    {
                                        auxProf.setIntDot(true);
                                        DOT.AgregarProfesional((CProfesional)auxProf); // CASTEO PASO DE EMPLEADO A PROFSEIONAL
                                    }
                                }

                                auxPat = CInterfaz.PedirDato(" PATENTE ");
                                CVehiculo auxVehiculo = empresa.BuscarVehiculo(auxPat);
                                if(CANTIDAD > 2)
                                {
                                    if(auxVehiculo.getAmb().ToUpper() == "AUTO")
                                    {
                                        CInterfaz.MostrarInfo("DEBE INGRESAR UNA AMBULANCIA PARA ESA CANTIDAD DE PROFESIONALES");
                                    }
                                    else
                                    {
                                        DOT.setVehiculo(auxVehiculo);
                                        empresa.AgregarDotacion(DOT);
                                        CInterfaz.MostrarInfo("DOTACIÓN REGISTRADA");
                                    }
                                }
                                else
                                {
                                    if (auxVehiculo.getAmb().ToUpper() != "AUTO")
                                    {
                                        CInterfaz.MostrarInfo(" DEBE INGRESAR UN AUTO PARA ESTA CANTIDAD DE PROFESIONALES");
                                    }
                                    else
                                    {
                                        DOT.setVehiculo(auxVehiculo);
                                        empresa.AgregarDotacion(DOT);
                                        CInterfaz.MostrarInfo("DOTACIÓN REGISTRADA");
                                    }
                                }
                            }
                            else
                            {
                                CInterfaz.MostrarInfo(" NO EXISTE NINGÚN CHOFER CON ESA IDENTIFICACIÓN ");
                            }
                        } else
                        {
                            CInterfaz.MostrarInfo(" NO HAY EMPLEADOS REGISTRADOS");
                        }
                        break;
                    case 'F':
                        if(empresa.CantidadEmpleados() > 0)
                        {
                            auxID = Convert.ToUInt64(CInterfaz.PedirDato(" IDENTIFICACIÓN DEL EMPLEADO A ELIMINAR"));
                            empresa.EliminarEmpleado(auxID);
                        } else
                        {
                            CInterfaz.MostrarInfo(" NO HAY EMPLEADOS REGISTRADOS PARA ELIMINAR");
                        }
                        break;
                    case 'G':
                        auxID = Convert.ToUInt64(CInterfaz.PedirDato(" IDENTIFICACIÓN DEL EMPLEADO PARA VER EL INFORME COMPLETO"));
                        CInterfaz.MostrarInfo(empresa.DatosEmpleado(auxID));
                        break;
                    case 'H':
                        if (empresa.CantidadDotaciones() > 0)
                        {
                            auxPat = CInterfaz.PedirDato(" PATENTE ");
                            auxFecha = CInterfaz.PedirDato(" FECHA (D/M/Y)");
                            CInterfaz.MostrarInfo(empresa.InfoDotaciones(auxFecha, auxPat));
                        } else
                        {
                            CInterfaz.MostrarInfo(" NO HAY DOTACIONES REGISTRADAS");
                        }
                        break;
                }
            } while (opcion != 'S');
        }
    }

}
