using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
