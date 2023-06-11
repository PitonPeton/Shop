using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using shop.Domain.Entities.Shippers;
using shop.Infraestructure.Context;
using shop.Infraestructure.Core;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Models;

namespace shop.Infraestructure.Repositories
{
    public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
    {
        private ILogger<ShipperRepository> logger;
        private shopContext context;

        public ShipperRepository(ILogger<ShipperRepository> logger,
                                shopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<ShipperModel> GetShippers()
        {
            List<ShipperModel> shippers = new List<ShipperModel>();

            try
            {
                shippers = this.context.Shippers.Select(de => new ShipperModel()
                {
                    shipname = de.shipname,
                    companyname = de.companyname,
                    phone = de.phone,
                    shippeddate = de.shippeddate
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo expedidos", ex.ToString());
            }

            return shippers;
        }

        public override void Add(Shipper entity)
        {

            if (this.Exists(cd => cd.shipname == entity.shipname))
            {
                throw new ShipperException("");
            }

            base.SaveChanges();
        }

        public override void Delete(Shipper entity)
        {
            if (this.Exists(cd => cd.shipname == entity.shipname))
            {
                throw new ShipperException("");
            }

            base.SaveChanges();
        }

        public override void Update(Shipper entity)
        {
            base.Update(entity);
        }
    }
}
