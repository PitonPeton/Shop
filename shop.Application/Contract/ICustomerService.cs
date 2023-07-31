
using shop.Application.Core;
using shop.Application.Dtos.Customer;

namespace shop.Application.Contract
{
    public interface ICustomerService : IBaseService<CustomerAddDto,
                                                    CustomerUpdateDto,
                                                    CustomerDeleteDto>
    {
    }
}
