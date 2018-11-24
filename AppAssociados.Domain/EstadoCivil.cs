using System.ComponentModel.DataAnnotations;

namespace AppAssociados.Domain
{
    public class EstadoCivil
    {
        public int id { get; set; }

        [Required(ErrorMessage="Estado Civil Obrigatorio!",AllowEmptyStrings=false)]

        public string descricao { get; set; }
    }
}