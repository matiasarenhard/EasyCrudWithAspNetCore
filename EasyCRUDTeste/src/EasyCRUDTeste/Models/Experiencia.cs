using System;
using System.Collections.Generic;

namespace EasyCRUDTeste.Models
{
    public partial class Experiencia
    {
        public int IdExperiencia { get; set; }
        public int IdPessoa { get; set; }
        public int? Nivel { get; set; }
        public string Nome { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
