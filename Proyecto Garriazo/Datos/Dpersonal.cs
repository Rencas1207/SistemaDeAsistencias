using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ORUSCURSO.Logica;
using System.Windows.Forms;
namespace ORUSCURSO.Datos
{
   public  class Dpersonal
    {
        public bool InsertarPersonal(Lpersonal parametros )
        {
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("InsertarPersonal", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
				cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
				cmd.Parameters.AddWithValue("@Pais", parametros.Pais );
				cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo );
				cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public bool editarPersonal(Lpersonal parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("editarPersonal", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
				cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
				cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
				cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
				cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo);
				cmd.Parameters.AddWithValue("@Sueldo_por_hora", parametros.SueldoPorHora);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public bool eliminarPersonal(Lpersonal parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("eliminarPersonal", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Idpersonal", parametros.Id_personal);;
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public void MostrarPersonal(ref DataTable dt, int desde,int hasta)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("mostrarPersonal", CONEXIONMAESTRA.conectar);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
				da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
				da.Fill(dt);


			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public void BuscarPersonal(ref DataTable dt, int desde, int hasta,string buscador)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("BuscarPersonal", CONEXIONMAESTRA.conectar);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
				da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
				da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public bool restaurar_personal(Lpersonal parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("restaurar_personal", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Idpersonal", parametros.Id_personal); ;
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public void ContarPersonal(ref int Contador)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("select Count(Id_personal) from Personal", CONEXIONMAESTRA.conectar);
				Contador =Convert.ToInt32( cmd.ExecuteScalar());
			}
			catch (Exception )
			{
				Contador = 0;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}

	}
}
