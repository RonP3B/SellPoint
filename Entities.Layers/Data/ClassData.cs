using Entities.Layers.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Layers.Data
{
    public class ClassData
    {
        //Metodo para insertar una entidad a la base de datos
        public void createEntity(ClassEntity entity)
        {
            if (entity == null) return;

            string storedProcedure = "SpEntidadesInsertar";

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();

            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ObjSqlCommand.Parameters.Add(new SqlParameter("@DESCRIPCION", entity.Descripcion));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@DIRECCION", entity.Direccion));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@LOCALIDAD", entity.Localidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TIPOENTIDAD", entity.TipoEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TIPODOCUMENTO", entity.TipoDocumento));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", entity.NumeroDocumento));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TELEFONOS", entity.Telefonos));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLPAGINAWEB", entity.URLPaginaWeb));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLFACEBOOK", entity.URLFacebook));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLINSTAGRAM", entity.URLInstagram));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLTWITTER", entity.URLTwitter));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLTIKTOK", entity.URLTikTok));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@CODIGOPOSTAL", entity.CodigoPostal));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@COORDENADASGPS", entity.CoordenadasGPS));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@LIMITECREDITO", entity.LimiteCredito));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@USERNAMEENTIDAD", entity.UserNameEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@PASSWORDENTIDAD", entity.PasswordEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@ROLUSERENTIDAD", entity.RolUserEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@COMENTARIO", entity.Comentario));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@ESTATUS", entity.Estatus));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@NOELIMINABLE", entity.NoEliminable));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@FECHAREGISTRO", entity.FechaRegistro));

                ObjSqlConnection.Open();
                ObjSqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                        "No fue posible crear la entidad\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }
        }

        //Metodo para obtener una entidad de la base de datos
        public Tuple<DataTable, ClassEntity> readEntity(string user)
        {

            string storedProcedure = "SpEntidadesObtener";

            DataTable ObjDataTable = null;
            ClassEntity searchedEntity = null;

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter ObjSqlDataAdapter = new SqlDataAdapter(ObjSqlCommand);
                ObjSqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@UserName", user));

                ObjDataTable = new DataTable();
                ObjSqlDataAdapter.Fill(ObjDataTable);

                if (ObjDataTable.Rows.Count == 1)
                {
                    DataRow row = ObjDataTable.Rows[0];
                    searchedEntity = new ClassEntity();

                    searchedEntity.IdEntidad = Convert.ToInt32(row["IdEntidad"]);
                    searchedEntity.Descripcion = row["Descripcion"] == null ? "" : row["Descripcion"].ToString();
                    searchedEntity.Direccion = row["Direccion"] == null ? "" : row["Direccion"].ToString();
                    searchedEntity.Localidad = row["Localidad"] == null ? "" : row["Localidad"].ToString();
                    searchedEntity.TipoEntidad = row["TipoEntidad"] == null ? "" : row["TipoEntidad"].ToString();
                    searchedEntity.TipoDocumento = row["TipoDocumento"] == null ? "" : row["TipoDocumento"].ToString();
                    searchedEntity.NumeroDocumento = Convert.ToInt64(row["NumeroDocumento"]);
                    searchedEntity.Telefonos = row["Telefonos"] == null ? "" : row["Telefonos"].ToString();
                    searchedEntity.URLPaginaWeb = row["URLPaginaWeb"] == null ? "" : row["URLPaginaWeb"].ToString();
                    searchedEntity.URLFacebook = row["URLFacebook"] == null ? "" : row["URLFacebook"].ToString();
                    searchedEntity.URLInstagram = (row["URLInstagram"] == null ? "" : row["URLInstagram"].ToString());
                    searchedEntity.URLTwitter = row["URLTwitter"] == null ? "" : row["URLTwitter"].ToString();
                    searchedEntity.URLTikTok = row["URLTikTok"] == null ? "" : row["URLTikTok"].ToString();
                    searchedEntity.CodigoPostal = row["CodigoPostal"] == null ? "" : row["CodigoPostal"].ToString();
                    searchedEntity.CoordenadasGPS = row["CoordenadasGPS"] == null ? "" : row["CoordenadasGPS"].ToString();
                    searchedEntity.LimiteCredito = Convert.ToInt32(row["LimiteCredito"]);
                    searchedEntity.UserNameEntidad = row["UserNameEntidad"] == null ? "" : row["UserNameEntidad"].ToString();
                    searchedEntity.PasswordEntidad = row["PasswordEntidad"] == null ? "" : row["PasswordEntidad"].ToString();
                    searchedEntity.RolUserEntidad = row["RolUserEntidad"] == null ? "" : row["RolUserEntidad"].ToString();
                    searchedEntity.Comentario = row["Comentario"] == null ? "" : row["Comentario"].ToString();
                    searchedEntity.Estatus = row["Estatus"] == null ? "" : row["Estatus"].ToString();
                    searchedEntity.NoEliminable = Convert.ToInt32(row["NoEliminable"]);
                    searchedEntity.FechaRegistro = (DateTime)row["FechaRegistro"];

                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                   "No fue posible obtener la entidad\nExcepción: " + e
                );
            }

            return Tuple.Create(ObjDataTable, searchedEntity);
        }

        //Metodo para actualizar una entidad de la base de datos
        public void updateEntity(int entityToUpdateId, ClassEntity updatedEntity)
        {
            if (updatedEntity == null) return;

            string storedProcedure = "SpEntidadesActualizar";

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ObjSqlCommand.Parameters.Add(new SqlParameter("@IDENTIDAD", entityToUpdateId));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@DESCRIPCION", updatedEntity.Descripcion));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@DIRECCION", updatedEntity.Direccion));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@LOCALIDAD", updatedEntity.Localidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TIPOENTIDAD", updatedEntity.TipoEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TIPODOCUMENTO", updatedEntity.TipoDocumento));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", updatedEntity.NumeroDocumento));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@TELEFONOS", updatedEntity.Telefonos));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLPAGINAWEB", updatedEntity.URLPaginaWeb));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLFACEBOOK", updatedEntity.URLFacebook));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLINSTAGRAM", updatedEntity.URLInstagram));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLTWITTER", updatedEntity.URLTwitter));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@URLTIKTOK", updatedEntity.URLTikTok));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@CODIGOPOSTAL", updatedEntity.CodigoPostal));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@COORDENADASGPS", updatedEntity.CoordenadasGPS));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@LIMITECREDITO", updatedEntity.LimiteCredito));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@USERNAMEENTIDAD", updatedEntity.UserNameEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@PASSWORDENTIDAD", updatedEntity.PasswordEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@ROLUSERENTIDAD", updatedEntity.RolUserEntidad));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@COMENTARIO", updatedEntity.Comentario));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@ESTATUS", updatedEntity.Estatus));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@NOELIMINABLE", updatedEntity.NoEliminable));
                ObjSqlCommand.Parameters.Add(new SqlParameter("@FECHAREGISTRO", updatedEntity.FechaRegistro));

                ObjSqlConnection.Open();
                ObjSqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                   "No fue posible actualizar la entidad\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }
        }

        //Metodo para eliminar una entidad de la base de datos
        public void deleteEntity(int entityID)
        {
            if (entityID < 1) return;

            string storedProcedure = "SpEntidadesEliminar";

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                ObjSqlCommand.Parameters.Add(new SqlParameter("@IDENTIDAD", entityID));

                ObjSqlConnection.Open();
                ObjSqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                   "No fue posible eliminar la entidad\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }
        }

        //Metodo para obtener todas las entidades de a la base de datos
        public DataTable readAllEntities()
        {
            string storedProcedure = "SpEntidadesListar";

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter ObjSqlDataAdapter = new SqlDataAdapter(ObjSqlCommand);


                DataTable ObjDataTable = new DataTable();
                ObjSqlDataAdapter.Fill(ObjDataTable);

                return ObjDataTable;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                   "No fue posible obtener todas las entidades\nExcepción: " + e
                );
            }

            return null;

        }

        //Metodo para autenticar el inicio de sesión
        public bool isAuthenticated(string user, string password)
        {

            string storedProcedure = "SpEntidadesVerificarAuntenticacion";
            bool result = false;

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter ObjDataAdapter = new SqlDataAdapter(ObjSqlCommand);
                ObjDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@UserNameEntidad", user));
                ObjDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@PasswordEntidad", password));

                ObjSqlConnection.Open();
                SqlDataReader ObjSqlDataReader = ObjSqlCommand.ExecuteReader();

                result = ObjSqlDataReader.HasRows;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    "La entidad dada no fue encontrada\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return result;
        }

        //Metodo para verificar que el usuario exista
        public bool userExist(string user)
        {

            string storedProcedure = "SpVerificarUsuario";
            bool result = false;

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter ObjSqlDataAdapter = new SqlDataAdapter(ObjSqlCommand);
                ObjSqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Usuario", user));

                DataTable ObjDataTable = new DataTable();
                ObjSqlDataAdapter.Fill(ObjDataTable);

                result = ObjDataTable.Rows.Count > 0;
                
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Error al buscar al usuario\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return result;
        }

        //Metodo para verificar si el numero de documento existe
        public bool documentNumberExist(long documentNumber)
        {

            string storedProcedure = "SpVerificarNumeroDocumento";
            bool result = false;

            SqlConnection ObjSqlConnection = ClassConnectionDB.StringConnectionDB();
            SqlCommand ObjSqlCommand = new SqlCommand(storedProcedure, ObjSqlConnection);
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter ObjSqlDataAdapter = new SqlDataAdapter(ObjSqlCommand);
                ObjSqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@NumeroDocumento", documentNumber));

                DataTable ObjDataTable = new DataTable();
                ObjSqlDataAdapter.Fill(ObjDataTable);

                result = ObjDataTable.Rows.Count > 0;


            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Error al buscar al usuario\nExcepción: " + e
                );
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return result;
        }

    }
}
