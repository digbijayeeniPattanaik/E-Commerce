namespace Core.Entites.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered(int productItemId, int productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        public int ProductItemId { get; set; }
        public int ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}
