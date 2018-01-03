using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alura.MVC.Inicial.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

    }
}