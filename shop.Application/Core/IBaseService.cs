
namespace shop.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Update(TDtoMod model);
        ServiceResult Save(TDtoAdd model);
        ServiceResult Delete(TDtoRem model);
    }
}
