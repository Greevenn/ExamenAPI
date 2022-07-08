using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models.Interfaces;

namespace SportWord.Core.Infraestructure.Repository.Abstract
{
        public interface IDetailRepository<Entity, TrasactionId> : ICreate<Entity>, ITransaction
        {
            List<Entity> GetDetailsByTransaction(TrasactionId trasactionId);
            void Cancel(Guid entityId);
    }
}
