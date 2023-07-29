using shop.Application.Core;
using shop.Application.Dtos.Shipper;
using shop.Domain.Entities.Shippers;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Extentions
{
    public static class ShipperExtention
    {
        public static ServiceResult ValidUser(this ShipperRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.Change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static ServiceResult IsValidShipper(this ShipperDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.companyname))
            {
                result.Message = "El nombre de la compañia es requerido.";
                result.Success = false;
                return result;
            }
            if (model.companyname.Length > 40)
            {
                result.Message = "El nombre de la compañia tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                result.Message = "El telefono del expedido es requerido.";
                result.Success = false;
                return result;
            }
            if (model.phone.Length > 9)
            {
                result.Message = "El numero de telefono es muy largo";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.shipname))
            {
                result.Message = "El nombre del expedido es requerido.";
                result.Success = false;
                return result;
            }
            if (model.shipname.Length > 20)
            {
                result.Message = "El nombre del expedido tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.shipaddress))
            {
                result.Message = "Ingrese una direccion valida";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.shipcity))
            {
                result.Message = "Ingrese una ciudad valida";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.shipregion))
            {
                result.Message = "Ingrese una region valida";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.shipcountry))
            {
                result.Message = "Ingrese un pais valido";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static Shipper ConvertDtoAddToEntity(this ShipperAddDto shipperAddDto)
        {
            return new Shipper()
            {
                companyname = shipperAddDto.companyname,
                phone = shipperAddDto.phone,
                shipname = shipperAddDto.shipname,
                shipaddress = shipperAddDto.shipaddress,
                shipcity = shipperAddDto.shipcity,
                shipregion = shipperAddDto.shipregion,
                shippeddate = shipperAddDto.shippeddate,
                shipcountry = shipperAddDto.shipcountry,
                Creation_user = shipperAddDto.Change_user.Value,
                Creation_date = DateTime.Now
            };
        }
        public static Shipper ConvertDtoUpdateToEntity(this ShipperUpdateDto shipperUpdateDto)
        {
            return new Shipper()
            {
                companyname = shipperUpdateDto.companyname,
                phone = shipperUpdateDto.phone,
                shipname = shipperUpdateDto.shipname,
                shipaddress = shipperUpdateDto.shipaddress,
                shipcity = shipperUpdateDto.shipcity,
                shipregion = shipperUpdateDto.shipregion,
                shippeddate = shipperUpdateDto.shippeddate,
                shipcountry = shipperUpdateDto.shipcountry,
                Creation_user = shipperUpdateDto.Change_user.Value,
                Creation_date = DateTime.Now
            };
        }
    }
}
