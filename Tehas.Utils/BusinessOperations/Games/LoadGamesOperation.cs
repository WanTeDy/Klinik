using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Games
{
    public class LoadGamesOperation : BaseOperation
    {
        public List<Game> _games { get; set; }

        public LoadGamesOperation()
        {
            RussianName = "Получение списка всех игровых тарифов";
        }

        protected override void InTransaction()
        {
            _games = Context.Games.Where(x => !x.Deleted && x.ParrentId != null).OrderBy(x => x.Id).ToList();
        }
    }
}