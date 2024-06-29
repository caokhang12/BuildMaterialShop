using BMShop.Areas.Admin.Models;
using BMShop.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                switch (result)
                {
                    case 1:
                        var user = dao.GetById(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = model.UserName;
                        userSession.UserID = user.ID;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Tài khoản đang bị khóa");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Mật khẩu sai");
                        break;
                    case -3:
                        ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                        break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                        break;
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            return Redirect("Index");
        }
    }
}