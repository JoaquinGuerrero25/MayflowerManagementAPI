using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request.Credential;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        User? ValidateUser(CredentialRequest credentialRequest);
        string AuthenticateCredentials(CredentialRequest credentialRequest);
    }
}
