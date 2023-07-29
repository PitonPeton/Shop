using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using shop.Application.Contract;
using shop.Application.Core;
using shop.Application.Dtos.Shipper;
using shop.Domain.Entities.Shippers;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Infraestructure.Repositories;
using shop.Application.Extentions;

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
                result.Message = "Error obteniendo los expedidos";
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
            catch (ShipperDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el expedido";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(ShipperAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidShipper();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var shipper = model.ConvertDtoAddToEntity();

                this.shipperRepository.Add(shipper);

                result.Message = "Orden agregada correctamente.";
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
                result.Message = "Error guardando el expedido.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(ShipperUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidShipper();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var order = model.ConvertDtoUpdateToEntity();

                this.shipperRepository.Update(order);

                result.Message = "El expedido se ha modificado correctamente.";
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
                result.Message = "Error modificando el expedido.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Delete(ShipperRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidUser();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                this.shipperRepository.Delete(new Shipper()
                {
                    shipperid = model.shipperid,
                    Deleted = model.Deleted,
                    Delete_date = DateTime.Now,
                    Delete_user = model.Change_user.Value,
                });

                result.Message = "Expedido eliminado correctamente.";
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
                result.Message = "Error eliminando el expedido.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

    }
}
