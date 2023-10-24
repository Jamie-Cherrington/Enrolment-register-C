using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Search : Form
    {
        
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            // Get the name of the student to search for from the text box
            string name = txtName.Text;

            // Create a variable to store the found student.
            Student foundStudent = null;

            // Loop through each student in the list
            foreach (Student s in e_Data.s_List)
            {
                if (s.name == name)
                {
                    // Stores a reference to the current student in the foundStudent variable
                    foundStudent = s;

                    // Exit the loop
                    break;
                }
            }

            // Check if a student was found
            if (foundStudent != null)
            {
                // If a student was found, display their details in the output label
                lblOutput.Text = foundStudent.name + ", " + foundStudent.gender + ", " + foundStudent.DOB + ", " + foundStudent.mode + ", " + foundStudent.year + ", " + foundStudent.numModules + ", " + foundStudent.totalFee;
            }
            else
            {
                // If the student was not able to be found, display an error message in the output label
                lblOutput.Text = "Student was not able to be found";
            }

 }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}