using System.Collections.Generic;
using ProductInspection.Services.Models;

namespace ProductInspection.Services
{
    /// <summary>
    /// Задает интерфейс взаимодействия с источником данных
    /// к примеру <see cref="DatabaseProductsService"/>
    /// </summary>
    public interface IProductsService
    {
        List<ProductReport> GetIcomingProducts();
    }
}