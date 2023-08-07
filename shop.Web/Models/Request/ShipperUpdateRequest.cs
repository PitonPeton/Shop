namespace shop.Web.Models.Request
{
    public class ShipperUpdateRequest : ShipperRequest
    {
#pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        public int shipperid { get; set; } 
#pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
    }
}
