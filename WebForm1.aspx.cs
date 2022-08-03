using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Data
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dispList"] == null && !IsPostBack)
            {
                Session["dispList"] = dispList;
                EmployeeGridView.DataSource = Session["dispList"];
                DataBind();
            }
            else
            {
                EmployeeGridView.DataSource = Session["dispList"];
                DataBind();
            }
        }


        List<Employees> dispList = new Employees().GetEmpList();

        public class Employees
        {
            public string name { get; set; }
            public string id { get; set; }
            public string email { get; set; }
            public string contact { get; set; }
            public string dept { get; set; }

            public List<Employees> GetEmpList()
            {
                Random rand = new Random();
                var myList = new List<Employees>();
                myList.Add(new Employees() { name = "Ali", id = "01" + rand.Next(10, 99).ToString(), email = "ali@rushtub.com", contact = "0301-64322345", dept = "Artificial Intelligence" });
                myList.Add(new Employees() { name = "Hamza", id = "02" + rand.Next(10, 99).ToString(), email = "hamza@rushtub.com", contact = "0301-64322345", dept = "Artificial Intelligence" });
                myList.Add(new Employees() { name = "Adil", id = "03" + rand.Next(10, 99).ToString(), email = "adil@rushtub.com", contact = "0301-64322345", dept = "Artificial Intelligence" });
                myList.Add(new Employees() { name = "Alia", id = "04" + rand.Next(10, 99).ToString(), email = "alia@rushtub.com", contact = "0301-64322345", dept = "Artificial Intelligence" });
                myList.Add(new Employees() { name = "Halim", id = "05" + rand.Next(10, 99).ToString(), email = "Halim@rushtub.com", contact = "0301-64322345", dept = "Web Development" });
                myList.Add(new Employees() { name = "Sarim", id = "06" + rand.Next(10, 99).ToString(), email = "sarim@rushtub.com", contact = "0301-64322345", dept = "Web Development" });
                myList.Add(new Employees() { name = "Qasim", id = "07" + rand.Next(10, 99).ToString(), email = "qasim@rushtub.com", contact = "0301-64322345", dept = "Front End Development" });
                myList.Add(new Employees() { name = "Hala", id = "08" + rand.Next(10, 99).ToString(), email = "hala@rushtub.com", contact = "0301-64322345", dept = "Front End Development" });
                myList.Add(new Employees() { name = "Husnain", id = "09" + rand.Next(10, 99).ToString(), email = "husnain@rushtub.com", contact = "0301-64322345", dept = "Production Analyst" });
                myList.Add(new Employees() { name = "Shehryar", id = "10" + rand.Next(10, 99).ToString(), email = "shehryar@rushtub.com", contact = "0301-64322345", dept = "Production Analyst" });
                myList.Add(new Employees() { name = "Hamza", id = "11" + rand.Next(10, 99).ToString(), email = "hamza@rushtub.com", contact = "0301-64322345", dept = "Human Resource" });
                myList.Add(new Employees() { name = "Hania", id = "12" + rand.Next(10, 99).ToString(), email = "hania@rushtub.com", contact = "0301-64322345", dept = "Human Resource" });
                myList.Add(new Employees() { name = "Abdullah", id = "13" + rand.Next(10, 99).ToString(), email = "abdullah@rushtub.com", contact = "0301-64322345", dept = "Human Resource" });
                myList.Add(new Employees() { name = "Asim", id = "14" + rand.Next(10, 99).ToString(), email = "asim@rushtub.com", contact = "0301-64322345", dept = "Quality Assurance" });
                myList.Add(new Employees() { name = "Dawar", id = "15" + rand.Next(10, 99).ToString(), email = "dawar@rushtub.com", contact = "0301-64322345", dept = "Quality Assurance" });
                return myList;
            }

        }

        protected void filterBtn_Click(object sender, EventArgs e)
        {
            var userInput = filter.Text;
            List<Employees> options = new List<Employees>();
            List<Employees> employees = Session["dispList"] as List<Employees>;
            foreach (Employees obj in employees)
            {
                if (((obj.dept).ToLower()).StartsWith((userInput).ToLower()))
                {
                    options.Add(obj);
                }
            }
            Session["dispList"] = options;
            Response.Redirect("WebForm1.aspx");


        }

        [WebMethod]
        public List<string> DisplayOptions(string userInput)
        {
            List<string> options = new List<string>();
            List<Employees> employees = Session["dispList"] as List<Employees>;
            foreach (var obj in employees)
            {
                if (((obj.dept).ToLower()).StartsWith(userInput.ToLower()))
                {
                    options.Add(obj.dept);
                }
            }
            return options;
        }
    }
}