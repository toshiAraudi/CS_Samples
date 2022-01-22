using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progressTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DoSomething(IProgress<int> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                if (progress != null)
                    progress.Report(i);
            }
        }

        public void DoSomethingTraditional()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                progressBar1.Value = i;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;

            });
            //await Task.Run(() => DoSomething(progress));
            await Task.Run(() => DoSomethingTraditional());
        }
    }
}
