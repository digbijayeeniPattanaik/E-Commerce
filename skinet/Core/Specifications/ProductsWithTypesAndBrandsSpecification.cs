using Core.Entites;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
    }
}
