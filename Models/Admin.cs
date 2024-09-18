namespace SeboPequeri.Models;

public class Admin : Usuario
{
    public int AdminId { get; set; }

    public Admin(string email, string nome, string telefone, string password) : base(nome, telefone, email, password)
    {

    }
    // Exemplo de herança para fins didaticos, não será usado: Foi substituido pelo enum Role na classe Usuário
    // Não haverá entidade admin no banco de dados

}