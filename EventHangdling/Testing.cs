using EventHangdling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHangdling
{
    public class Testing
    {
        public void Run()
        {
            MyCircle mycircle = new MyCircle();

            mycircle.SizeChanged += new EventHandler(Circle_SizeChanged);

            var newSize = new Size(11, 11);
            mycircle.Size = newSize;
            var new2Size = new Size(12, 12);
            mycircle.Size = new2Size;
        }

        void Circle_SizeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(((SizeEventArgs)e).NewSize.ToString());

            //Console.WriteLine("sender: " + sender + " event: " + e.ToString() + " | changed (from console)");
            //Console.WriteLine("Height now is: " + ((MyCircle)sender).Size.Height);

            Console.WriteLine("Old Heigth: " + ((VinhPHAdvanceSizeEventArgs)e).OldSize.Height.ToString() + " | New Heigth: " + ((VinhPHAdvanceSizeEventArgs)e).NewSize.Height.ToString());            
        }
    }
}
