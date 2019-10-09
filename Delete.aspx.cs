using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            int id;
            string path = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + "/UserInfo.xlsx";
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                List<User> users = ShowInfo.users;
                foreach(User user in users)
                {
                    if(user.id == id)
                    {
                        ShowInfo.users.Remove(user);
                        DeleteOneRow.DeleteRow(id,path);
                        Response.Redirect("ShowInfo.aspx");
                    }
                }
            }
        }
    }
}