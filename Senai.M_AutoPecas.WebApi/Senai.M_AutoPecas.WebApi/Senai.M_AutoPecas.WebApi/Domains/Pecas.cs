using System;
using System.Collections.Generic;

namespace Senai.M_AutoPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPeca { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public int? IdFonecedor { get; set; }

        public Fornecedores IdFonecedorNavigation { get; set; }
    }
}
