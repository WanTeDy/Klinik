using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Comments
{
    public class AddCommentOperation : BaseOperation
    {
        private Comment _model { get; set; }

        public AddCommentOperation(Comment model)
        {
            _model = model;
            RussianName = "Добавление комментария пользователей";
        }

        protected override void InTransaction()
        {
            _model.Date = DateTime.Now;
            Context.Comments.Add(_model);
            Context.SaveChanges();
        }
    }
}