using shop.Web.Models.Core;

namespace shop.Web.Http
{
    public interface IHttpCaller
    {
        Response? Get<Response>(string url, Response response) where Response : BaseResponseD;
        Response? Set<Request, Response>(string url, Request request, Response response) where Response: BaseResponseD;
    }
}
