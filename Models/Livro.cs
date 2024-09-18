namespace SeboPequeri.Models
{
    public enum GeneroLiterario
    {
        Romance,
        FiccaoCientifica,
        Fantasia,
        Suspense,
        Terror,
        Drama,
        Poesia,
        Aventura,
        Biografia,
        AutoAjuda,
        Historia,
        InfantoJuvenil,
        Outros
    }

    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? ImgUrl { get; set; }
        public GeneroLiterario Genero { get; set; }
        public decimal Preco { get; set; }
        public int? Avaliacao { get; set; }
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
        public string Editora { get; set; }

        public Livro() { }

        public Livro
        (
            string titulo,
            string autor,
            string imgUrl,
            GeneroLiterario genero,
            decimal preco,
            int avaliacao,
            string descricao,
            int quantidade,
            string isbn,
            int anoPublicacao,
            string editora
        )
        {
            Titulo = titulo;
            Autor = autor;
            ImgUrl = imgUrl;
            Genero = genero;
            Preco = preco;
            Avaliacao = avaliacao;
            Descricao = descricao;
            Quantidade = quantidade;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;
            Editora = editora;
        }
    }
}
