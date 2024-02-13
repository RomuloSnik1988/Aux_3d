using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aux_3d.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage ="O nome do produto deve ser informado")]
    [Display(Name = "Nome do produto")]
    [MaxLength(100, ErrorMessage ="O nome não deve exeder 100 caracteres")]
    public string  Nome { get; set; }

    [Required(ErrorMessage =" A descrição deve ser preenchida")]
    [MaxLength(255, ErrorMessage ="A descrição não deve exeder {1} caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage ="A descrição detalhada deve ser preenchida")]
    [MaxLength(255, ErrorMessage ="A descrição detalhada não deve ultrapassar {1} caracteres")]
    public string  DescricaoDetalhada { get; set; }

    [Required(ErrorMessage ="O preço deve ser preenchido")]
    [Display(Name ="Preço")]
    [Column(TypeName ="decimal(10,2)")]
    [Range(1,9999.99, ErrorMessage ="O preço deve esta entre 1 e 9999,99")]
    public decimal Preco { get; set; }

    [Display(Name ="Caminho Imagem Normal")]
    [StringLength(200, ErrorMessage ="O {} deve ter no maximo {1}")]
    public string ImagemUrl  { get; set; }

    [Display(Name ="Caminho Imagem Miniatura")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1}")]
    public string ImagemThumbnailUrl { get; set; }

    [Display(Name ="Preferido?")]
    public bool IsProdutoPreferido { get; set; }

    [Display(Name= "Estoque")]
    public bool EmEstoque { get; set; }

    public int CategoriaID { get; set; }

    public virtual Categoria Categoria { get; set; }
}
