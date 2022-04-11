﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioACP.MODELO
{
    public class ModeloUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ModeloUsuario()
        {
            this.Id = 0;
            this.Nome = "";
            this.Email = "";
            this.Senha = "";
        }
    }
}