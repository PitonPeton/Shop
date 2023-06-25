using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace shop.Application.Core
{
    public abstract class BaseService<TModelAdd, TModelMod, TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetByInt(int id);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Delete(TModelRem model);
    }
}
