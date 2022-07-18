using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCXFModel
{

    public class IsEvenEventArgs : EventArgs
    {
        public int Random = 0;
        public IsEvenEventArgs(int inputRandom)
        {
            Random = inputRandom;
        }
    }
    public delegate void IsEvenEvent(object sender,IsEvenEventArgs e);
    public class MYRandom
    {
        public event IsEvenEvent IsEven;

        public void run_Random()
        {
            Random rd = new Random();
           int rad=  rd.Next(0,10000);
            if (rad % 2==0)
            {
                IsEven(this, new IsEvenEventArgs(rad));
            }
        }
       
    }
}
