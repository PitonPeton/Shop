using shop.Web.Models;
using shop.Application.Dtos.Shipper;
using shop.Infraestructure.Models;
using shop.Web.Models.Request;

namespace shop.Web.Controllers.Extentions
{
    public static class ShipperExtentions
    {
        public static ShipperResponseModel ConvertGetByIdToShipperResponse(this ShipperModel shipper)
        {
            return new ShipperResponseModel()
            {
                shipperid = shipper.shipperid,
                companyname = shipper.companyname,
                phone = shipper.phone,
                shipname = shipper.shipname,
                shipaddress = shipper.shipaddress,
                shipcity = shipper.shipcity,
                shipregion = shipper.shipregion,
                shippostalcode = shipper.shippostalcode,
                shippeddate = shipper.shippeddate,
                shipcountry = shipper.shipcountry

            };
        }

        public static ShipperAddDto ConvertAddRequestToAddDto(this ShipperAddRequest shipperAdd)
        {
            return new ShipperAddDto()
            {
                companyname = shipperAdd.companyname,
                phone = shipperAdd.phone,
                shipname = shipperAdd.shipname,
                shipaddress = shipperAdd.shipaddress,
                shipcity = shipperAdd.shipcity,
                shipregion = shipperAdd.shipregion,
                shippostalcode = shipperAdd.shippostalcode,
                shippeddate = (DateTime)shipperAdd.shippeddate,
                shipcountry = shipperAdd.shipcountry,
                Change_user = shipperAdd.Change_user,
                Change_date = shipperAdd.Change_date
            };
        }

        public static ShipperUpdateRequest ConvertShipperToUpdateRequest(this ShipperModel shipper)
        {
            return new ShipperUpdateRequest()
            {
                shipperid = shipper.shipperid,
                companyname = shipper.companyname,
                phone = shipper.phone,
                shipname = shipper.shipname,
                shipaddress = shipper.shipaddress,
                shipcity = shipper.shipcity,
                shipregion = shipper.shipregion,
                shippostalcode = shipper.shippostalcode,
                shippeddate = shipper.shippeddate,
                shipcountry = shipper.shipcountry

            };
        }

        public static ShipperUpdateDto ConvertirUpdateRequestToUpdateDto(this ShipperUpdateRequest shipperUpdate)
        {
            return new ShipperUpdateDto()
            {
                shipperid = shipperUpdate.shipperid,
                companyname = shipperUpdate.companyname,
                phone = shipperUpdate.phone,
                shipname = shipperUpdate.shipname,
                shipaddress = shipperUpdate.shipaddress,
                shipcity = shipperUpdate.shipcity,
                shipregion = shipperUpdate.shipregion,
                shippostalcode = shipperUpdate.shippostalcode,
                shippeddate = (DateTime)shipperUpdate.shippeddate,
                shipcountry = shipperUpdate.shipcountry,
                Change_user = shipperUpdate.Change_user,
                Change_date = shipperUpdate.Change_date
            };
        }
    }
}
