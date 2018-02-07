using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacaoEFCookie.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50,MinimumLength=4)]
        public string NomeUsuario { get; set; }
        [StringLength(50,MinimumLength=6)]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50,MinimumLength=6)]
        public string Senha { get; set; }
    }
}