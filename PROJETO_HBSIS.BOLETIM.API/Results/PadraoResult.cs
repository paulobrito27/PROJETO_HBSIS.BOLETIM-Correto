﻿using System.Collections.Generic;
using System.Net;

namespace PROJETO_HBSIS.BOLETIM.API.Results
{
    public class PadraoResult<T>
    {
        public List<T> Data { get; set; }
        public bool Error { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public HttpStatusCode Status { get; set; }

    }
}
