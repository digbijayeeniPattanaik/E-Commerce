using Core.Entites;

namespace Core.Specifications
{
    public class ProductWithFilterForCountSpecifications : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecifications(ProductSpecParams productSpec) : base(a =>
        (string.IsNullOrWhiteSpace(productSpec.Search) || a.Name.ToLower().Contains(productSpec.Search)) &&
        (!productSpec.BrandId.HasValue || a.ProductBrandId == productSpec.BrandId) &&
        (!productSpec.TypeId.HasValue || a.ProductTypeId == productSpec.TypeId))
        {
        }
    }
}
