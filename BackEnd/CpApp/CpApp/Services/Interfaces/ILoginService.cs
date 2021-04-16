using CpApp.Data.DTO;
using CpApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Services.Interfaces
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UserDTO user);

        TokenDTO ValidateCredentials(TokenDTO token);

    }
}
