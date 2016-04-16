using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DieuNguOrg.Controllers
{
    public class MediaController : Controller
    {
        // GET: Photos
        public ActionResult Photos()
        {
            return View();
        }

        // GET: Audio
        public ActionResult Audio()
        {
            return View();
        }

        // GET: Video
        public ActionResult Video()
        {
            return View();
        }
    }
}