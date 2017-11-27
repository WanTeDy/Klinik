using System.IO;
using System.Linq;
using System.Web;

namespace Klinik.Utils.BusinessOperations.Doctors
{
    public class DeleteDoctorsOperation : BaseOperation
    {
        private int[] _ids { get; set; }        

        public DeleteDoctorsOperation(int[] ids)
        {
            _ids = ids;
            RussianName = "Удаление продукта";
        }

        protected override void InTransaction()
        {
            foreach (var id in _ids)
            {
                var _doctor = Context.Doctors.FirstOrDefault(x => x.Id == id && !x.Deleted);
                if (_doctor != null)
                {
                    if (_doctor.Image != null)
                    {
                        var path = HttpContext.Current.Server.MapPath(_doctor.Image.Url);
                        FileInfo fileInf = new FileInfo(path + _doctor.Image.FileName);
                        if (fileInf.Exists)
                        {
                            fileInf.Delete();
                        }
                        Context.Images.Remove(_doctor.Image);
                    }
                    Context.Doctors.Remove(_doctor);
                    Context.SaveChanges();
                }
            }
        }
    }
}
