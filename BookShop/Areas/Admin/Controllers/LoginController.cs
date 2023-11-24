using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Models.TestDBEntities db = new Models.TestDBEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.user obj)
        {
            if(ModelState.IsValid)
            {
                Models.user check = db.users.FirstOrDefault(m => m.user_name == obj.user_name && m.pass_word == obj.pass_word);
                if(check == null)
                {
                    //Đăng nhập thất bại
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
                else
                {
                    //Đăng nhập thành công
                    //C1 lưu trạng thái vào session
                    //Session["user"]=check;
                    //C2 Cookie
                    FormsAuthentication.SetAuthCookie(check.user_name, false);
                    if (Request.QueryString["ReturnUrl"]==null || Request.QueryString["ReturnUrl"] == "")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]);
                    }
                }
            }
            return View(obj);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}