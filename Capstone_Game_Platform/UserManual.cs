using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class UserManual : Form
    {
        public List<Panel> listPanel = new List<Panel>();
        public int Index = 0;
        public UserManual()
        {
            InitializeComponent();            
        }  

        private void UserManual_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            listPanel.Add(panel5);
            listPanel.Add(panel6);
            listPanel.Add(panel7);
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            btnBack.Hide();
            btnNext.Show();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(Index < listPanel.Count - 1)
            {
                listPanel[Index].Hide();
                listPanel[++Index].Show();
            }
            SetBtnVisibility();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (Index >= 0)
            {
                listPanel[Index].Hide();
                listPanel[--Index].Show();
            }
            SetBtnVisibility();
        }

        private void SetBtnVisibility()
        {
            if (Index == 0)
            {
                btnBack.Hide();
                btnNext.Show();
            }
            if (Index > 0 && Index < listPanel.Count)
            {
                btnBack.Show();
                btnNext.Show();
            }
            if (Index == 6)
            {
                btnBack.Show();
                btnNext.Hide();
            }
        }

    }
}
