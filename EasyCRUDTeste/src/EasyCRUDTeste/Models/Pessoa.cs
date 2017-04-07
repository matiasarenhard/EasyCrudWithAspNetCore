using System;
using System.Collections.Generic;

namespace EasyCRUDTeste.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Experiencia = new HashSet<Experiencia>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? Idade { get; set; }
        public string Skype { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Portfolio { get; set; }
        public string NomeBanco { get; set; }
        public string Cpf { get; set; }
        public string NomePessoaBanco { get; set; }
        public string TipoConta { get; set; }
        public string Agencia { get; set; }
        public string NrConta { get; set; }
        public string Opconta { get; set; }
        public string Disponibilidade { get; set; }
        public string Horario { get; set; }

        public virtual ICollection<Experiencia> Experiencia { get; set; }
    }
}
