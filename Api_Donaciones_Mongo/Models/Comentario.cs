using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

public class Comentario
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = null;

    public int UsuarioId { get; set; }
    public int? DonacionId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El comentario es obligatorio")]
    [StringLength(1000, ErrorMessage = "El comentario no puede exceder 1000 caracteres")]
    public string Texto { get; set; }

    [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5")]
    public int Calificacion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}