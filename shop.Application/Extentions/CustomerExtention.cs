
using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;
using System;

namespace shop.Application.Extentions
{
    public static class CustomerExtention
    {
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
