using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models {
    [Table("Lanches")]
    public class Lanche {
        [Key]
        public int LancheId { get; set; }
        [StringLength(80, ErrorMessage = "Máximo de 80 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Nome do lanche")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição obrigatória")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage ="Mínimo de {1} caracteres")]
        [MaxLength(200, ErrorMessage ="Máximo de {1} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "Descrição datalhada obrigatória")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Máximo de {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Preço obrigatório")]
        [Display(Name = "Preço do lanche")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999.99")]
        public decimal Preco { get; set; }
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "Caminho imagem normal")]
        public string ImagemUrl { get; set; }
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "Caminho imagem miniatura")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
