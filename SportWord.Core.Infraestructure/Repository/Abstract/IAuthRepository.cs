using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Infraestructure.Repository.Abstract
{
    public interface IAuthRepository <Entity, key>
    {
        Entity Login(Entity entity);
        string GetToken(Entity entity, key key);
    }
}
