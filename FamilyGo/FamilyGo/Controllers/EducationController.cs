using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FamilyGo.Controllers
{
    public class EducationController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult GetJsonFromFile(string path)
        {
            try
            {
                string filepath = Server.MapPath(path);
                string json = GetFileJson(filepath);
                return Content(json);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        //具体读取json文件数据
        public string GetFileJson(string filepath)
        {
            string json = string.Empty;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312")))
                {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }
    }
}