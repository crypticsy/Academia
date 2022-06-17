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
    public partial class WebForm3 : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT Address_ID as ""Address ID"", Country as ""Country"", Street, ZIP_Code as ""ZIP Code"" FROM Address";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Address");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            AddressGridView.DataSource = dt;
            AddressGridView.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string country = TextCountry.Text.ToString().TrimStart().TrimEnd();
            string street = TextStreet.Text.ToString().TrimStart().TrimEnd();
            string zip_code = TextZipCode.Text.ToString().TrimStart().TrimEnd();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (ButtonSubmit.Text == "Submit")
            {

                OracleCommand cmd = new OracleCommand("Insert into Address(Country, Street, ZIP_Code) Values('" + country + "','" + street + "','" + zip_code + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                AddressGridView.EditIndex = -1;
            }
            else if (ButtonSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = AddressID.Text.ToString();
                OracleCommand cmd = new OracleCommand("Update Address set Country = '" + country + "',Street = '" + street + "',ZIP_Code = '" + zip_code + "' where Address_ID = '" + ID + "'");

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ButtonSubmit.Text = "Submit";
                AddressGridView.EditIndex = -1;
            }

            TextCountry.Text = "";
            TextStreet.Text = "";
            TextZipCode.Text = "";

            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            AddressGridView.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = AddressGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Address WHERE Address_ID = '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            AddressGridView.EditIndex = -1;

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != AddressGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
            //this.BindGrid();
            AddressGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            AddressID.Text = this.AddressGridView.Rows[e.NewEditIndex].Cells[1].Text;

            TextCountry.Text = this.AddressGridView.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
            TextStreet.Text = this.AddressGridView.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd();
            TextZipCode.Text = this.AddressGridView.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd();

            ButtonSubmit.Text = "Update";

        }
    }
}