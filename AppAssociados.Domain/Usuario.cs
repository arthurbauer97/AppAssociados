using System.ComponentModel.DataAnnotations;

namespace AppAssociados.Domain
{
    public class Usuario
    {
        public int id { get; set; }
        [Required(ErrorMessage="O nome do usuário é obrigatório",AllowEmptyStrings=false)]
        public string usuario { get; set; }
        [Required(ErrorMessage="Digite outra senha",AllowEmptyStrings = false)]
        [StringLength(12,MinimumLength=4)]
        public string senha { get; set; }
    }
}