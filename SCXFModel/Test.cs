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
    public partial class Test : Form
    {
        Building building = new Building();
        Employee employee = new Employee();
        FireMan fireMan = new FireMan();
       
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            building.fire += new FireAlarmDelegate(employee.RunAway);
            building.fire += new FireAlarmDelegate(fireMan.FireAawy);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            building.OnFire();
        }
    }


    public delegate void FireAlarmDelegate();
    public class Building
    {
      public  event FireAlarmDelegate fire;

        public void OnFire()
        {
            this.fire();
        }
    }


    public class Employee
    {
        public void RunAway()
        {
            Console.WriteLine("go away！");
        }
    }


    public class FireMan
    {
        public void FireAawy()
        {
            Console.WriteLine("Fire Away!");
        }
    }
}
