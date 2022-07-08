using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models.Interfaces;
namespace SportWord.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
