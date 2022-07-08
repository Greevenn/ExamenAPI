using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;

namespace SportWord.Core.Application.Interfaces
{
    public interface IAuthUseCase
    {
        string Login(User user, string key);
    }
}
