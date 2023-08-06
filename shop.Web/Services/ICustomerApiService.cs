using shop.Application.Dtos.Customer;
using shop.Infraestructure.Models;
using shop.Web.Models.Reponses;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public interface ICustomerApiService
    {
        CustomerDetailResponse GetCustomer(int id);
        CustomerListResponse GetCustomers();
        CustomerUpdateResponse Update(CustomerUpdateDto customerUpdateDto);
        CustomerSaveReponse Save(CustomerAddDto customerAddDto);

    }
}
