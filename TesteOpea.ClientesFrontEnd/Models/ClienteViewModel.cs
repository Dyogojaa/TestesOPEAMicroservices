using System.ComponentModel.DataAnnotations;

namespace TesteOpea.ClientesFrontEnd.Models
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        
        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage ="Nome da Empresa é Requerido!")]
        public string? NomeEmpresa { get; set; }
        [Display(Name = "Porte da Empresa")]
        [Required]
        public string? PorteEmpresa { get; set; }
    }
}
