namespace EFProject.Models
{
	public interface IProductRepository
	{
		Product GetById(int ProductId);
		List<Product> Products{ get; }
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int productId);
	}
	public class ProductRepository : IProductRepository //implement 
	{
		private ProductContext _db;
        public ProductRepository(ProductContext db)
        {
			_db = db;
        }
        public List<Product> Products
		{
			get { return _db.Products.ToList(); }
		}
		public void CreateProduct(Product product)
		{
			_db.Products.Add(product);
			_db.SaveChanges();
		}

		public void DeleteProduct(int productId)
		{
			var product = GetById(productId);
			if (product != null) 
			{ 
				_db.Products.Remove(product);
				_db.SaveChanges();
			}
		}

		public Product GetById(int productId)
		{
			return _db.Products.FirstOrDefault(x => x.ProductId == productId);
		}

		public void UpdateProduct(Product product)
		{
			_db.Products.Update(product);
			_db.SaveChanges();
		}
	}
}
