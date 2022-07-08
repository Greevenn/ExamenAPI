using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class UserTiendasUseCase : IDetailUseCase<Tiendas, Guid>
    {
        private readonly IBaseRepository<Tiendas, Guid> TiendasRepository;
        private readonly IDetailRepository<User_Tienda, Guid> UserTiendasRepository;
        public UserTiendasUseCase(
            IBaseRepository<Tiendas, Guid> TiendasRepository,
            IDetailRepository<User_Tienda, Guid> UserTiendasRepository
            )
        {
            this.TiendasRepository = TiendasRepository;
            this.UserTiendasRepository = UserTiendasRepository;
        }
        public void Cancel(Guid entityId)
        {
            UserTiendasRepository.Cancel(entityId);
            UserTiendasRepository.saveAllChanges();
        }

        public Tiendas Create(Tiendas tiendas)
        {
            var CreateCategoria = TiendasRepository.Create(tiendas);
            tiendas.User_Tienda.ForEach(detail => {
                UserTiendasRepository.Create(detail);
            });
            TiendasRepository.saveAllChanges();
            return CreateCategoria;
        }
    }
}
