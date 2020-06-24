using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Extensions.Logging;

namespace ASPClient
{
    public partial class Default : System.Web.UI.Page
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("LocalLogger");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            int employeeId = int.Parse(EmployeeIDTextBox.Text);
            int salary = SalaryFor(employeeId);
            EmployeeSalaryLabel.Text = "The salary is: " + Convert.ToString(salary);        
            _logger.LogInformation("<from ASP page> employee with ID:{0} has salary:{1}", employeeId, salary);
        }

        private int SalaryFor(int id) { return 123;  }
    }
}