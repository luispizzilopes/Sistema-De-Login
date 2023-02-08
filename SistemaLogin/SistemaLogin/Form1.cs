using System.Data.SqlClient;

namespace SistemaLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string strComandoSql = string.Empty;
        private string strConexaoBd = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbLogin;Data Source=DESKTOP-CK95DQO\\SQLEXPRESS01"; 
        SqlConnection? connection = null;
        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtBoxLogin.Text != string.Empty && txtBoxSenha.Text != string.Empty)
            {
                strComandoSql = "select * from TabelaLogin where Login = @Login and Senha = @Senha";
                connection = new SqlConnection(strConexaoBd);
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
            Form2 cadastrar = new Form2();
            cadastrar.ShowDialog();
        }
    }
}