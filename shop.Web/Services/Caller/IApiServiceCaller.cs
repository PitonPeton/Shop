using shop.Web.Models.Core;

namespace shop.Web.Services.Caller
{
    public interface IApiServiceCaller
    {
        ObjIn? Get<ObjIn>(string url, ObjIn objIn) where ObjIn : BaseResponseD;
        ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn objIn, ObjOut objOut) where ObjOut : BaseResponseD;
    }
}
