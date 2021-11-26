using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;
namespace CapaNegocio
{
    public class N_Usuario
    {
        D_Usuario d_Usuario = new D_Usuario();
        public E_Usuario BuscarUsuario(String pUser,String pContrasenia)
        {
            DataTable dataTable = d_Usuario.BuscarUsuario(pUser, pContrasenia);
            try
            {
                if(dataTable != null)
                {
                    if (dataTable.Rows.Count != 1)
                    {
                        return null;
                    }
                    else
                    {
                        E_Usuario e_Usuario = new E_Usuario
                        {
                            Usuario = dataTable.Rows[0][1].ToString(),
                            Acceso = dataTable.Rows[0][2].ToString()
                        };
                        return e_Usuario;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
