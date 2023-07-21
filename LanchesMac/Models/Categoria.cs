using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models {
    [Table("Categorias")]
    public class Categoria {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(100,ErrorMessage = "Máximo de 100 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name ="Nome")]
        public String CategoriaNome { get; set; }
        [StringLength(200,ErrorMessage="Máximo de 200 caracteres")]
        [Required(ErrorMessage = "Descrição obrigatória")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set;}
    }
}
