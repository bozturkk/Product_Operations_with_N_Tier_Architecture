using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

// !!DataAccess katmanında sadece veritabanı(DML) işlemleri yapılır. Bunlar:
//SELECT,INSERT,UPDATE,DELETE
namespace Northwind.DataAccess.Concrete.EntityFramework
{

    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
       
    }
}
