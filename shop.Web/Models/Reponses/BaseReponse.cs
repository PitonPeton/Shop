namespace shop.Web.Models.Reponses
{
    public class BaseReponse<TModel> where TModel : class
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public List<TModel> data { get; set; }
    }
}
