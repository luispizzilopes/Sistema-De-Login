using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaLogin.Entities; 

namespace SistemaLogin
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private string strComandoSql = string.Empty;
        SqlConnection? connection = null;
        SqlCommand? command = null;

        private bool VerificarCadastroExistente()
        {
            if(txtBoxLogin.Text != string.Empty && txtBoxSenha.Text != string.Empty)
            {
                connection = new SqlConnection(StrConexao.strConexaoBd);
                strComandoSql = "select * from TabelaLogin where Login = @Login";
                command = new SqlCommand(strComandoSql, connection);
                command.Parameters.Add("Login", SqlDbType.VarChar).Value = txtBoxLogin.Text;
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if(dataReader.HasRows == true)
                    {
                        return true;  
                    }
                    else
                    {
                        return false; 
                    }
                }
                catch(SqlException ex) 
                {
                    MessageBox.Show(ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; 
                }
                finally { connection.Close(); }
            }
            else
            {
                return true; 
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            if (VerificarCadastroExistente() == false)
            {
                connection = new SqlConnection(StrConexao.strConexaoBd);
                strComandoSql = "insert into TabelaLogin values (@Login, @Senha)";
                command = new SqlCommand(strComandoSql, connection);
                command.Parameters.Add("Login", SqlDbType.VarChar).Value = txtBoxLogin.Text;
                command.Parameters.Add("Senha", SqlDbType.VarChar).Value = txtBoxSenha.Text;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Erro na conexão com o Bd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Já existe um Login igual ao informado na base de dados, tente novamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Visible = false; 
        }
    }
}
