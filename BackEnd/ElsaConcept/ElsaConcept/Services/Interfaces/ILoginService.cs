using ElsaConcept.Data.DTO;
using ElsaConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Services.Interfaces
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UserDTO user);

        TokenDTO ValidateCredentials(TokenDTO token);

    }
}
