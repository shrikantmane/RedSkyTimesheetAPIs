using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.ViewModel.GenericViewModel
{
    class GenericViewModel
    {
    }

    public class BaseIDViewModel
    {
        public int ID { get; set; }
    }

    public class UserViewModel : BaseIDViewModel
    {
        public string Name { get; set; }
    }

    public class LookupViewModel : BaseIDViewModel
    {
        public string Value { get; set; }
    }

    //public class DateViewModel
    //{
    //    public DateTime? Date { get; set; }
    //}
}
