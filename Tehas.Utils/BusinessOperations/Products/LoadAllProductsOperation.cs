using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Products
{
    public class LoadAllProductsOperation : BaseOperation
    {
        public List<Product> _products { get; set; }

        public LoadAllProductsOperation()
        {
            RussianName = "Получение списка всех продуктов категории";
        }

        protected override void InTransaction()
        {
            _products = Context.Products.Where(x => !x.Deleted).OrderBy(x => x.Id).ToList();
        }
    }
}