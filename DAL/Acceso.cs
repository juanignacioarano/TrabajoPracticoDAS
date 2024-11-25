using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DAL
{
    public class Acceso
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.;Initial Catalog=TrabajoPractico;Integrated Security=True");

        public void abrir()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void cerrar()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable Leer(string sp, SqlParameter[] parametros)
        {
            abrir();
            DataTable dt = new DataTable();
            dt.TableName = "Objeto";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandText = sp;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Connection = connection;
            if (parametros != null)
            {
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.AddRange(parametros);
            }
            da.Fill(dt);
            cerrar();
            return dt;
        }

        public int Escribir(string sp, SqlParameter[] parametros)
        {
            abrir();
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            SqlTransaction ts = connection.BeginTransaction();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = connection;
            cmd.Transaction = ts;
            if (parametros != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parametros);
            }
            try
            {
                i = cmd.ExecuteNonQuery();
                ts.Commit();
            }
            catch (Exception ex)
            {
                ts.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cerrar();
            }
            return i;
        }


        public int EscribirLista(List<(string procedimiento, SqlParameter[] parametros)> operaciones)
        {
            int totalRegistrosAfectados = 0;

            using (connection)
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    foreach (var operacion in operaciones)
                    {
                        SqlCommand cmd = new SqlCommand
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = operacion.procedimiento,
                            Connection = connection,
                            Transaction = transaction
                        };

                        if (operacion.parametros != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(operacion.parametros);
                        }

                        totalRegistrosAfectados += cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalRegistrosAfectados;
        }


        public void ExportarStoredProcedureAXml(string storedProcedureName, string fileName, SqlParameter[] parametros = null)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string filePath = System.IO.Path.Combine(desktopPath, fileName + ".xml");

                Leer(storedProcedureName, parametros).WriteXml(filePath);

                MessageBox.Show("Exportado con éxito en la ruta: " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mostrar el archivo en el explorador y asegurar que se haga scroll hasta él
                ShowFileInExplorer(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In] IntPtr[] apidl, uint dwFlags);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHParseDisplayName(string pszName, IntPtr pbc, out IntPtr ppidl, uint sfgaoIn, out uint psfgaoOut);

        private void ShowFileInExplorer(string filePath)
        {
            IntPtr pidl;
            uint psfgaoOut;

            int hr = SHParseDisplayName(filePath, IntPtr.Zero, out pidl, 0, out psfgaoOut);
            if (hr == 0) // S_OK
            {
                SHOpenFolderAndSelectItems(pidl, 0, null, 0);
                Marshal.FreeCoTaskMem(pidl);
            }
            else
            {
                MessageBox.Show("No se pudo mostrar el archivo en el explorador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
