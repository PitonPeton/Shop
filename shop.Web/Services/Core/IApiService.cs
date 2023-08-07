using shop.Web.Models.Core;

namespace shop.Web.Services.Core
{
    public interface IApiService<List, Details, TAdd, TUpdate>
    {
        public List Get();
        public Details GetById(int id);
        public BaseResponseD Add(TAdd add);
        public BaseResponseD Update(TUpdate update);
    }
}
