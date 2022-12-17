using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class RoomForm : Form
    {
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public RoomForm()
        {
            InitializeComponent();
        }

        int sumCost, averageCost;
        double timeJob;
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];

            foreach (var item in Rooms)
            {
                sumCost += Convert.ToInt32(item.RecCost);
                averageCost = (sumCost / Rooms.Count);
                timeJob = (Rooms.Count / Workers.Count) * 3.2;
            }

            foreach (var item in RecStudios)
            {
                item.NumberOfRooms = listView1.Items.Count;
                item.TrackCreationCost = averageCost;
                item.TrackCreationTime = timeJob;
            }

            form1.RecStudios = RecStudios;
            form1.Workers = Workers;
            form1.Instruments = Instruments;
            form1.Rooms = Rooms;

            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            AddRoomForm addRoomForm = new AddRoomForm();

            addRoomForm.RecStudios = RecStudios;
            addRoomForm.Workers = Workers;
            addRoomForm.Instruments = Instruments;
            addRoomForm.Rooms = Rooms;

            addRoomForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            foreach (var room in Rooms)
            {
                listView1.Items.Add("Коштує\n" + room.RecCost.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            EditRoomForm editRoomForm = new EditRoomForm();

            editRoomForm.RecStudios = RecStudios;
            editRoomForm.Workers = Workers;
            editRoomForm.Instruments = Instruments;
            editRoomForm.Rooms = Rooms;

            editRoomForm.Show();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            listView1.Clear();

            foreach (var room in Rooms)
            {
                listView1.Items.Add("Коштує\n" + room.RecCost.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var room in Rooms)
            {
                if (listView1.SelectedItems.Equals(room))
                {
                    Rooms.Remove(room);
                    listView1.SelectedItems.Clear();
                }
            }
        }
    }
}
