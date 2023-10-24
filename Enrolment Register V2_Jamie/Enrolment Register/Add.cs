using System;
using System.Globalization;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Add : Form 
    {

        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // This "directive" is needed for proper mamagement of date strings
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime checkDate;

            // Assemble student record from Form input and add to List structure

            double fee = 0;
            
            
            

            // Using try-catch to handle incorrect date format
            try
            {
                checkDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", provider);

                // Check for input values - if any field is blank display error message
                if ((txtName.Text == "") || (cboGender.SelectedIndex == -1) || (cboMode.SelectedIndex == -1) || (cboYear.SelectedIndex == -1) || (cboNumModules.SelectedIndex== -1))
                {
                    MessageBox.Show("Record cannot be saved unless all values supplied");
                }
                else
                {
                    if (cboMode.Text == "FT")
                    {
                        //For a FT student, the tuition fee is £5000 for Year 1,
                        //Year 2 and Year 4 students and £2500 for a Year 3 student who is on placement.
                        if((cboYear.Text == "1") || (cboYear.Text == "2") || (cboYear.Text == "4"))
                        {
                            fee = 5000;
                        }
                        else
                        {
                            fee = 2500;
                        }

                    }
                    else   // Calculate part time fee 
                    {
                        fee = double.Parse(cboNumModules.Text) * 750;
                      

                    }
                
                    // Create instance of Student and populate properties with input data
                    Student s = new Student();

                    s.name = txtName.Text;
                    s.gender = cboGender.Text;
                    s.DOB = txtDOB.Text;
                    s.mode = cboMode.Text;
                    s.year = cboYear.Text;                           
                    s.numModules = cboNumModules.Text;         
                    s.totalFee = fee.ToString();



                    // Add new student to List Structure
                    e_Data.s_List.Add(s); 

                    // Closes form
                    this.Close();  

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format in Student file");
                this.Close();
            }
        }

        private void txtDOB_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
