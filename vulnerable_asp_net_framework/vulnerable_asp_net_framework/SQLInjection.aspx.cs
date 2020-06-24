using System;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;
using System.Data.SQLite;
using System.Text.Encodings.Web;

namespace vulnerable_asp_net_framework
{
    public partial class SQLInjection : Page
	{
        TextEncoder jsEncode = new TextEncoder();

        protected void Page_Load(object sender, EventArgs e)
		{
            string name = ParamUtils.GetParam(Request, "name");
            string pw = ParamUtils.GetParam(Request, "pw");
            string res = "";

            if (name.Length > 0)
            {
                var command = new SQLiteCommand(string.Format("SELECT * FROM users WHERE name = '{0}' and pw = '{1}'",
                    name, pw), DatabaseUtils._con);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res += reader["name"].ToString();
                    }

                }

                ParamUtils.PrintOut(SQLResults,"Successfully logged in as " + jsEncode.Encode(res));
            }

           if (res.Length == 0)
              ParamUtils.PrintOut(SQLResults, "Please login by providing a valid username and password");

        }
	}
}
