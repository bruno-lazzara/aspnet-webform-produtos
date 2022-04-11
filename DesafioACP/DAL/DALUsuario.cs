using DesafioACP.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioACP.DAL
{
    public class DALUsuario
    {
        private System.Configuration.ConnectionStringSettings connString;

        public DALUsuario()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }

        public void Inserir(ModeloUsuario obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (RegistroExiste(obj.Email))
                {
                    throw new Exception("Já existe um usuário cadastrado com este e-mail.");
                }

                cmd.Connection = con;
                cmd.CommandText = "Insert into usuario (nome, email, senha) values (@nome,@email,@senha);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("email", obj.Email);
                cmd.Parameters.AddWithValue("senha", obj.Senha);
                con.Open();
                obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Alterar(ModeloUsuario obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (RegistroExiste(obj.Email) && GetRegistro(obj.Id).Email != obj.Email)
                {
                    throw new Exception("Este e-mail já está cadastrado em outro usuário, insira um novo e-mail.");
                }

                if (obj.Senha == "")
                {
                    cmd.CommandText = "update usuario set nome=@nome, email=@email where id = @id;";
                }
                else
                {
                    cmd.CommandText = "update usuario set nome=@nome, email=@email, senha=@senha where id = @id;";
                    cmd.Parameters.AddWithValue("senha", obj.Senha);
                }
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("email", obj.Email);
                cmd.Parameters.AddWithValue("id", obj.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Excluir(int cod)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "delete from usuario where id = " + cod.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Listar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from usuario", connString.ConnectionString);
            try
            {
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ModeloUsuario GetRegistro(int id)
        {
            ModeloUsuario obj = new ModeloUsuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from usuario where id= @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.Nome = Convert.ToString(registro["nome"]);
                    obj.Email = Convert.ToString(registro["email"]);
                    obj.Senha = Convert.ToString(registro["senha"]);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return obj;
        }

        public ModeloUsuario GetRegistro(string email)
        {
            ModeloUsuario obj = new ModeloUsuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from usuario where email= @email";
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.Nome = Convert.ToString(registro["nome"]);
                    obj.Email = Convert.ToString(registro["email"]);
                    obj.Senha = Convert.ToString(registro["senha"]);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return obj;
        }

        public bool RegistroExiste(string email)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from usuario where email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}