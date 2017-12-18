using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyIService;
using Web.Commons;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest model)
        {
            JsonData data = new JsonData();
            if (model.Captcha!=TempData["Captcha"].ToString())
            {
                data.Status = "error";
                data.Msg = "验证码错误";
            }
            else
            {
                var b = userService.CheckLogin(model.UserName, model.Password);
                if (b)
                {
                    data.Status = "ok";
                    data.Msg = "登录成功";
                }
                else
                {
                    data.Status = "error";
                    data.Msg = "账号或者密码错误";
                }
            }
            return Json(data);
        }


        public IActionResult CreateCaptCha()
        {
            Random rd = new Random();
            string code = rd.Next(1000, 9999).ToString();
            TempData["CaptCha"] = code;
            Stream picstream = ImageFactory.BuildImage(code, 50, 100, 20, 10);
            return File(picstream, "image/png");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest model)
        {
            string code = (string)TempData["CaptCha"];
            if (code != model.Captcha)
            {
                return Json(new JsonData { Status = "error", Msg = "验证码错误" });
            }
            if (userService.GetUserName(model.UserName) != null)
            {
                return Json(new JsonData { Status = "error", Msg = "手机号已经存在" });
            }
            userService.AddNew(model.UserName, model.Password);
            return Json(new JsonData { Status = "ok" });
        }


    }
}
