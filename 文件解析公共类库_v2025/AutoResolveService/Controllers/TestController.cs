using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace AutoResolveService.Controllers
{
    public class TestController : Controller
    {
        JKY.Models24.AutoReeolveMethod24 amMethod = new JKY.Models24.AutoReeolveMethod24();
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            JKY.Models24.AutoReeolveCollection24 model = new JKY.Models24.AutoReeolveCollection24();
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                return Content("上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。");
            }
            else
            {
                //文件大小不为0
                XmlDocument xml = new XmlDocument();
                xml.Load(file.InputStream);
                model = amMethod.SaveXmlToDB(xml);
            }
            return Content(model.ExsultMessage);
        }
    }
}
