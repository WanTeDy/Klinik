using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Products
{
    public class LoadCategoriesOperation : BaseOperation
    {        
        public List<Category> _categories { get; set; }

        public LoadCategoriesOperation()
        {            
            RussianName = "Получение списка категорий";
        }

        protected override void InTransaction()
        {
            _categories = Context.Categories.Where(x => !x.Deleted).ToList();
        }
    }
}