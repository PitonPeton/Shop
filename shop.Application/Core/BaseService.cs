
namespace shop.Application.Core
{
    public abstract class BaseService<TModelAdd, TModelMod, TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Delete(TModelRem model);

    }
}
