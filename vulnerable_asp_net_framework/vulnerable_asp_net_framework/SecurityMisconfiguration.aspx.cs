using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text.Encodings.Web;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
	public partial class SecurityMisconfiguration : Page
	{
        TextEncoder jsEncode = new TextEncoder();

        protected void Page_Load(object sender, EventArgs e)
		{
            var command = new SQLiteCommand("SELECT * FROM user WHERE id = 10", DatabaseUtils._con);
            try
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string returnString = string.Empty;
                        returnString += $"Hello {reader["Name"]} ! ";
                        ParamUtils.PrintOut(SecurityMisconfigurationResults, jsEncode.Encode(returnString));
                    }
                    else
                    {
                        ParamUtils.PrintOut(SecurityMisconfigurationResults, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                ParamUtils.PrintOut(SecurityMisconfigurationResults, ex.Message);
            }
        }
	}
}