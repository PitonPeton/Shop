using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using shop.Application.Core;
using shop.Application.Dtos.Shipper;
using shop.Domain.Entities.Shippers;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Application.Contract;
using Microsoft.Extensions.Logging;

namespace shop.Application.Service
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;
        private readonly ILogger<ShipperService> logger;

        public ShipperService(IShipperRepository shipperRepository, ILogger<ShipperService> logger)
        {
            this.shipperRepository = shipperRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.shipperRepository.GetShippers();
            }
            catch (ShipperException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los remitentes";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.shipperRepository.GetShipperById(id);
            }
            catch (ShipperDataException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el remitente";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(ShipperAddDto model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.shipname))
            {
                result.Message = "El nombre del remitente es requerido.";
                result.Success = false;
                return result;
            }
            if (model.shipname.Length > 40)
            {
                result.Message = "El nombre del remitente tiene una longitud invalida.";
                result.Success = false;
                return result;
            }

            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.shipperRepository.Add(new Shipper()
                {
                    companyname = model.companyname,
                    phone = model.phone,
                    shipname = model.shipname,
                    shipaddress = model.shipaddress,
                    shipcity = model.shipcity,
                    shipregion = model.shipregion,
                    shippeddate = model.shippeddate,
                    shipcountry = model.shipcountry,
                    creation_user = (int)model.change_user,
                    creation_date = model.change_date
                });
                result.Message = "Remitente agregado correctamente.";
            }
            catch (ShipperDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el remitente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(ShipperUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.shipname))
            {
                result.Message = "El nombre del remitente es requerido.";
                result.Success = false;
                return result;
            }
            if (model.shipname.Length > 40)
            {
                result.Message = "El nombre del remitente tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            //if (!model.phone.HasValue)
            //{
            //    result.Message = "El telefono del remitente es requerido.";
            //    result.Success = false;
            //    return result;
            //}
            //if (!model.shipaddress.HasValue)
            //{
            //    result.Message = "Se requiere saber si el producto esta descontinuado.";
            //    result.Success = false;
            //    return result;
            //}
            //if (!model.shipperid.HasValue)
            //{
            //    result.Message = "Se requiere la id del remitente.";
            //    result.Success = false;
            //    return result;
            //}
            //if (!model.custid.HasValue)
            //{
                //result.Message = "Se requiere la id de la categoria del producto.";
                //result.Success = false;
                //return result;
            //}
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.shipperRepository.Update(new Shipper()
                {
                    shipperid = model.shipperid,
                    modify_user = model.change_user,
                    modify_date = DateTime.Now
                });
            }
            catch (ShipperDataException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando el remitente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Delete(ShipperRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.shipperRepository.Delete(new Shipper()
                {
                    shipperid = model.shipperid,
                    deleted = model.deleted,
                    delete_date = DateTime.Now,
                    delete_user = model.change_user.Value,
                });

                result.Message = "Remitente eliminado correctamente.";
            }
            catch (OrderDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el remitente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

    }
}
