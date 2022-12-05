using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCenter.ViewModels
{
    class AdminViewModel : ViewModelBase
    {
        public Worker Worker { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public AdminViewModel()
        {
            Worker = AuthorizationViewModel.Worker;
            Title = "Администратор";
            GetName();
            GetLastName();
        }

        private string GetName()
        {
            FirstName = Worker.FirstName;
            return FirstName;
        }

        private string GetLastName()
        {
            LastName = Worker.LastName;
            return LastName;
        }
    }
}
