using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowVM
    {
        public ListСontactsVM ListСontacts { get; set; }

        public MainWindowVM()
        {
            ListСontacts = new ListСontactsVM();
        }
    }
}
