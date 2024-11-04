using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liveCSharp.App
{
    public class Aluno
    {
        /**
         * Método construtor         
         */
        public Aluno(int id=0, string name=null, string email=null, string telefone=null, string senha=null, bool ativo=false)
        {
            Id = id;
            Name = name;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            Ativo = ativo;
        }

        // propriedades
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }


        public void Inserir()
        {
            var cmd = Conexao.Abrir();
        }

    }
}
