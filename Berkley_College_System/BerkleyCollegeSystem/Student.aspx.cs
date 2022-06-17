using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerkleyCollegeSystem
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {

            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @" SELECT s.Student_ID as ""Student ID"", p.First_Name as ""First Name"", p.Last_Name as ""Last Name"", 
                                TO_CHAR(p.DOB, 'DD Mon, YYYY') as ""Date of Birth"", p.Gender as ""Gender"", p.Email as ""Email"", p.Phone_Number as ""Phone Number"", 
                                TO_CHAR(s.Enroll_Date, 'DD Mon, YYYY') as ""Enroll Date"", s.Emergency_Contact as ""Emergency Contanct"",
                                CASE s.""Is_Fee_Due?"" WHEN 'T' THEN 'Yes' ELSE 'No' END as ""Fee Due"",
                                CASE s.""Is_Attendance_Eligible?"" WHEN 'T' THEN 'Yes' ELSE 'No' END as ""Attendance Eligible"",
                                CASE s.""Is_Graduate?"" WHEN 'T' THEN 'Yes' ELSE 'No' END as ""Graduate""
                                FROM student s 
                                INNER JOIN person p ON s.student_id = p.person_id";

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            StudentGridView.DataSource = dt;
            StudentGridView.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // insert code
            string first_name = TextBoxFirstName.Text.ToString().TrimStart().TrimEnd();
            string last_name = TextBoxLasttName.Text.ToString().TrimStart().TrimEnd();
            string dob = DateTime.Parse(DateTimeDOB.Text.ToString()).ToString("dd/MM/yyyy");
            string gender = DDLGender.SelectedValue;
            string email = TextBoxEmail.Text.ToString().TrimStart().TrimEnd();
            string phone_number = TextBoxPhoneNumber.Text.ToString().TrimStart().TrimEnd();
            string enroll_date = DateTime.Parse(DateTimeEnrollDate.Text.ToString()).ToString("dd/MM/yyyy");
            string emergency_contact = TextBoxEmergencyContact.Text.ToString().TrimStart().TrimEnd();
            string fee_due = CheckBoxIsFeeDue.Checked ? "T" : "F";
            string attendance_eligible = CheckBoxIsAttendanceEligible.Checked ? "T" : "F";
            string graduate = CheckBoxIsGraduate.Checked ? "T" : "F";

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (ButtonSubmit.Text == "Submit")
            {
                
                OracleCommand cmd;
                string current_person_id = "";
                
                cmd = new OracleCommand("SELECT person_id FROM person WHERE Email = '" + email + "'");
                cmd.Connection = con;
                con.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        current_person_id = sdr["person_id"].ToString();
                    }
                }
                con.Close();

                if (current_person_id != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert('Email already exists');", true);
                    return;
                }

                cmd = new OracleCommand("SELECT person_id FROM person WHERE Phone_Number = '" + phone_number + "'");
                cmd.Connection = con;
                con.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        current_person_id = sdr["person_id"].ToString();
                    }
                }
                con.Close();

                if (current_person_id != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert('Phone Number already exists');", true);
                    return;
                }


                cmd = new OracleCommand("Insert into person(First_Name, Last_Name, DOB, Gender, Email, Phone_Number) Values('" + first_name + "','" + last_name + "',TO_DATE('" + dob + "', 'DD/MM/YYYY'),'" + gender + "','" + email + "','" + phone_number + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                current_person_id = "";
                cmd = new OracleCommand("SELECT person_id FROM person WHERE Email = '" + email + "'");
                cmd.Connection = con;
                con.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        current_person_id = sdr["person_id"].ToString();
                    }
                }
                con.Close();

                cmd = new OracleCommand(@"Insert into student(Student_ID, Enroll_Date, Emergency_Contact, ""Is_Fee_Due?"", ""Is_Attendance_Eligible?"", ""Is_Graduate?"") Values('" + current_person_id + "',TO_DATE('" + enroll_date + "', 'DD/MM/YYYY'),'" + emergency_contact + "','" + fee_due + "','" + attendance_eligible + "','" + graduate + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                StudentGridView.EditIndex = -1;
            }
            else if (ButtonSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = StudentID.Text.ToString();
                
                OracleCommand cmd = new OracleCommand("Update Person set First_Name = '" + first_name + "',Last_Name = '" + last_name + "',DOB = TO_DATE('" + dob + "', 'DD/MM/YYYY'), Gender = '" + gender + "',Email = '" + email + "',Phone_Number = '" + phone_number + "' where Person_ID = '" + ID +"'");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                cmd = new OracleCommand("Update Student set Enroll_Date = TO_DATE('" + enroll_date + "', 'DD/MM/YYYY'), Emergency_Contact = '" + emergency_contact + @"', ""Is_Fee_Due?"" = '" + fee_due + @"', ""Is_Attendance_Eligible?"" = '" + attendance_eligible + @"', ""Is_Graduate?"" = '" + graduate + "' where Student_ID = '" + ID + "'");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                StudentGridView.EditIndex = -1;
            }


            // reset all input files
            StudentID.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxLasttName.Text = "";
            DateTimeDOB.Text = "";
            DDLGender.SelectedIndex = 0;
            TextBoxEmail.Text = "";
            TextBoxPhoneNumber.Text = "";
            DateTimeEnrollDate.Text = "";
            TextBoxEmergencyContact.Text = "";
            CheckBoxIsFeeDue.Checked = false;
            CheckBoxIsAttendanceEligible.Checked = false;
            CheckBoxIsGraduate.Checked = false;

            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            StudentGridView.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = StudentGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Student WHERE Student_ID = '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            StudentGridView.EditIndex = -1;

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != StudentGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }

            //this.BindGrid();
            StudentGridView.EditIndex = -1;

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            StudentID.Text = this.StudentGridView.Rows[e.NewEditIndex].Cells[1].Text;

            TextBoxFirstName.Text = this.StudentGridView.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            TextBoxLasttName.Text = this.StudentGridView.Rows[e.NewEditIndex].Cells[3].Text.ToString();

            DateTime DOB = DateTime.Parse(this.StudentGridView.Rows[e.NewEditIndex].Cells[4].Text.ToString());
            DateTimeDOB.Text = DOB.ToString("yyyy-MM-dd");
            
            DDLGender.SelectedValue = this.StudentGridView.Rows[e.NewEditIndex].Cells[5].Text.ToString();
            TextBoxEmail.Text = this.StudentGridView.Rows[e.NewEditIndex].Cells[6].Text.ToString();

            TextBoxPhoneNumber.Text = this.StudentGridView.Rows[e.NewEditIndex].Cells[7].Text.ToString();

            DateTime EnrollDate = DateTime.Parse(this.StudentGridView.Rows[e.NewEditIndex].Cells[8].Text.ToString());
            DateTimeEnrollDate.Text = EnrollDate.ToString("yyyy-MM-dd");

            string cur_emergency_number = this.StudentGridView.Rows[e.NewEditIndex].Cells[9].Text.ToString();
            if ( cur_emergency_number == "&nbsp;" ) { cur_emergency_number = ""; }
            TextBoxEmergencyContact.Text = cur_emergency_number;

            CheckBoxIsFeeDue.Checked = this.StudentGridView.Rows[e.NewEditIndex].Cells[10].Text.ToString() == "Yes";
            CheckBoxIsAttendanceEligible.Checked = this.StudentGridView.Rows[e.NewEditIndex].Cells[11].Text.ToString() == "Yes";
            CheckBoxIsGraduate.Checked = this.StudentGridView.Rows[e.NewEditIndex].Cells[12].Text.ToString() == "Yes";

            ButtonSubmit.Text = "Update";

        }
    }
}