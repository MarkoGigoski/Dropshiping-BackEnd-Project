namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
