using System.ComponentModel.DataAnnotations;

namespace Entitites.Dtos
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }
        [Required(ErrorMessage = "Category name is required.")]
        public String? CategoryName { get; init; } = String.Empty;
    }
}