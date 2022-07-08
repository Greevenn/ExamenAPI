using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models.Interfaces;
namespace SportWord.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}
