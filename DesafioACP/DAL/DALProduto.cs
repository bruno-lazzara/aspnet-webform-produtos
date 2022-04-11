using DesafioACP.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioACP.DAL
{
    public class DALProduto
    {
        private System.Configuration.ConnectionStringSettings connString;

        public DALProduto()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }

        public void Inserir(ModeloProduto obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (RegistroExiste(obj.NomeProduto))
                {
                    throw new Exception("Este produto já existe, insira um novo produto.");
                }

                cmd.Connection = con;
                cmd.CommandText = "Insert into produto (nome, preco, quantidade, ultima_alteracao_por) values (@nome,@preco,@quantidade,@ultima_alteracao_por);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.NomeProduto);
                cmd.Parameters.AddWithValue("preco", obj.Preco);
                cmd.Parameters.AddWithValue("quantidade", obj.Quantidade);
                cmd.Parameters.AddWithValue("ultima_alteracao_por", obj.UltimaAlteracaoPor);
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

        public void Alterar(ModeloProduto obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (RegistroExiste(obj.NomeProduto) && GetRegistro(obj.Id).NomeProduto != obj.NomeProduto)
                {
                    throw new Exception("Este produto já existe, insira um novo produto.");
                }

                cmd.Connection = con;
                cmd.CommandText = "update produto set nome=@nome, preco=@preco, quantidade=@quantidade, ultima_alteracao_por=@ultima_alteracao_por where id = @id;";
                cmd.Parameters.AddWithValue("nome", obj.NomeProduto);
                cmd.Parameters.AddWithValue("preco", obj.Preco);
                cmd.Parameters.AddWithValue("quantidade", obj.Quantidade);
                cmd.Parameters.AddWithValue("ultima_alteracao_por", obj.UltimaAlteracaoPor);
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

        public void ExcluirQuantidade(int cod, int alteradoPor)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "update produto set quantidade=0, ultima_alteracao_por=@ultima_alteracao_por where id = @id;";
                cmd.Parameters.AddWithValue("id", cod);
                cmd.Parameters.AddWithValue("ultima_alteracao_por", alteradoPor);
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.id as id, p.nome as nome, p.preco as preco, " +
                "p.quantidade as quantidade, u.nome as usuario " +
                "FROM produto p, usuario u " +
                "WHERE p.ultima_alteracao_por = u.id", connString.ConnectionString);
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

        public ModeloProduto GetRegistro(int id)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from produto where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.NomeProduto = Convert.ToString(registro["nome"]);
                    obj.Preco = Convert.ToInt32(registro["preco"]);
                    obj.Quantidade = Convert.ToInt32(registro["quantidade"]);
                    obj.UltimaAlteracaoPor = Convert.ToInt32(registro["ultima_alteracao_por"]);
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

        public ModeloProduto GetRegistro(string nome)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from produto where nome = @nome";
                cmd.Parameters.AddWithValue("@nome", nome);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.NomeProduto = Convert.ToString(registro["nome"]);
                    obj.Preco = Convert.ToInt32(registro["preco"]);
                    obj.Quantidade = Convert.ToInt32(registro["quantidade"]);
                    obj.UltimaAlteracaoPor = Convert.ToInt32(registro["ultima_alteracao_por"]);
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

        public bool RegistroExiste(string nome)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from produto where nome = @nome";
                cmd.Parameters.AddWithValue("@nome", nome);
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