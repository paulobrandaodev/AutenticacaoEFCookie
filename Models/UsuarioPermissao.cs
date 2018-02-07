using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacaoEFCookie.Models
{
    public class UsuarioPermissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioPermissao { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdPermissao { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario usuario { get; set;}

        [ForeignKey("IdPermissao")]
        public Permissao permissao { get; set; }
    }
}