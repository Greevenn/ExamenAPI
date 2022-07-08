using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models.Interfaces
{
    public interface ITransaction
    {
        void saveAllChanges();
    }
}
