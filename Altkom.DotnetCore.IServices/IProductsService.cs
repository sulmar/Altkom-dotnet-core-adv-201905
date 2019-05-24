using Altkom.DotnetCore.Models;
using System.Collections.Generic;

namespace Altkom.DotnetCore.IServices
{
    public interface IProductsService : IEntitiesService<Product>
    {
        IEnumerable<Product> Get(string color);
    }




}
