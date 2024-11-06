using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using liveCSharp.App;

namespace liveCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(
                0,
                txtNome.Text,
                txtEmail.Text,
                txtTelefone.Text,
                txtSenha.Text,
                true
                );

            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
            MessageBox.Show("Aluno inserido com sucesso!");

            LimparCampos();
        }

        public void LimparCampos()
        {
            txtId.Clear();
            txtId.ReadOnly = true;
            txtNome.Clear();
            txtEmail.Clear();
            txtEmail.ReadOnly = false;
            txtTelefone.Clear();
            txtSenha.Clear();
            txtSenha.ReadOnly = false;
            txtConfirmaSenha.Clear();
            chkAtivo.Enabled = false;
            chkAtivo.Checked = true;
            btnInserir.Enabled = true;
            btnUpdate.Text = "...";
            btnUpdate.Width = 26;
            btnUpdate.Height = 23;
            btnAlterar.Enabled = false;
            chkVisualizar.Enabled = true;
            btnExcluir.Enabled = false; 
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();

            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos();
            lista.ForEach(a => {
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[colId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colAtivo.Index].Value = a.Ativo;
            });
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (decimal) Aluno.ObterQtideRegistro();
        }

        private void chkVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizar.Checked)
                txtSenha.UseSystemPasswordChar = false;
            else
                txtSenha.UseSystemPasswordChar = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Id = int.Parse(txtId.Text);
            aluno.Nome = txtNome.Text;
            aluno.Email = txtEmail.Text;
            aluno.Telefone = txtTelefone.Text;
            aluno.Senha = txtSenha.Text;
            aluno.Ativo = chkAtivo.Checked;
            aluno.Alterar(aluno);

            MessageBox.Show($"Aluno {aluno.Nome} alterado com sucesso! ");
            LimparCampos();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            if (btnUpdate.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                btnInserir.Enabled = false;
                chkAtivo.Enabled = true;
                btnUpdate.Text = "Update";
                chkVisualizar.Enabled = false;
                chkAtivo.Checked = false;
            }
            else if (btnUpdate.Text == "Update")
            {
                if (txtId.Text != string.Empty)
                {
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;

                    aluno.ConsultarPorId(int.Parse(txtId.Text));
                    txtNome.Text = aluno.Nome;
                    txtEmail.Text = aluno.Email;
                    txtEmail.ReadOnly = true;
                    txtTelefone.Text = aluno.Telefone;
                    txtSenha.Text = aluno.Senha;
                    txtSenha.ReadOnly = true;
                    chkAtivo.Checked = aluno.Ativo;
                }
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Excluir(int.Parse(txtId.Text));
            MessageBox.Show($"Aluno excluido com sucesso");

            LimparCampos();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();

            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos(0, (int)numericUpDown1.Value);
            lista.ForEach(a => {
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[colId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[colAtivo.Index].Value = a.Ativo;
            });
        }
    }
}
