using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityTester
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();
            
            man.GetActivity().ForEach(s => signupList.Items.Add(s));
            signupList.DisplayMember = "name";
            signupList.ValueMember = "Id";

            signLifeTimeEnd.CustomFormat = " ";
        }

        private void signupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            slotList.Items.Clear();
            //MP.Activity.SignUp sign = signupList.SelectedItem as MP.Activity.SignUp;
            //if (sign != null)
            //{
            //    sign.Slots.ToList().ForEach(s => slotList.Items.Add(s));
            //    slotList.DisplayMember = "start";
            //    slotList.ValueMember = "Id";
            //}
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();
            MP.Activity.Activity sign = man.GetActivity(((MP.Activity.Activity)signupList.Items[signupList.SelectedIndex]).Id).FirstOrDefault();
            //signupList.SelectedItem as MP.Activity.SignUp;
            if (sign != null)
            {
                sign.Period1.ToList().ForEach(s => slotList.Items.Add(s));
                slotList.DisplayMember = "start";
                slotList.ValueMember = "Id";
            }

            _activity = sign;




            signId.Text = _activity.Id.ToString();
            signName.Text = _activity.name;
            signDescription.Text = _activity.description;
            signLifeTimeStart.Value = _activity.Period.start;
            //signLifeTimeEnd.Value = _activity.Period.end = null ?? (DateTime)_activity.Period.end;

            dataGridView1.Rows.Clear();

            foreach (MP.Activity.Period p in _activity.Period1)
            {
                int rowIndex = this.dataGridView1.Rows.Add();

                //Obtain a reference to the newly created DataGridViewRow 
                var row = this.dataGridView1.Rows[rowIndex];

                //Now this won't fail since the row and columns exist 
                row.Cells["start"].Value = p.start;
                if (p.end != null)
                {
                    row.Cells["end"].Value = ((DateTime)p.end);
                }


            }


        }

        private void signLifeTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            signLifeTimeEnd.Format = signLifeTimeStart.Format;
            
        }

        MP.Activity.Activity _activity = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (_activity == null)
            {
                _activity = new MP.Activity.Activity();
            }
            
            _activity.name = signName.Text;
            _activity.description = signDescription.Text;
            _activity.Period = new MP.Activity.Period() { start = signLifeTimeStart.Value, end = signLifeTimeEnd.Value };

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++){
                DataGridViewRow item = dataGridView1.Rows[i];
                DateTime start = DateTime.Parse(item.Cells["start"].Value.ToString());
                DateTime end = DateTime.Parse(item.Cells["end"].Value.ToString());
                _activity.Period1.Add(new MP.Activity.Period() { start = start, end = end });
            }
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    DateTime start = DateTime.Parse(item.Cells["start"].Value.ToString());
            //    DateTime end = DateTime.Parse(item.Cells["end"].Value.ToString());
            //    sign.Slots.Add(new MP.Activity.Period() { start = start, end = end });
            //}

            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();
            man.SaveActivity(_activity);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
