using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models.Interfaces;

namespace SportWord.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository <Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {
    }
}
