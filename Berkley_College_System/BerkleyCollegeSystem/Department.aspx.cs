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
    public partial class About : Page
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
            cmd.CommandText = @"SELECT Department_ID as ""Department ID"", Department_Name as ""Department Name"", Department_Type as ""Department Type"", Building as ""Building"", Room as ""Room"" FROM Department";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Department");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            DepartmentGridView.DataSource = dt;
            DepartmentGridView.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string department_name = TextBoxName.Text.ToString().TrimStart().TrimEnd();
            string department_type = TextBoxType.Text.ToString().TrimStart().TrimEnd();
            string buidling = TextBoxBuilding.Text.ToString().TrimStart().TrimEnd();
            string room = TextBoxRoom.Text.ToString().TrimStart().TrimEnd();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (ButtonSubmit.Text == "Submit")
            {

                OracleCommand cmd = new OracleCommand("Insert into Department(Department_Name, Department_Type, Building, Room) Values('" + department_name + "','" + department_type + "','" + buidling + "','" + room + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                DepartmentGridView.EditIndex = -1;
            }
            else if (ButtonSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = DepartmentID.Text.ToString();
                OracleCommand cmd = new OracleCommand("Update Department set Department_Name = '" + department_name + "',Department_Type = '" + department_type + "',Building = '" + buidling + "',Room = '" + room + "' where Department_ID = '" + ID +"'");
                
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                DepartmentGridView.EditIndex = -1;
            }

            TextBoxName.Text = "";
            TextBoxType.Text = "";
            TextBoxBuilding.Text = "";
            TextBoxRoom.Text = "";

            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            DepartmentGridView.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = DepartmentGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Department WHERE Department_ID = '" + ID +"'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            DepartmentGridView.EditIndex = -1;

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != DepartmentGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
            //this.BindGrid();
            DepartmentGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            DepartmentID.Text = this.DepartmentGridView.Rows[e.NewEditIndex].Cells[1].Text;

            TextBoxName.Text = this.DepartmentGridView.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
            TextBoxType.Text = this.DepartmentGridView.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd();
            TextBoxBuilding.Text = this.DepartmentGridView.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd();
            TextBoxRoom.Text = this.DepartmentGridView.Rows[e.NewEditIndex].Cells[5].Text.ToString().TrimStart().TrimEnd();

            ButtonSubmit.Text = "Update";

        }
    }
}