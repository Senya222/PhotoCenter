using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCenter.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public Worker ActiveWorker { get; set; }

        public string FullName { get; set; }
        public List<int> CountOrder { get; set; }
        public List<string> NameWorker { get; set; }
        public ReportViewModel()
        {
            Title = "Отчетность о заказах";
            List<Worker> workers;
            workers = DBContext.GetContext().Worker.ToList();
            NameWorker = workers.Select(p => p.LastName + " " + p.FirstName + " " + p.MiddleName).ToList();
            CountOrder = new List<int>();
            workers.ForEach(p =>
            {
                CountOrder.Add(DBContext.GetContext().Order.Where(n => n.WorkerID == p.WorkerID).Count());
            });

            ActiveWorker = workers.FirstOrDefault(p => p.Order.Count() == CountOrder.Max());
            FullName = ActiveWorker.LastName + " " + ActiveWorker.FirstName + " " + ActiveWorker.MiddleName;
        }
    }
}
