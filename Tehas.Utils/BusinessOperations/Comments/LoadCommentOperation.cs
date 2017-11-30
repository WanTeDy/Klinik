using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Emails;

namespace Klinik.Utils.BusinessOperations.Comments
{
    public class LoadCommentOperation : BaseOperation
    {
        private Int32 _Id { get; set; }
        public Comment _comment { get; set; }

        public LoadCommentOperation(int id)
        {            
            _Id = id;
            RussianName = "Получение продукта";
        }

        protected override void InTransaction()
        {
            _comment = Context.Comments.FirstOrDefault(x => x.Id == _Id && !x.Deleted);            
        }
    }
}