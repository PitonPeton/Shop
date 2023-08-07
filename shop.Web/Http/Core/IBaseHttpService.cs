using shop.Web.Models.Core;

namespace shop.Web.Http.Core
{
    public interface IBaseHttpService<List, Details, TAdd, TUpdate>
    {
        public List Get();
        public Details GetById(int id);
        public BaseResponseD Add(TAdd add);
        public BaseResponseD Update(TUpdate update);
    }
}
