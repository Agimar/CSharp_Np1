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
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
            chkAtivo.Checked = false;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();

            Aluno aluno = new Aluno();
            var lista = aluno.ListarAlunos(0,(int)numericUpDown1.Value);
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
