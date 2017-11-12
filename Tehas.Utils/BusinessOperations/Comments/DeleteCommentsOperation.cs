using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Klinik.Utils.DataBase.PagesDesc;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Comments
{
    public class DeleteCommentsOperation : BaseOperation
    {
        private int[] _ids { get; set; }        

        public DeleteCommentsOperation(int[] ids)
        {
            _ids = ids;
            RussianName = "Удаление коммента";
        }

        protected override void InTransaction()
        {
            foreach (var id in _ids)
            {
                var _product = Context.Comments.FirstOrDefault(x => x.Id == id && !x.Deleted);
                if (_product != null)
                {
                    _product.Deleted = true;
                    Context.SaveChanges();
                }
            }
        }
    }
}
