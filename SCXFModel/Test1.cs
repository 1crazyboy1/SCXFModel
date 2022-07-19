using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCXFModel
{
    public partial class Test1 : Form
    {
        Building building = new Building();
        Employes employes = new Employes();
        FireMan fireMan = new FireMan();
        public Test1()
        {
            InitializeComponent();
        }



       public class EventArgs
       {
            public string flower { get; set; }
            public string fireLevel{ get; set; }
       }
        public delegate void EvenEventArgs(object sender,EventArgs e);
        public class Building
        {
            public event EvenEventArgs even;
            public void onfire(string flower, string fireLevel )
            {
                EventArgs e = new EventArgs();
                e.flower = flower;
                e.fireLevel = fireLevel;
                this.even(this,e);
            }

            public string buildingname;
        }

        public class FireMan
        {
            public void Onfireaway(object sender, EventArgs e)
            {
                Console.WriteLine("fire away!");
            }
        }

        public class Employes
        {
            public string buildname { get; set;}

            public string flower { get; set;}

            public void RanAway(object sender,EventArgs e)
            {
                Building building = (Building)sender;
                if (building.buildingname==this.buildname&&(e.flower=="A"||e.flower==this.flower))
                {
                    Console.WriteLine("employs come go!");
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            building.onfire("1","1");
        }

        private void Test1_Load(object sender, System.EventArgs e)
        {
            building.buildingname="1";
            
            employes.buildname = "1";
            employes.flower = "1";

            building.even += new EvenEventArgs(employes.RanAway);
            building.even += new EvenEventArgs(fireMan.Onfireaway);
        }
    }
}
