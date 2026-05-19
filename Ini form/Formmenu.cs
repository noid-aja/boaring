using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Formmenu : Form
    {
        public Formmenu()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void pnlmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Formmenu_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            pnl1.Visible = false;
        }

        private void hideSubMenu()
        {
            if (pnl1.Visible == true)
                pnl1.Visible = false;
        }

        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;


        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl1);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            hideSubMenu();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form child)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelmain.Controls.Add(child);
            panelmain.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void panelmain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
