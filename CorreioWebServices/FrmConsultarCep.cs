using System;
using System.Windows.Forms;

namespace CorreioWebServices
{
    public partial class FrmConsultarCep : Form
    {
        public FrmConsultarCep()
        {
            InitializeComponent();
        }

        #region Eventos de click dos buttons
        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(textBoxCep.Text.Trim());

                        textBoxEstado.Text = endereco.uf;
                        textBoxCidade.Text = endereco.cidade;
                        textBoxBairro.Text = endereco.bairro;
                        textBoxRua.Text = endereco.end;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cep invalido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxCep.Text = string.Empty;
            textBoxEstado.Text = string.Empty;
            textBoxCidade.Text = string.Empty;
            textBoxBairro.Text = string.Empty;
            textBoxRua.Text = string.Empty;
        }

        private void buttonSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
/*  INSTALAÇÃO API CORREIOS

    Botão direito em cima de References
    Add Services Reference
    Link da API: https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl, GO
    Renomear Namespace para WSCorreios (caso queira mudar o nome alterar tbm a classe FrmConsultarCep.cs), OK
 */
