using System;

namespace shop.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime change_date { get; set; }
        public int change_user { get; set; }
    }
}
