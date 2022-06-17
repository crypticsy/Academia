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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                this.GetStudent();
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
            cmd.CommandText = @"select p.first_name as ""First Name"", p.last_name as ""Last Name"",
                                a.assignment_name as ""Assignment Name"", m.module_name as ""Module Name"", 
                                ar.Marks as ""Marks"", ar.Grade as ""Grade"", g.Status as ""Status"",
                                TO_CHAR(ar.due_date, 'DD Mon, YYYY') as ""Due Date"",
                                TO_CHAR(ar.submitted_date, 'DD Mon, YYYY') as ""Submitted Date""
                                from student s
                                inner join person p on p.person_id = s.student_id
                                inner join Assignment_Result ar on ar.student_id = s.student_id
                                inner join Module m on m.module_code = ar.module_code
                                inner join Assignment a on a.assignment_id = ar.assignment_id
                                inner join Grade g on g.Grade = ar.Grade";

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            StudentAssignmentGridView.DataSource = dt;
            StudentAssignmentGridView.DataBind();
        }

        private void GetStudent()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select s.student_id, concat( p.first_name, concat(' ', concat( p.last_name , concat('  -  ', p.phone_number)))) as ""student_name"" from student s inner join person p on p.person_id = s.student_id";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            DDLStudent.DataSource = dt;
            DDLStudent.DataTextField = "Student_Name";
            DDLStudent.DataValueField = "Student_ID";
            DDLStudent.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            string student_id = DDLStudent.SelectedValue;

            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select p.first_name as ""First Name"", p.last_name as ""Last Name"",
                                a.assignment_name as ""Assignment Name"", m.module_name as ""Module Name"", 
                                ar.Marks as ""Marks"", ar.Grade as ""Grade"", g.Status as ""Status"",
                                TO_CHAR(ar.due_date, 'DD Mon, YYYY') as ""Due Date"",
                                TO_CHAR(ar.submitted_date, 'DD Mon, YYYY') as ""Submitted Date""
                                from student s
                                inner join person p on p.person_id = s.student_id
                                inner join Assignment_Result ar on ar.student_id = s.student_id
                                inner join Module m on m.module_code = ar.module_code
                                inner join Assignment a on a.assignment_id = ar.assignment_id
                                inner join Grade g on g.Grade = ar.Grade
                                where s.student_id = '" + student_id + "'";

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Student");

            try
            {
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }
            }
            catch
            {
                // do nothing
            }

            con.Close();

            StudentAssignmentGridView.DataSource = dt;
            StudentAssignmentGridView.DataBind();

        }

        protected void ShowAllSubmit_Click(object sender, EventArgs e)
        {

            this.BindGrid();

        }
    }
}