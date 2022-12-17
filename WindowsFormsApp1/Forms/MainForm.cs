using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        // Списки
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public MainForm()
        {
            InitializeComponent();
        }

        // Обробник натискання клавіші "Додати студію"
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("Поле для вводу даних пусте!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RecStudios.Add(RecStudio.CreateRecStudio(name));
                listBox1.Items.Add(name);
            }
        }
        
        // Обробник натискання клавіші "Відобразити дані"
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Назва студії: " + RecStudios[listBox1.SelectedIndex].NameOfStudio);                         // назва студії
                listBox2.Items.Add("Адреса студії: " + RecStudios[listBox1.SelectedIndex].AdressOfStudio);                      // адреса
                listBox2.Items.Add("Кількість робітників студії: " + RecStudios[listBox1.SelectedIndex].CountOfWorkers);        // кількість робітників
                listBox2.Items.Add("Вартість створення треку: " + RecStudios[listBox1.SelectedIndex].TrackCreationCost);        // вартість створення одного треку
                listBox2.Items.Add("Час створення треку: " + RecStudios[listBox1.SelectedIndex].TrackCreationTime + " годин");             // час створення одного треку
                listBox2.Items.Add("Заробітна плата одного робітника: " + RecStudios[listBox1.SelectedIndex].OneWorkerSalary);  // заробітна плата робітника
                listBox2.Items.Add("Заробітна плата всіх робітників: " + RecStudios[listBox1.SelectedIndex].AllWorkersSalary);  // заробітна плата всіх робітників
                listBox2.Items.Add("Кількість інструментів: " + RecStudios[listBox1.SelectedIndex].NumberOfInstruments);        // кількість інструментів
                listBox2.Items.Add("Кількість кімнат: " + RecStudios[listBox1.SelectedIndex].NumberOfRooms);                    // кількість кімнат
            }
        }

        // Обробник натискання клавіші "Змінити параметр"
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: // назва
                        int nameIndex = listBox1.SelectedIndex;
                        RecStudios[listBox1.SelectedIndex].NameOfStudio = textBox1.Text;
                        listBox1.Items.RemoveAt(nameIndex);
                        listBox1.Items.Insert(nameIndex, textBox1.Text);
                        break;

                    case 1: // адреса
                        RecStudios[listBox1.SelectedIndex].AdressOfStudio = textBox1.Text;
                        break;

                    default: break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdditionalForm editForm = new AdditionalForm();

            editForm.RecStudios = RecStudios;
            editForm.Workers = Workers;
            editForm.Instruments = Instruments;
            editForm.Rooms = Rooms;

            editForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder studioInfo = new StringBuilder();

            StringBuilder studioInfoTemp = new StringBuilder();

            foreach (var item in RecStudios)
            {
                studioInfoTemp = studioInfoTemp.AppendLine(item.NameOfStudio);
                studioInfoTemp = studioInfoTemp.AppendLine(item.AdressOfStudio);
                studioInfoTemp = studioInfoTemp.AppendLine(item.CountOfWorkers.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.TrackCreationCost.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.TrackCreationTime.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.OneWorkerSalary.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.AllWorkersSalary.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.NumberOfInstruments.ToString());
                studioInfoTemp = studioInfoTemp.AppendLine(item.NumberOfRooms.ToString());
            }

            studioInfo.Append(studioInfoTemp);

            studioInfoTemp.Clear();

            // збережемо студію у файл
            File.WriteAllText(@"..\..\Studio\" + listBox1.SelectedItem.ToString() + ".txt", studioInfo.ToString());
            MessageBox.Show("Файл збережено");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            // зчитаємо файл та перенесемо у тимчасовий список
            var tempList = File.ReadAllLines(filename);
            RecStudios.Add(RecStudio.CreateRecStudio("NULL"));

            foreach (var item in RecStudios)
            {
                RecStudios[0].NameOfStudio = tempList.GetValue(0).ToString();
                RecStudios[0].AdressOfStudio = tempList.GetValue(1).ToString();
                RecStudios[0].CountOfWorkers = Convert.ToInt32(tempList.GetValue(2));
                RecStudios[0].TrackCreationCost = Convert.ToInt32(tempList.GetValue(3));
                RecStudios[0].TrackCreationTime = Convert.ToDouble(tempList.GetValue(4));
                RecStudios[0].OneWorkerSalary = Convert.ToInt32(tempList.GetValue(5));
                RecStudios[0].AllWorkersSalary = Convert.ToInt32(tempList.GetValue(6));
                RecStudios[0].NumberOfInstruments = Convert.ToInt32(tempList.GetValue(7));
                RecStudios[0].NumberOfRooms = Convert.ToInt32(tempList.GetValue(8));
                listBox1.Items.Clear();
                listBox1.Items.Add(item.NameOfStudio);
                textBox1.ResetText();
                textBox1.AppendText(item.NameOfStudio);
            }

            MessageBox.Show("Файл відкрито");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // підвантаження інструментів
            List<string> tempInstList = new List<string>(File.ReadAllLines(@"..\..\Studio\Інструменти.txt"));

            for (int i = 0; i < tempInstList.Count; i++)
            {
                if (i == 0 || i % 3 == 0)
                {
                    Instruments.Add(Instrument.CreateInstrument("t", 0));
                }
            }

            foreach (var item in Instruments)
            {
                item.Id = Guid.Parse(tempInstList.First());
                tempInstList.RemoveAt(0);
                item.Type = tempInstList.First().ToString();
                tempInstList.RemoveAt(0);
                item.Price = Convert.ToInt32(tempInstList.First());
                tempInstList.RemoveAt(0);
            }
            tempInstList.Clear();

            // підвантаження робітників
            List<string> tempWorkList = new List<string>(File.ReadAllLines(@"..\..\Studio\Робітники.txt"));

            for (int i = 0; i < tempWorkList.Count; i++)
            {
                if (i == 0 || i % 4 == 0)
                {
                    Workers.Add(tempWorkList[i].ToString(), Worker.CreateWorker("NULL", "NULL", 0, 0));
                }
            }

            foreach (var item in Workers)
            {
                item.Value.Id = tempWorkList.First().ToString();
                tempWorkList.RemoveAt(0);
                item.Value.Name = tempWorkList.First().ToString();
                tempWorkList.RemoveAt(0);
                item.Value.Salary = Convert.ToInt32(tempWorkList.First());
                tempWorkList.RemoveAt(0);
                item.Value.TrackCount = Convert.ToInt32(tempWorkList.First());
                tempWorkList.RemoveAt(0);
            }
            tempWorkList.Clear();

            // підвантаження кімнат
            List<string> tempRoomList = new List<string>(File.ReadAllLines(@"..\..\Studio\Кімнати.txt"));

            List<Guid> tempRoomGuidList = new List<Guid>();
            List<string> tempRoomWorkList = new List<string>();

            for (int i = 0; i < tempRoomList.Count; i++)
            {
                if (tempRoomList[i].Length == 36)
                    tempRoomGuidList.Add(Guid.Parse(tempRoomList[i].ToString()));

                if (tempRoomList[i].Length == 12)
                {
                    tempRoomWorkList.Add(tempRoomList[i].ToString());
                }
                
                if (tempRoomList[i].Length == 28)
                {
                    Rooms.Add(Room.CreateRoom(0, tempRoomGuidList.ToArray(), tempRoomWorkList.ToArray(), 0, 0, 0, 0, 0, 0, 0));
                    tempRoomGuidList.Clear();
                    tempRoomWorkList.Clear();

                    continue;
                }
            }

            foreach (var item in Rooms)
            {
                if (tempRoomList.Count > 0)
                {
                    item.Id = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    tempRoomList.RemoveRange(0, item.InstIds.Length);
                    tempRoomList.RemoveRange(0, item.WorkNum.Length);
                    item.MinInst = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.MaxInst = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.MinWorkers = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.MaxWorkers = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.RecCost = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.InstCount = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);
                    item.WorkersCount = Convert.ToInt32(tempRoomList.First());
                    tempRoomList.RemoveAt(0);

                    if (tempRoomList.Count > 0)
                        tempRoomList.RemoveAt(0);
                }
            }

            tempRoomWorkList.Clear();
            tempRoomGuidList.Clear();
            tempRoomList.Clear();
        }
    }
}
