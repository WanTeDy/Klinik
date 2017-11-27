using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Utils.BusinessOperations.Doctors
{
    public class LoadAllDoctorsOperation : BaseOperation
    {
        public List<Doctor> _doctors { get; set; }

        public LoadAllDoctorsOperation()
        {
            RussianName = "Получение списка всех продуктов категории";
        }

        protected override void InTransaction()
        {
            _doctors = Context.Doctors.Where(x => !x.Deleted).OrderBy(x => x.OrderNum).ToList();
        }
    }
}