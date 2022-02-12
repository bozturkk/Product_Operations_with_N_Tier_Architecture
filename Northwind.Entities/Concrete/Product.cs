using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
    public class Product:IEntity //bu nesne veritabanı nesnesi ise IEntity den implemente edilsin. 
    {
        public int ProductId { get; set; }
        //[Required] burada da doğrulama işlemi yapılabilir. Fakat bu nesnenin kullanıldığı her yerde doğrulama yapılır.
        //SOLID prensiplerine aykırıdır.
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public String QuantityPerUnit { get; set; }
        public Int16 UnitsInStock { get; set; }
    }
}
