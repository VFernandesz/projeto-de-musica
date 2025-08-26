// using System.ComponentModel.DataAnnotations;

// namespace Api.Models;

// public class Usuario
// {
//     public int Id { get; set; }

//     [Required]
//     public string Nome { get; set; } = string.Empty;

//     [Required]
//     [EmailAddress]
//     public string Email { get; set; } = string.Empty;

//     [Required]
//     [DataType(DataType.Password)]
//     public string Senha { get; set; } = string.Empty; // Armazenar senhas em texto plano não é seguro. Use hashing!
// }