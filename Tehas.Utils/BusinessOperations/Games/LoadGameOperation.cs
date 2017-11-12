using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Games
{
    public class LoadGameOperation : BaseOperation
    {
        private Int32 _Id { get; set; }
        public Game _game { get; set; }

        public LoadGameOperation(int id)
        {            
            _Id = id;
            RussianName = "Получение игрового тарифа";
        }

        protected override void InTransaction()
        {
            _game = Context.Games.FirstOrDefault(x => x.Id == _Id && !x.Deleted);
            if (_game == null)
            {
                Errors.Add("Id", "Такого тарифа не существует");
            }
        }
    }
}