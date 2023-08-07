using shop.Web.Models.Responses;
using shop.Web.Models.Core;
using shop.Application.Dtos.Shipper;
using shop.Web.Controllers.Extentions;
using shop.Web.Models.Request;


namespace shop.Web.Http.HttpServices
{
    public class ExpedidoHttpService
    {
            private readonly IHttpCaller httpCaller;
            private readonly ILogger<ExpedidoHttpService> logger;
            private string baseUrl = string.Empty;

            public ExpedidoHttpService(IHttpCaller apiCaller,
                                    IConfiguration configuration,
                                    ILogger<ExpedidoHttpService> logger)
            {
                this.httpCaller = apiCaller;
                this.logger = logger;
                this.baseUrl = configuration["ApiConfig:baseUrl"] + "Shipper/";
            }

            public ShipperListResponse Get()
            {
                ShipperListResponse? shippersList = new ShipperListResponse();
                string url = $" {baseUrl}GetShippers";

                try
                {
                    shippersList = httpCaller.Get(url, shippersList);

                    if (shippersList == null)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    shippersList = new ShipperListResponse();
                    shippersList.success = false;
                    shippersList.message = $"Error al solicitar al llamar Api, url:{url}";
                    logger.LogError(shippersList.message, ex.ToString());
                }

                return shippersList;
            }

            public ShipperDetailResponse GetById(int Id)
            {
                ShipperDetailResponse? shipper = new ShipperDetailResponse();
                string url = $" {baseUrl}GetShippers?id={Id}";

                try
                {
                    shipper = httpCaller.Get(url, shipper);

                    if (shipper == null)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    shipper = new ShipperDetailResponse();
                    shipper.success = false;
                    shipper.message = $"Error al solicitar al llamar Api, url:{url}";
                    logger.LogError(shipper.message, ex.ToString());
                }

                return shipper;
            }

            public BaseResponseD Add(ShipperAddRequest add)
            {
                BaseResponseD? result = new BaseResponseD();

                ShipperAddDto shipperAdd = add.ConvertAddRequestToAddDto();

                string url = $" {baseUrl}Guardar";

                try
                {
                    result = httpCaller.Set(url, shipperAdd, result);
                    if (result == null)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    result = new BaseResponseD();
                    result.success = false;
                    result.message = $"Error al solicitar al llamar Api, url:{url}";
                    logger.LogError(result.message, ex.ToString());
                }

                return result;
            }

            public BaseResponseD Update(ShipperUpdateRequest update)
            {
                BaseResponseD? result = new BaseResponseD();

                ShipperUpdateDto shipperUpdate = update.ConvertirUpdateRequestToUpdateDto();
                string url = $" {baseUrl}Modificar";

                try
                {
                    result = httpCaller.Set(url, shipperUpdate, result);
                    if (result == null)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    result = new BaseResponseD();
                    result.success = false;
                    result.message = $"Error al solicitar al llamar Api, url:{url}";
                    logger.LogError(result.message, ex.ToString());
                }

                return result;
            }
    }
}
