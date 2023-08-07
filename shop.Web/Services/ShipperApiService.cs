using shop.Web.Controllers.Extentions;
using shop.Application.Dtos.Shipper;
using shop.Web.Models.Core;
using shop.Web.Services.Caller;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public class ShipperApiService : IShipperApiService
    {
        private readonly IApiServiceCaller apicaller;
        private readonly ILogger<ShipperApiService> logger;
        private string baseUrl = "http://localhost:5016/api/Shipper/";


        public ShipperApiService(IApiServiceCaller apicaller, ILogger<ShipperApiService> logger)
        {
            this.apicaller = apicaller;
            this.logger = logger;
        }

        public ShipperListResponse Get()
        {
            ShipperListResponse? shippersList = new ShipperListResponse();
            string url = $" {baseUrl}GetShippers";

            try
            {
                shippersList = apicaller.Get(url, shippersList);

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
        public ShipperDetailResponse GetById(int id)
        {
            ShipperDetailResponse? shipper = new ShipperDetailResponse();
            string url = $" {baseUrl}/{id}";

            try
            {
                shipper = apicaller.Get(url, shipper);

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
                result = apicaller.Set(url, shipperAdd, result);
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

            ShipperUpdateDto shipperUpdateUpdate = update.ConvertirUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Modificar";

            try
            {
                result = apicaller.Set(url, shipperUpdateUpdate, result);
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
