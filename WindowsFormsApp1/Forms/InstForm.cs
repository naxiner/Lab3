using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InstForm : Form
    {
        public string[] InstTypes = { "Барабан", "Бас-гітара", "Ритм-гітара", "Соло-гітара", "Сінтезатор", "Фортепіано", "Саксофон", "Віолончель", "Скрипка", "Баян" };

        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public InstForm()
        {
            InitializeComponent();

            foreach (var item in InstTypes)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];

            StringBuilder instInfo = new StringBuilder();

            StringBuilder instInfoTemp = new StringBuilder();

            foreach (var item in Instruments)
            {
                instInfoTemp = instInfoTemp.AppendLine(item.Id.ToString());
                instInfoTemp = instInfoTemp.AppendLine(item.Type.ToString());
                instInfoTemp = instInfoTemp.AppendLine(item.Price.ToString());
            }

            instInfo.Append(instInfoTemp);

            instInfoTemp.Clear();

            // збережемо зміни
            File.WriteAllText(@"..\..\Studio\Інструменти.txt", instInfo.ToString());

            int sumInst = listBox2.Items.Count;
            foreach (var item in RecStudios)
            {
                item.NumberOfInstruments = sumInst;
            }

            form1.RecStudios = RecStudios;
            form1.Workers = Workers;
            form1.Instruments = Instruments;
            form1.Rooms = Rooms;

            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            Instruments.Add(Instrument.CreateInstrument(comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox1.Text)));
            

            StringBuilder instInfo = new StringBuilder();

            StringBuilder instInfoTemp = new StringBuilder();

            foreach (var item in Instruments)
            {
                instInfoTemp = instInfoTemp.AppendLine(item.Id.ToString());
                instInfoTemp = instInfoTemp.AppendLine(item.Type.ToString());
                instInfoTemp = instInfoTemp.AppendLine(item.Price.ToString());
            }

            instInfo.Append(instInfoTemp);

            instInfoTemp.Clear();

            // збережемо студію у файл
            File.WriteAllText(@"..\..\Studio\Інструменти.txt", instInfo.ToString());
            MessageBox.Show("Інструмент додано до файлу");


            // зчитаємо файл та перенесемо у тимчасовий список
            var tempList = File.ReadAllLines(@"..\..\Studio\Інструменти.txt");

            foreach (var item in Instruments)
            {
                listBox1.Items.Add(item.Id);
                listBox1.Items.Add(item.Type);
                listBox1.Items.Add(item.Price);
                listBox2.Items.Add(item.Id);
            }
        }

        // Обробник натискання клавіші "Видалити інструмент"
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in Instruments)
            {
                if (listBox2.Text == item.Id.ToString())
                {
                    listBox2.Items.Remove(item.Id);
                    listBox1.Items.Remove(item.Id);
                    listBox1.Items.Remove(item.Type);
                    listBox1.Items.Remove(item.Price);
                    Instruments.Remove(item);

                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            foreach (var item in Instruments)
            {
                listBox1.Items.Add(item.Id);
                listBox1.Items.Add(item.Type);
                listBox1.Items.Add(item.Price);
                listBox2.Items.Add(item.Id);
            }
        }

        private void InstForm_Load(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            foreach (var item in Instruments)
            {
                listBox1.Items.Add(item.Id);
                listBox1.Items.Add(item.Type);
                listBox1.Items.Add(item.Price);
                listBox2.Items.Add(item.Id);
            }
        }
    }
}
