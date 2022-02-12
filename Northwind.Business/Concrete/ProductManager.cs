using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//burada iş kuralları yazılır.
// mesela birimi Ürün listesini görmeye uygun mu?
//Ör: Bir bankacılık uygulamasında, bir kredi datasını görmek için kıstaslar,
//mevzuata uygunlukla ilgili kodlar yazılabilir.

namespace Northwind.Business.Concrete
{
    //C reate = İnsert işlemleri,
    //R ead = Select işlemleri,
    //U pdate = Update işlemleri,
    //D Delete = Delete işlemleri,
    public class ProductManager : IProductService
    {
        private IProductDal _productDal; // IProductDal'dan implemente edilmiş iki ayrı ORM mevcut.

        public ProductManager(IProductDal productDal) // bu sayede product manager newlendiğinde bana bir IproductDal türünde nesne olarak istediğim dal sınıfını verebilirim.
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch (DbUpdateException)
            {

                throw new Exception("Silme işlemi gerçekleşemedi.");
            }
           
        }

        public List<Product> GetAll()
        {
           
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string ProductName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(ProductName.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
