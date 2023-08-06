namespace shop.Web.Models.Reponses
{
    public class BaseReponse
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public DateTime change_date { get; set; }
        public int? change_user { get; set; }

    }
}
