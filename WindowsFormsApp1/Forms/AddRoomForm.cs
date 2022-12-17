using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class AddRoomForm : Form
    {
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<Guid> tempInstGuids = new List<Guid>();

            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                tempInstGuids.Add(Guid.Parse(checkedListBox2.CheckedItems[i].ToString()));
            }

            var instGuids = tempInstGuids.ToArray();

            List<string> tempWorkerIds = new List<string>();

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                tempWorkerIds.Add(checkedListBox1.CheckedItems[i].ToString());
            }

            var workerIds = tempWorkerIds.ToArray();

            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null || 
                textBox6.Text == null || checkedListBox1.CheckedItems.Count <= 0 || checkedListBox2.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Не введено усі дані!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Rooms.Add(Room.CreateRoom(Convert.ToInt32(textBox1.Text),
                    instGuids, workerIds, 
                    Convert.ToInt32(textBox2.Text), 
                    Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text), 
                    Convert.ToInt32(checkedListBox2.CheckedItems.Count), Convert.ToInt32(checkedListBox1.CheckedItems.Count)));
            }

            StringBuilder roomsInfo = new StringBuilder();

            StringBuilder roomsInfoTemp = new StringBuilder();

            foreach (var item in Rooms)
            {
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.Id.ToString());
                for (int i = 0; i < item.InstIds.Length; i++)
                {
                    roomsInfoTemp = roomsInfoTemp.AppendLine(item.InstIds[i].ToString());
                }
                for (int i = 0; i < item.WorkNum.Length; i++)
                {
                    roomsInfoTemp = roomsInfoTemp.AppendLine(item.WorkNum[i].ToString());
                }
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.MinInst.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.MaxInst.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.MinWorkers.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.MaxWorkers.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.RecCost.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.InstCount.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine(item.WorkersCount.ToString());
                roomsInfoTemp = roomsInfoTemp.AppendLine("----------------------------");
            }

            roomsInfo.Append(roomsInfoTemp);

            roomsInfoTemp.Clear();

            // збережемо студію у файл
            File.WriteAllText(@"..\..\Studio\Кімнати.txt", roomsInfo.ToString());
            MessageBox.Show("Файл збережено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            RoomForm roomForm = new RoomForm();

            roomForm.RecStudios = RecStudios;
            roomForm.Workers = Workers;
            roomForm.Instruments = Instruments;
            roomForm.Rooms = Rooms;

            roomForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();

            foreach (var item in Instruments)
            {
                checkedListBox2.Items.Add(item.Id);
            }

            foreach (var item in Workers)
            {
                checkedListBox1.Items.Add(item.Value.Id);
            }
        }
    }
}
