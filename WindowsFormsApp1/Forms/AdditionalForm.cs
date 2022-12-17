using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdditionalForm : Form
    {
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public AdditionalForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];
            form1.Hide();
            RoomForm roomForm = new RoomForm();

            roomForm.RecStudios = RecStudios;
            roomForm.Workers = Workers;
            roomForm.Instruments = Instruments;
            roomForm.Rooms = Rooms;

            roomForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];
            form1.Hide();
            WorkerForm workerForm = new WorkerForm();

            workerForm.RecStudios = RecStudios;
            workerForm.Workers = Workers;
            workerForm.Instruments = Instruments;
            workerForm.Rooms = Rooms;

            workerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];
            form1.Hide();
            InstForm instForm = new InstForm();

            instForm.RecStudios = RecStudios;
            instForm.Workers = Workers;
            instForm.Instruments = Instruments;
            instForm.Rooms = Rooms;

            instForm.Show();
        }
    }
}
