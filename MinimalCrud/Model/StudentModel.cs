using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MinimalCrud.Model
{
    public class StudentModel
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();

        [Required(ErrorMessage = "Informe seu nome")]
        [StringLength(80, ErrorMessage = "Nome não pode possuir mais que 80 caracteres")]
        [MinLength(5, ErrorMessage = "Nome deve possuir no mínimo 5 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe seu Telefone.")]
        [Phone]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Endereço não pode possuir mais que 100 caracteres")]
        [MinLength(20, ErrorMessage = "Endereço deve possuir no mínimo 20 caracteres")]
        [DisplayName("Endereço")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe seu Email.")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;


    }
}
