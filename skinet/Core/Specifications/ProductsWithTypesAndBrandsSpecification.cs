using Core.Entites;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpec)
            : base(a => 
            (string.IsNullOrWhiteSpace(productSpec.Search) || a.Name.ToLower().Contains(productSpec.Search)) &&
            (!productSpec.BrandId.HasValue || a.ProductBrandId == productSpec.BrandId) &&
            (!productSpec.TypeId.HasValue || a.ProductTypeId == productSpec.TypeId))
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
            AddOrderBy(a => a.Name);
            ApplyingPaging(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(a => a.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(a => a.Price);
                        break;
                    default:
                        AddOrderBy(a => a.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
    }
}
