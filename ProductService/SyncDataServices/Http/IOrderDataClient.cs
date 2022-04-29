﻿using ProductService.DTOs;

namespace ProductService.SyncDataServices.Http
{
    public interface IOrderDataClient
    {
        Task SendProductToOrder(ProductCreateDTO product);
    }
}
