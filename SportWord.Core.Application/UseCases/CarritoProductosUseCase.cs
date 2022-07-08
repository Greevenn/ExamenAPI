using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;


namespace SportWord.Core.Application.UseCases
{
    public class CarritoProductosUseCase : IDetailUseCase<Carrito, Guid>
    {
        private readonly IBaseRepository<Carrito, Guid> CarritoRepository;
        private readonly IDetailRepository<Carrito_Productos, Guid> CarritoProductosRepository;
        public CarritoProductosUseCase(
            IBaseRepository<Carrito, Guid> CarritoRepository,
            IDetailRepository<Carrito_Productos, Guid> CarritoProductosRepository
            )
        {
            this.CarritoRepository = CarritoRepository;
            this.CarritoProductosRepository = CarritoProductosRepository;
        }

        public void Cancel(Guid entityId)
        {
            CarritoProductosRepository.Cancel(entityId);
            CarritoProductosRepository.saveAllChanges();
        }

        public Carrito Create(Carrito carrito)
        {
            var CreateCarrito = CarritoRepository.Create(carrito);
            carrito.carrito_productos.ForEach(detail =>{
                CarritoProductosRepository.Create(detail);
            });
            CarritoRepository.saveAllChanges();
            return CreateCarrito;
        }
    }
}
