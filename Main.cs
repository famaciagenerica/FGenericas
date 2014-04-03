using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciasGenericas
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult desicion = new System.Windows.Forms.DialogResult();
            desicion =  MessageBox.Show("Desea salir de la aplicación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (desicion == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
