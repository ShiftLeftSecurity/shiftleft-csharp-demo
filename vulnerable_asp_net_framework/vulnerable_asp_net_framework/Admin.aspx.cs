using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using vulnerable_asp_net_core.Utils;
using System.Text.Encodings.Web;

namespace vulnerable_asp_net_framework
{
	public partial class Admin : Page
	{
        TextEncoder jsEncode = new TextEncoder();

        protected void Page_Load(object sender, EventArgs e)
		{
            string id = ParamUtils.GetParam(Request,"id");
            if (id.Length == 0)
                id = "0";
 
            if (id != "0")
            {
                var command = new SQLiteCommand($"DELETE FROM users WHERE id = {id}",
                    DatabaseUtils._con);

                if (command.ExecuteNonQuery() > 0)
                {
                    ParamUtils.PrintOut(AdminResults,"Deleted user with " + jsEncode.Encode(id));
                }
                else
                {
                    ParamUtils.PrintOut(AdminResults, string.Empty);
                }
            }
        }
	}
}