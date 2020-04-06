using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRandomizer
{
    public partial class ErrorMsgBox : Form
    {
        static ErrorMsgBox ErrorBox;
        public ErrorMsgBox()
        {
            InitializeComponent();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            ErrorBox.Close();
        }

        public static void Show(string msg)
        {
            ErrorBox = new ErrorMsgBox();
            ErrorBox.labelMsg.Text = msg;
            ErrorBox.ShowDialog();
        }
    }
}
