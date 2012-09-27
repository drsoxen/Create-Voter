using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentVote
{
    public partial class StudentVote : Form
    {
        
        string FirstName;
        string LastName;
        string UserName;

        string FirstChoiceCurrentSelection;
        string SecondChoiceCurrentSelection;
        string ThirdChoiceCurrentSelection;

        string FullName;

        Confirm m_Submit;

        public StudentVote()
        {
            InitializeComponent();
            List<string> ComboBoxes = new List<string>(); ;
            ComboBoxes.Add("Wild Card");
            ComboBoxes.Add("Programmer");
            ComboBoxes.Add("Artist");
            ComboBoxes.Add("Designer");
            

            FirstChoice.DataSource = null;
            SecondChoice.DataSource = null;
            ThirdChoice.DataSource = null;

            FirstChoice.Items.Clear();
            SecondChoice.Items.Clear();
            ThirdChoice.Items.Clear();

            FirstChoice.DataSource = new BindingSource(ComboBoxes,null);
            SecondChoice.DataSource = new BindingSource(ComboBoxes,null);
            ThirdChoice.DataSource = new BindingSource(ComboBoxes, null);

            FirstChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            SecondChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            ThirdChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FullName = FullNameTextBox.Text;

        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UserName = UserNameTextBox.Text;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (FullName.IndexOf(' ') != -1)
            {
                FirstName = FullName.Substring(0, FullName.IndexOf(' '));
                LastName = FullName.Substring(FullName.IndexOf(' ') + 1, (FullName.Length) - FullName.IndexOf(' ') - 1);

                if ((FirstChoiceCurrentSelection == "Wild Card" || FirstChoiceCurrentSelection != SecondChoiceCurrentSelection && FirstChoiceCurrentSelection != ThirdChoiceCurrentSelection) &&
    (SecondChoiceCurrentSelection == "Wild Card" || FirstChoiceCurrentSelection != SecondChoiceCurrentSelection && SecondChoiceCurrentSelection != ThirdChoiceCurrentSelection) &&
        (ThirdChoiceCurrentSelection == "Wild Card" || ThirdChoiceCurrentSelection != SecondChoiceCurrentSelection && FirstChoiceCurrentSelection != ThirdChoiceCurrentSelection))
                {
                    m_Submit = new Confirm(FirstName, LastName, UserName, FirstChoiceCurrentSelection, SecondChoiceCurrentSelection, ThirdChoiceCurrentSelection);
                    m_Submit.Show();
                }
                else
                    MessageBox.Show("Two or more of your choices are the same");
            }
            else
                MessageBox.Show("You need to have a space between your first and last name");


        }

        private void FirstChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstChoiceCurrentSelection = (string)FirstChoice.SelectedItem;
        }

        private void SecondChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecondChoiceCurrentSelection = (string)SecondChoice.SelectedItem;
        }

        private void ThirdChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThirdChoiceCurrentSelection = (string)ThirdChoice.SelectedItem;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if(m_Submit != null)
            if (m_Submit.Sent == true)
            {
                this.Close();
            }
        }











    }
}
