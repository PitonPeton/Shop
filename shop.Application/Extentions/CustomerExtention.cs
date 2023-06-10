
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
using shop.Application.Core;
>>>>>>> Actualizacion
=======
>>>>>>> Actualizacion
=======
>>>>>>> Actualizacion
using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;
using System;

namespace shop.Application.Extentions
{
    public static class CustomerExtention
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        public static ServiceResult ValidUser(this CustomerDeleteDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult IsValidCustomer(this CustomerDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.contactname))
            {
                result.Message = "El nombre del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (model.contactname.Length > 40)
            {
                result.Message = "El nombre del cliente tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.companyname))
            {
                result.Message = "El nombre de la compañia es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.contacttitle))
            {
                result.Message = "El titulo del contacto es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.address))
            {
                result.Message = "La direccion del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                result.Message = "El email del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.city))
            {
                result.Message = "La ciudad del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.country))
            {
                result.Message = "El pais del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                result.Message = "El telefono del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.fax))
            {
                result.Message = "El fax del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }

>>>>>>> Actualizacion
=======
>>>>>>> Actualizacion
=======
>>>>>>> Actualizacion
        public static Customer ConvertDtoAddToEntity(this CustomerAddDto customerAddDto)
        {
            return new Customer()
            {
                companyname = customerAddDto.companyname,
                contactname = customerAddDto.contactname,
                contacttitle = customerAddDto.contacttitle,
                address = customerAddDto.address,
                email = customerAddDto.email,
                city = customerAddDto.city,
                region = customerAddDto.region,
                postalcode = customerAddDto.postalcode,
                country = customerAddDto.country,
                phone = customerAddDto.phone,
                fax = customerAddDto.fax,
                creation_date = DateTime.Now,
                creation_user = customerAddDto.change_user.Value
            };
        }
        public static Customer ConvertDtoUpdateToEntity(this CustomerUpdateDto customerUpdateDto)
        {
            return new Customer()
            {
                custid = customerUpdateDto.custid,
                companyname = customerUpdateDto.companyname,
                contactname = customerUpdateDto.contactname,
                contacttitle = customerUpdateDto.contacttitle,
                address = customerUpdateDto.address,
                email = customerUpdateDto.email,
                city = customerUpdateDto.city,
                region = customerUpdateDto.region,
                postalcode = customerUpdateDto.postalcode,
                country = customerUpdateDto.country,
                phone = customerUpdateDto.phone,
                fax = customerUpdateDto.fax,
                modify_date = DateTime.Now,
                modify_user = customerUpdateDto.change_user.Value
            };
        }
    }
}
