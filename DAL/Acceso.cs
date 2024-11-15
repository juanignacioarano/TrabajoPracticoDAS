using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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


        public void ExportarStoredProcedureAXml(string storedProcedureName, string filePath, SqlParameter[] parametros = null)
        {
            Leer(storedProcedureName, parametros).WriteXml(filePath);
            MessageBox.Show("Exportado con exito en la ruta: " + filePath);
        }

    }
}
