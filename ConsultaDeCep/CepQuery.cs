﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDeCep
{
    internal class CepQuery
    {
        public string Cep { get;set; }
        public string Localidade { get; set; }
        public string Estado { get; set; }
        public DateTime Date { get; set; }

        public CepQuery(CepResponse cep)
        {
            Cep = cep.Cep;
            Localidade = cep.Localidade;
            Estado = cep.Estado;
            Date = DateTime.Now;
        }
    }
}
