﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_1.Models
{
    public class LoginModel
    {
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsSubmitted { get; set; }

    }
}