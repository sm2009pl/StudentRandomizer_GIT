using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRandomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            checkedListBox1.Items.Clear();
            GStudentList.getStudents.Clear();
            foreach (String file in openFileDialog1.FileNames)
            {
                var content = File.ReadAllText(file);
                foreach (var item in content.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Student tempStudent = new Student();
                    bool result = tempStudent.CopyFromString(item);
                    if(result == false)
                    {
                        GStudentList.getStudents.Clear();
                        break;
                    }
                    int repeater = 0;
                    foreach(var stud in GStudentList.getStudents)
                    {
                        if (tempStudent.albumNumber == stud.albumNumber)
                        {
                            repeater++;
                        }
                    }
                    if (repeater == 0)
                    {
                        GStudentList.getStudents.Add(tempStudent);
                        checkedListBox1.Items.Add(tempStudent.GetText());
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            List<Student> checkedStudents = new List<Student>();
            int[] indexes = checkedListBox1.CheckedIndices.Cast<int>().ToArray();
            foreach (var item in indexes)
            {
                checkedStudents.Add(GStudentList.getStudents[item]);
            }
            Randomizer randomizer = new Randomizer();
            randomizer.SetPriority(checkedStudents);
            randomizer.ChooseStudentFromList(checkedStudents);
            if(GChosenStudent.getChosenStudent != null)
                textBox1.Text = GChosenStudent.getChosenStudent.GetText();
            checkedStudents.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GChosenStudent.getChosenStudent != null)
            {
                GChosenStudent.getChosenStudent.correctAnswers++;
                GChosenStudent.getChosenStudent.waitingVar = 0;
            }
            GChosenStudent.getChosenStudent = null;
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GChosenStudent.getChosenStudent != null)
            {
                GChosenStudent.getChosenStudent.wrongAnswers++;
                GChosenStudent.getChosenStudent.waitingVar = 0;
            }
            GChosenStudent.getChosenStudent = null;
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (GChosenStudent.getChosenStudent != null)
            {
                GChosenStudent.getChosenStudent.notAnswered++;
            }
            GChosenStudent.getChosenStudent = null;
            textBox1.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (GStudentList.getStudents.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "los file (*.los)|*.los|txt files (*.txt)|*.txt";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, String.Empty);
                    foreach (var item in GStudentList.getStudents)
                    {
                        File.AppendAllText(saveFileDialog1.FileName, item.GetStudent() + Environment.NewLine);
                    }
                }
            }
        }
    }   
}
