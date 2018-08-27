using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHangdling.Models
{
    public class VinhPHAdvanceSizeEventArgs : EventArgs
    {
        public Size NewSize
        {
            get;
            set;
        }

        public Size OldSize
        {
            get;
            set;
        }

        public VinhPHAdvanceSizeEventArgs(Size oldSize, Size newSize)
        {
            OldSize = oldSize;
            NewSize = newSize;
        }
    }
}
