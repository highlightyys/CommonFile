using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class EditUser : System.Web.UI.Page
    {
        public User user1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + "/UserInfo.xlsx";
            if (!IsPostBack) //展示用户信息
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    List<User> users = ShowInfo.users;
                    foreach (User user in users)
                    {
                        if (user.id == id)
                        {
                            user1 = user;
                        }
                    }
                }
            }
            else //保存用户信息
            {
                User user = new User();
                user.id = Convert.ToInt32(Request.Form["id"]);
                user.name = Request.Form["username"];
                int age = 0;
                int.TryParse(Request.Form["age"], out age);
                user.age = age;
                user.gender = Request.Form["gender"];
                user.phone = Request.Form["phone"];
                user.address = Request.Form["address"];
                user.nationality = Request.Form["nationality"];

                //在list中替换出该user信息
                List<User> users = ShowInfo.users;
                foreach (User u in users)
                {
                    if (u.id == user.id)
                    {
                        ShowInfo.users.Remove(u);
                        ShowInfo.users.Add(user);
                        break;
                    }
                }
                UpdateOneRow.UpdateRow(user,path);

                Response.Redirect("ShowInfo.aspx");
            }
        }
    }
}