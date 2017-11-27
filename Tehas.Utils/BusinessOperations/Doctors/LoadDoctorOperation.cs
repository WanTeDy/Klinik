using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Utils.BusinessOperations.Doctors
{
    public class LoadDoctorOperation : BaseOperation
    {
        private Int32 _Id { get; set; }
        public Doctor _doctor { get; set; }

        public LoadDoctorOperation(int id)
        {            
            _Id = id;
            RussianName = "Получение продукта";
        }

        protected override void InTransaction()
        {
            _doctor = Context.Doctors.FirstOrDefault(x => x.Id == _Id && !x.Deleted);            
        }
    }
}