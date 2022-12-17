using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkerForm : Form
    {
        public List<RecStudio> RecStudios = new List<RecStudio>();

        public Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();

        public List<Instrument> Instruments = new List<Instrument>();

        public List<Room> Rooms = new List<Room>();

        public WorkerForm()
        {
            InitializeComponent();
        }


        int summary, oneSal;
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm form1 = (MainForm)Application.OpenForms[0];

            StringBuilder workersInfo = new StringBuilder();

            StringBuilder workerssInfoTemp = new StringBuilder();

            foreach (var item in Workers)
            {
                workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Id.ToString());
                workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Name.ToString());
                workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Salary.ToString());
                workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.TrackCount.ToString());

                summary += Convert.ToInt32(item.Value.Salary);
                oneSal = (summary / Workers.Count);
            }

            workersInfo.Append(workerssInfoTemp);

            workerssInfoTemp.Clear();

            // збережемо зміни
            File.WriteAllText(@"..\..\Studio\Робітники.txt", workersInfo.ToString());

            foreach (var item in RecStudios)
            {
                item.CountOfWorkers = listBox1.Items.Count;
                item.OneWorkerSalary = oneSal;
                item.AllWorkersSalary = summary;
            }

            form1.RecStudios = RecStudios;
            form1.Workers = Workers;
            form1.Instruments = Instruments;
            form1.Rooms = Rooms;

            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
            {
                MessageBox.Show("Не введено усі дані!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text.Where(char.IsDigit).Count() == 12)
                {
                    Workers.Add(textBox1.Text, Worker.CreateWorker(textBox1.Text, textBox2.Text,
                        Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)));

                    StringBuilder workersInfo = new StringBuilder();

                    StringBuilder workerssInfoTemp = new StringBuilder();

                    foreach (var item in Workers)
                    {
                        workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Id.ToString());
                        workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Name.ToString());
                        workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.Salary.ToString());
                        workerssInfoTemp = workerssInfoTemp.AppendLine(item.Value.TrackCount.ToString());
                    }

                    workersInfo.Append(workerssInfoTemp);

                    workerssInfoTemp.Clear();

                    // збережемо студію у файл
                    File.WriteAllText(@"..\..\Studio\Робітники.txt", workersInfo.ToString());
                    MessageBox.Show("Робітника додано до файлу");


                    // зчитаємо файл та перенесемо у тимчасовий список
                    var tempList = File.ReadAllLines(@"..\..\Studio\Робітники.txt");

                    foreach (var item in Workers)
                    {
                        Workers.OnDeserialization(tempList);
                    }
                }
                else
                    MessageBox.Show("Номер повинен складатися з 12 символів!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                listBox1.Items.Add("ІПН: " + textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in Workers)
            {
                if (listBox1.Text == "ІПН: " + item.Value.Id)
                {
                    listBox1.Items.Remove("ІПН: " + item.Value.Id);
                    Workers.Remove(item.Key);

                    break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Workers)
            {
                listBox1.Items.Add("ІПН: " + item.Value.Id);
            }
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Workers)
            {
                listBox1.Items.Add("ІПН: " + item.Value.Id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count >= 1)
            {
                foreach (var item in Workers)
                {
                    if (listBox1.Text == "ІПН: " + item.Value.Id)
                    {
                        MessageBox.Show($"Працівник - {item.Value.Name}\nІПН: {item.Key}\nЗаробітна плата: {item.Value.Salary}\nКіль-сть треків: {item.Value.TrackCount} ", 
                            "Деталі", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                }
            }

            listBox1.Items.Clear();

            foreach (var item in Workers)
            {
                listBox1.Items.Add("ІПН: " + item.Value.Id);
            }
        }
    }
}
