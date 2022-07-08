using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models.Interfaces
{
    public interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
