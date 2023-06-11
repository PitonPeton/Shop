using shop.Domain.Entities.Shippers;
using shop.Domain.Repository;
using shop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace shop.Infraestructure.Interfaces
{
    public interface IShipperRepository : IBaseRepository<Shipper>
    {
        List<ShipperModel> GetShippers();
    }
}