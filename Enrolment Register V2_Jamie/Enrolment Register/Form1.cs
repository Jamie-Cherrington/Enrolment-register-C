using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Enrolment_Register
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            // On form load, course details are read.
            // List structure AND listbox populated with student details
            string courseRec, studentRec;
            string[] studentRecArray, courseRecArray;
            // Read course data
            StreamReader CourseFile, StudentFile;
            if (File.Exists(@"C:\Users\B00880063\Downloads\CourseDetails.txt")) 
            {
                CourseFile = File.OpenText(@"C:\Users\B00880063\Downloads\CourseDetails.txt");

                while (CourseFile.EndOfStream == false)
                {
                    courseRec = CourseFile.ReadLine();
                    courseRecArray = courseRec.Split(',');
                    e_Data.courseName = courseRecArray[0];
                    e_Data.courseLecturer = courseRecArray[1];
                }

                CourseFile.Close();

            }

            // Read Student file
            // Create instance of Student and add to List structure
            // Refresh Listbox.  
            
            if (File.Exists(@"C:\Users\B00880063\Downloads\StudentDetails.txt"))
            {
                StudentFile = File.OpenText(@"C:\Users\B00880063\Downloads\StudentDetails.txt");

                while (StudentFile.EndOfStream == false)
                {
                    studentRec = StudentFile.ReadLine();
                    lstStudents.Items.Add(studentRec);
                    studentRecArray = studentRec.Split(',');

                    Student student = new Student();

                    student.name = studentRecArray[0];
                    student.DOB = studentRecArray[1];
                    student.gender = studentRecArray[2];
                    student.mode = studentRecArray[3];
                    student.year = studentRecArray[4];
                    student.numModules = studentRecArray[5];
                    student.totalFee = studentRecArray[6];

                    e_Data.s_List.Add(student);
                }

                StudentFile.Close();
                
            }

        }

        private void RefreshListBox()
        {
            // Clear the listbox
            lstStudents.Items.Clear();
            
            // Iterate over the List structure and add each student to listbox

             foreach (Student s in e_Data.s_List)
            {
                lstStudents.Items.Add(s.name + ", " + s.gender + ", " + s.DOB + ", " + s.mode + ", " + s.year + ", " + s.numModules + ", " + s.totalFee);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add myAddForm = new Add();
            myAddForm.ShowDialog();
            RefreshListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sRec;
            string[] sRecArray;
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select student to delete");
            }
            else 
            {
                sRec = lstStudents.Items[lstStudents.SelectedIndex].ToString();
                sRecArray = sRec.Split(',');
                DialogResult result = MessageBox.Show("Delete student: " + sRecArray[0], "Confirm", MessageBoxButtons.YesNoCancel);
                // Remove the student from the List structure and refresh the listbox. If the user clicks Yes
                if (result == DialogResult.Yes)
                {
                    lstStudents.Items.RemoveAt(lstStudents.SelectedIndex);
                    MessageBox.Show("Student " + sRecArray[0] + " has been removed");
                    

                }
           
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Open the Student Details and the Course Details files
            // Write student data to file from the List structure
            // ...

            StreamWriter StudentFile = new StreamWriter(@"C:\Users\B00880063\Downloads\StudentDetails.txt");

            // Write student data to file from the List structure
            foreach (Student s in e_Data.s_List)
            {
                StudentFile.WriteLine(s.name + ", " + s.gender + ", " + s.DOB + ", " + s.mode + ", " + s.year + ", " + s.numModules + ", " + s.totalFee);
            }

            // Close the Student Details file
            StudentFile.Close();

            // Open the Course Details file for writing
            StreamWriter CourseFile = new StreamWriter(@"C:\Users\B00880063\Downloads\CourseDetails.txt");

            // Write course report data to file from variables
            CourseFile.WriteLine(e_Data.courseName + ", " + e_Data.courseLecturer);

            // Close the Course Details file
            CourseFile.Close();

            // Closes the application 
            Application.Exit();
        
    }

        private void btnReport_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            // Iterate over list structure, counting data as required.
            double male = 0, female = 0, other = 0, Total = 0;
            foreach (Student student in e_Data.s_List)
            {
                if (student.gender == "Male")
                {
                    male++;

                }
                else if (student.gender == "Female")
                {
                    female++;
                }
                else 
                {
                    other++;
                }

                Total++;
            }

                // Find percentages of students gender
                e_Data.coursePCM = (male / Total) * 100;
                e_Data.coursePCF = (female / Total) * 100;
                e_Data.coursePCO = (other / Total) * 100;
                
                // Output of report
                lblOutput.Text = "Course name: " + e_Data.courseName + '\n' +
                                 "Lecturer: " + e_Data.courseLecturer + '\n' +
                                 "Total No. of Students: " + Total + "\n" +
                                 "Male Students: " + e_Data.coursePCM + "%" + '\n' +
                                 "Female Students: " + e_Data.coursePCF + "%" + "\n" +
                                 "Other Students: " + e_Data.coursePCO + "%";


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search mySearchForm = new Search();
            mySearchForm.ShowDialog();
        }

        public void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}