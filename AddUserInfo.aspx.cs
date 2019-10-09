using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3;
namespace WebApplication3
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                User user = new User();
                user.name = Request.Form["username"];
                int age=0;
                int.TryParse(Request.Form["age"], out age);
                user.age = age;
                //user.age = Convert.ToInt32(Request.Form["age"]);
                user.gender = Request.Form["gender"];
                user.phone = Request.Form["phone"];
                user.address = Request.Form["address"];
                user.nationality = Request.Form["nationality"];
                List<User> users = ShowInfo.users;
                int maxid = 0;
                if(users == null)
                {
                    Response.Redirect("ShowInfo.aspx");
                    return;
                }
                foreach (User u in users)
                {
                    if (u.id > maxid)
                    {
                        maxid = u.id;
                    }
                }
                user.id = maxid + 1;
                users.Add(user);
                string path = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + "/UserInfo.xlsx";
                AddOneRow.AddRow(user,path);

                Response.Redirect("ShowInfo.aspx");
                
            }
           
        }
    }
}