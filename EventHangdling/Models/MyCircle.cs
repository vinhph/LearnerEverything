using System;

namespace EventHangdling.Models
{
    public class MyCircle
    {
        //public event EventHandler<SizeEventArgs> SizeChanged;
        public event EventHandler SizeChanged;

        private Size _size;

        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (SizeChanged != null)
                {
                    //SizeChanged(this, new SizeEventArgs(value));
                    //SizeChanged(this, EventArgs.Empty);
                    SizeChanged(this, new VinhPHAdvanceSizeEventArgs(_size, value));
                }
                _size = value;
            }
        }

        public MyCircle()
        {
            _size = new Size(10, 10);
        }
    }
}
