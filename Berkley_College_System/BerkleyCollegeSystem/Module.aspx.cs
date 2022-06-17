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
    public partial class WebForm1 : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT Module_Code as ""Module Code"", Module_Name as ""Module Name"", Credit_Hours as ""Credit Hours"", Total_Days as ""Total Days"" FROM Module";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Module");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            ModuleGridView.DataSource = dt;
            ModuleGridView.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string module_name = TextBoxName.Text.ToString().TrimStart().TrimEnd();
            string credit_hours = TextCreditHours.Text.ToString().TrimStart().TrimEnd();
            string total_days = TextTotalDays.Text.ToString().TrimStart().TrimEnd();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (ButtonSubmit.Text == "Submit")
            {

                OracleCommand cmd = new OracleCommand("Insert into Module(Module_Name, Credit_Hours, Total_Days) Values('" + module_name + "'," + credit_hours + "," + total_days + ")");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                ModuleGridView.EditIndex = -1;
            }
            else if (ButtonSubmit.Text == "Update")
            {
                //get ID for the Update
                string Code = ModuleCode.Text.ToString();
                OracleCommand cmd = new OracleCommand("Update Module set Module_Name = '" + module_name + "', Credit_Hours = " + credit_hours + ", Total_Days = " + total_days + " WHERE Module_Code = '" + Code + "'");

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                ModuleGridView.EditIndex = -1;
            }

            TextBoxName.Text = "";
            TextCreditHours.Text = "";
            TextTotalDays.Text = "";

            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            ModuleGridView.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Code = ModuleGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Module WHERE Module_Code = '" + Code + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            ModuleGridView.EditIndex = -1;

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != ModuleGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
            //this.BindGrid();
            ModuleGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            ModuleCode.Text = this.ModuleGridView.Rows[e.NewEditIndex].Cells[1].Text;

            TextBoxName.Text = this.ModuleGridView.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
            TextCreditHours.Text = this.ModuleGridView.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd();
            TextTotalDays.Text = this.ModuleGridView.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd();

            ButtonSubmit.Text = "Update";

        }
    }
}