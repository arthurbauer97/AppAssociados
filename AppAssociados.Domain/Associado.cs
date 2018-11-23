using System;
using System.Collections.Generic;

namespace AppAssociados.Domain
{
    public class Associado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime dataCadastro { get; set; }
        public string ruaEndereco { get; set; }
        public int numeroEndereco { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string email { get; set; }
        public EstadoCivil estadoCivil { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<Dependente> dependentes { get; set; }
    }
}