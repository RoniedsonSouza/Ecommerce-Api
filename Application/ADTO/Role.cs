﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class Role : IdentityRole<int>
    {
        public List<UsuarioRoles> UserRoles { get; set; }
    }
}
