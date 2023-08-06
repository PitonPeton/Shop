using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;
using shop.Web.Models.Reponses;
using shop.Web.Models.Responses;

namespace shop.Web.Models.Extention
{
    public static class CustomerExtention
    {
        public static CustomerAddDto ConvertSaveRequestToDto(this CustomerSaveReponse customerSave)
        {
            return new CustomerAddDto()
            {
                custid = customerSave.custid,
                companyname = customerSave.companyname,
                contactname = customerSave.contactname,
                contacttitle = customerSave.contacttitle,
                address = customerSave.address,
                email = customerSave.email,
                city = customerSave.city,
                region = customerSave.region,
                postalcode = customerSave.postalcode,
                country = customerSave.country,
                phone = customerSave.phone,
                fax = customerSave.fax,

            };
        }
    }
}
