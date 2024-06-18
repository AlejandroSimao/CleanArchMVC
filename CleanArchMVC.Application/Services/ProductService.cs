using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
           
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new ApplicationException("Entity cloud not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new ApplicationException("Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //        throw new ApplicationException("Entity could not be loaded.");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new ApplicationException("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
