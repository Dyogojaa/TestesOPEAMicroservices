using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteOpea.ClientesAPI.Model.Base;

namespace TesteOpea.ClientesAPI.Model
{
    public class Cliente : BaseEntity
    {
        
        [Column(name:"nome_empresa")]
        [MaxLength(100)]
        [Required]
        public string? NomeEmpresa { get; set; }

        [Column(name: "porte_empresa")]
        [MaxLength(30)]
        [Required]
        public string? PorteEmpresa { get; set; }


    }
}
