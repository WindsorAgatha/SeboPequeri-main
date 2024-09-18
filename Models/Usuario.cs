using System.ComponentModel.DataAnnotations;

namespace SeboPequeri.Models;

public class Usuario
{
    public enum CargoUsuario
    {
        Administrador,
        Cliente
    }

    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    [StringLength(20)]  
    public CargoUsuario Cargo { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool EstaAtivo { get; set; } = true;     // para realização de soft-delete   // default === true


    public Usuario() { }

    public Usuario(string nome, string telefone, string email, string senha)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Cargo = Cargo;
        Senha = senha;
    }

}