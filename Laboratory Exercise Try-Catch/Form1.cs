using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratory_Exercise_Try_Catch
{
    public partial class Form1 : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        /////return methods 
        public long StudentNumber(string studNum)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(studNum))
                {
                    throw new ArgumentException("Please put your Student Number");
                }

                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Student Number" + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Student Number is too Long" +ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Contact))
                {
                    throw new ArgumentNullException("Contact number cannot be empty.");
                }
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Contact number must be 10 or 11 digits.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Contact number too large: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
 
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(MiddleInitial))
                {
                    throw new ArgumentNullException("Name fields Empty.");
                }
                if (Regex.IsMatch(LastName, @"^[a-zA-Z ]+$")&&
                    Regex.IsMatch(FirstName, @"^[a-zA-Z ]+$")&&
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z ]+$"))
                    {
                    _FullName = LastName + " " + FirstName + " " + MiddleInitial;

                }
                else
                {
                    throw new FormatException("Name Field must contain only Letters.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return _FullName;
        }
 
        public int Age(string age)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(age))
                {
                    throw new ArgumentNullException("Age cannot be empty.");
                }
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age); 
                }
                else
                {
                    throw new FormatException("Invalid age format.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Age value is too large: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return _Age;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                 "BS Computer Science",
                 "BS Information Systems",
                 "BS in Accountancy",
                 "BS in Hospitality Management",
                 "BS in Tourism Management"
            };

             for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());

            }
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
         
            StudentInformationClass.SetFullName = FullName(txtLastName.Text,
            txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = (int) StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyyMM-dd");

            Confirmation frm = new Confirmation();
            frm.ShowDialog();
        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
