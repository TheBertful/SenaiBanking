﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Transferencia : Transacao
    {
        public ContaCorrente Favorecido { get; set; }
    }
}