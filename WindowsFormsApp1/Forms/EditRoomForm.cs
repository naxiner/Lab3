using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class EditRoomForm : Form
    {
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public EditRoomForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            RoomForm roomForm = new RoomForm();

            roomForm.RecStudios = RecStudios;
            roomForm.Workers = Workers;
            roomForm.Instruments = Instruments;
            roomForm.Rooms = Rooms;

            roomForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: // id
                    int idIndex = listBox1.SelectedIndex;
                    foreach (var item in Rooms)
                    {
                        if ("Номер кімнати: " + item.Id.ToString() == listBox1.SelectedItem.ToString())
                            item.Id = Convert.ToInt32(textBox1.Text);
                    }
                    listBox1.Items.RemoveAt(idIndex);
                    listBox1.Items.Insert(idIndex, textBox1.Text);
                    break;

                default: break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var room in Rooms)
            {
                listBox1.Items.Add("------------------------------------");
                listBox1.Items.Add("Номер кімнати: " + room.Id);
                listBox1.Items.Add("Номер інструмента: ");
                for (int i = 0; i < room.InstIds.Length; i++)
                {
                    listBox1.Items.Add(room.InstIds.ElementAtOrDefault(i));
                }
                listBox1.Items.Add("ІПН працівника: ");
                for (int i = 0; i < room.WorkNum.Length; i++)
                {
                    listBox1.Items.Add(room.WorkNum.ElementAtOrDefault(i));
                }
                listBox1.Items.Add("Мін. кіль-сть інструментів: " + room.MinInst);
                listBox1.Items.Add("Макс. кіль-сть інструментів: " + room.MaxInst);
                listBox1.Items.Add("Мін. кіль-сть працівників: " + room.MinWorkers);
                listBox1.Items.Add("Макс. кіль-сть працівників: " + room.MaxWorkers);
                listBox1.Items.Add("Вартість запису: " + room.RecCost);
                listBox1.Items.Add("Кількість інструментів: " + room.InstCount);
                listBox1.Items.Add("Кількість працівників: " + room.WorkersCount);
                listBox1.Items.Add("------------------------------------");
            }
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var room in Rooms)
            {
                listBox1.Items.Add("------------------------------------");
                listBox1.Items.Add("Номер кімнати: " + room.Id);
                listBox1.Items.Add("Номер інструмента: ");
                for (int i = 0; i < room.InstIds.Length; i++)
                {
                    listBox1.Items.Add(room.InstIds.ElementAtOrDefault(i));
                }
                listBox1.Items.Add("ІПН працівника: ");
                for (int i = 0; i < room.WorkNum.Length; i++)
                {
                    listBox1.Items.Add(room.WorkNum.ElementAtOrDefault(i));
                }
                listBox1.Items.Add("Мін. кіль-сть інструментів: " + room.MinInst);
                listBox1.Items.Add("Макс. кіль-сть інструментів: " + room.MaxInst);
                listBox1.Items.Add("Мін. кіль-сть працівників: " + room.MinWorkers);
                listBox1.Items.Add("Макс. кіль-сть працівників: " + room.MaxWorkers);
                listBox1.Items.Add("Вартість запису: " + room.RecCost);
                listBox1.Items.Add("Кількість інструментів: " + room.InstCount);
                listBox1.Items.Add("Кількість працівників: " + room.WorkersCount);
                listBox1.Items.Add("------------------------------------");
            }
        }
    }
}
