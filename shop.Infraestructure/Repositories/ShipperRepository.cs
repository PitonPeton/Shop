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
                    shipperid = de.shipperid,
                    companyname = de.companyname,
                    phone = de.phone,
                    shipname = de.shipname,
                    shipaddress = de.shipaddress,
                    shipcity = de.shipcity,
                    shippostalcode = de.shippostalcode,
                    shipregion = de.shipregion,
                    shipcountry = de.shipcountry,
                    shippeddate = de.shippeddate,
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo expedidos", ex.ToString());
            }

            return shippers;
        }

        public ShipperModel GetShipperById(int id)
        {
            ShipperModel shipperModel = new ShipperModel();

            try
            {
                Shipper shipper = this.GetEntity(id);

                if (shipper == null)
                {
                    throw new ShipperDataException("El expedido no existe.");
                }

                shipperModel.shipperid = shipper.shipperid;
                shipperModel.companyname = shipper.companyname;
                shipperModel.phone = shipper.phone;
                shipperModel.shippeddate = shipper.shippeddate;
                shipperModel.shipcountry = shipper.shipcountry;
            }
            catch (ShipperDataException dex)
            {
                throw new ShipperDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo expedidos", ex.ToString());
            }
            return shipperModel;
        }

        public override void Add(Shipper entity)
        {

            if (this.Exists(cd => cd.shipname == entity.shipname))
            {
                throw new ShipperException("Expedido Existe");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Shipper entity)
        {
            try
            {
                Shipper shipperToUpdate = this.GetEntity(entity.shipperid);

                if (shipperToUpdate == null)
                {
                    throw new ShipperDataException("El expedido no existe.");
                }

                shipperToUpdate.shipperid = entity.shipperid;
                shipperToUpdate.companyname = entity.companyname;
                shipperToUpdate.phone = entity.phone;
                shipperToUpdate.shipname = entity.shipname;
                shipperToUpdate.shipaddress = entity.shipaddress;
                shipperToUpdate.shipcity = entity.shipcity;
                shipperToUpdate.shipregion = entity.shipregion;
                shipperToUpdate.shippostalcode = entity.shippostalcode;
                shipperToUpdate.shippeddate = entity.shippeddate;
                shipperToUpdate.shipcountry = entity.shipcountry;

                this.context.Shippers.Update(shipperToUpdate);
                this.context.SaveChanges();
            }
            catch (ShipperDataException dex)
            {
                throw new ShipperDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando expedidos", ex.ToString());
            };
        }

        public override void Delete(Shipper entity)
        {
            try
            {
                Shipper shipperToDelete = this.GetEntity(entity.shipperid);

                if (shipperToDelete == null)
                {
                    throw new OrderDataException("La orden no existe.");
                }

                shipperToDelete.Deleted = entity.Deleted;
                shipperToDelete.Delete_date = entity.Delete_date;
                shipperToDelete.Delete_user = entity.Delete_user;

                this.context.Shippers.Update(shipperToDelete);
                this.context.SaveChanges();
            }
            catch (ShipperDataException dex)
            {
                throw new ShipperDataException(dex.Message);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error eliminando expedido", ex.ToString());
            }
            base.SaveChanges();
        }

    }
}
