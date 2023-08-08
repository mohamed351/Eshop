﻿using EShop.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Interfaces
{
    public interface ITokenService
    {
       public string CreateToken(AppUser user);

    }
}
