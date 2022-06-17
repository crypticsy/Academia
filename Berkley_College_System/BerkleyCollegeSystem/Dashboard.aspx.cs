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

    public partial class WebForm7 : System.Web.UI.Page
    {
        public string YearLabel;
        public string Revenue;
        public string GenderLabels;
        public string GenderDistribution;
        public string GenderDistributionTable;
        public string ModuleLabels;
        public string ModuleDistribution;

        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                this.PopulateCard();
                this.PlotYearlyFee();
                this.PlotGenderDistribution();
                this.PlotModuleDistribution();
            }
        }

        private void PopulateCard()
        {

            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT COUNT(*) FROM Student";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int count = Convert.ToInt32(dr[0]);
            con.Close();

            // get the count of students
            StudentCount.InnerText = count.ToString();



            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT COUNT(*) FROM Teacher";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0]);
            con.Close();

            // get the count of teachers
            TeacherCount.InnerText = count.ToString();



            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT COUNT(*) FROM Module";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0]);
            con.Close();

            // get the count of modules
            ModuleCount.InnerText = count.ToString();



            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT COUNT(UNIQUE(Building)) FROM Department";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0]);
            con.Close();

            // get the count of buildings
            BuildingCount.InnerText = count.ToString();

        }


        private void PlotYearlyFee()
        {
            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT SUM(fee_amount), Extract(year from Payment_date) as year FROM Fee_payment GROUP BY Extract(year from Payment_date) order by Extract(year from Payment_date)";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            YearLabel = "[ ";
            Revenue = "[ ";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                YearLabel += dt.Rows[i]["year"].ToString() + ",";
                Revenue += dt.Rows[i]["SUM(fee_amount)"].ToString() + ",";
            }

            YearLabel += " ]";
            Revenue += " ]";
        }


        private void PlotGenderDistribution()
        {
            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select count(*) as total, gender from person group by gender order by gender";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GenderLabels = "[ ";
            GenderDistribution = "[ ";
            
            string start_filler = "<tr><td>";
            string middle_filler = "</td><td class='text-end'>";
            string end_filler=  "</td></tr>";
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GenderLabels += "'"+dt.Rows[i]["gender"].ToString() + "',";
                GenderDistribution += dt.Rows[i]["total"].ToString() + ",";
                GenderDistributionTable += start_filler + dt.Rows[i]["gender"].ToString() + middle_filler + dt.Rows[i]["total"].ToString() + end_filler;
            }

            GenderLabels += " ]";
            GenderDistribution += " ]";

        }


        private void PlotModuleDistribution()
        {
            var constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select * from  
                                    ( select m.module_name, count(*) as total
                                    from module_student ms
                                    inner join module m on m.module_code = ms.module_code 
                                    group by m.module_name
                                    order by count(*) desc ) 
                                where ROWNUM <= 5";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            ModuleLabels = "[ ";
            ModuleDistribution = "[ ";
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModuleLabels += "'"+dt.Rows[i]["module_name"].ToString() + "',";
                ModuleDistribution += dt.Rows[i]["total"].ToString() + ",";
            }

            ModuleLabels += " ]";
            ModuleDistribution += " ]";

        }
    }
}
