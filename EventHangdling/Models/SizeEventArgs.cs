using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHangdling.Models
{
    public class SizeEventArgs : EventArgs
    {
        public Size NewSize
        {
            get;
            set;
        }

        public SizeEventArgs(Size newSize)
        {
            NewSize = newSize;
        }
    }
}
