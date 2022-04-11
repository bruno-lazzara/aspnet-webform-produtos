using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioACP.MODELO
{
    public class ModeloProduto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }
        public int UltimaAlteracaoPor { get; set; }

        public ModeloProduto()
        {
            this.Id = 0;
            this.NomeProduto = "";
            this.Preco = 0;
            this.Quantidade = 0;
            this.UltimaAlteracaoPor = 1;
        }
    }
}