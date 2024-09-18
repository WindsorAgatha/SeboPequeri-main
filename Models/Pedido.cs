using System;
using System.Collections.Generic;

namespace SeboPequeri.Models
{
    public class Pedido
    {
        public enum StatusPedido
        {
            AguardandoPagamento,
            PagamentoConfirmado,
            EmSeparacao,
            Enviado,
            Entregue,
            Cancelado
        }

        public int PedidoId { get; set; }
        public StatusPedido Status { get; set; }
        public DateTime DataPedido { get; set; }
        public Usuario Usuario { get; set; }
        public decimal ValorPedido { get; set; }
        public List<Livro> Livros { get; set; }


        public Pedido() { }

        public Pedido(StatusPedido status, DateTime dataPedido, decimal valorPedido, Usuario usuario)
        {
            Status = status;
            Usuario = usuario;
            DataPedido = dataPedido;
            ValorPedido = valorPedido;
            Livros = new List<Livro>();
        }
    }
}
