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

namespace SistemaLogin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string strComandoSql = string.Empty;
        private string strConexaoBd = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbLogin;Data Source=DESKTOP-CK95DQO\\SQLEXPRESS01";
        SqlConnection? connection = null;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtBoxLogin.Text != string.Empty && txtBoxSenha.Text != string.Empty)
            {
                strComandoSql = "insert into TabelaLogin values (@Login, @Senha)";
                connection = new SqlConnection(strConexaoBd);
                SqlCommand command = new SqlCommand(strComandoSql, connection);
                command.Parameters.Add("Login", System.Data.SqlDbType.VarChar).Value = txtBoxLogin.Text;
                command.Parameters.Add("Senha", System.Data.SqlDbType.VarChar).Value = txtBoxSenha.Text;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { connection.Close(); }
            }
            else
            {
                MessageBox.Show("Informe o Login e a Senha corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }
    }
}
