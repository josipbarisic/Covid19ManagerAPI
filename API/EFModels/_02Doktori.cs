﻿using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02Doktori
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
