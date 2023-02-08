using System.Data.SqlClient;
using SistemaLogin.Entities; 

namespace SistemaLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private string strComandoSql = string.Empty;
        SqlConnection? connection = null;
        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtBoxLogin.Text != string.Empty && txtBoxSenha.Text != string.Empty)
            {
                strComandoSql = "select * from TabelaLogin where Login = @Login and Senha = @Senha";
                connection = new SqlConnection(StrConexao.strConexaoBd);
                SqlCommand command = new SqlCommand(strComandoSql, connection);
                command.Parameters.Add("Login", System.Data.SqlDbType.VarChar).Value = txtBoxLogin.Text;
                command.Parameters.Add("Senha", System.Data.SqlDbType.VarChar).Value = txtBoxSenha.Text;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows == true)
                    {
                        MessageBox.Show("Login efetuado com sucesso!", "Acessando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível localizar as informações enviadas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { connection.Close(); }

            }
            else
            {
                MessageBox.Show("Informe o Login e Senha corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastrar = new Cadastro();
            cadastrar.ShowDialog();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            try
            {
                StrConexao.Caminho();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível localizar o arquivo LocalConexao.dll, tente novamente!\nDescrição do erro: " + ex.Message, "Erro fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); 
            }
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}