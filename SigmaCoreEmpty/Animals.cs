using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace SigmaCoreEmpty
{
    public class Animals : Controller
    {
        // GET
        public IActionResult Index()
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            return Content($"controller: {controller} | action: {action}");
        }
        public IActionResult Add()
        {
            string eroor = "все гуд";
            var name = RouteData.Values["name"].ToString();
            var weight = RouteData.Values["weight"].ToString();
            var height = RouteData.Values["height"].ToString();
            Repository _repository = new Repository(new SqlConnection());
            try
            {
                _repository.AddAnimals(name, Convert.ToDecimal(weight), Convert.ToDecimal(height));
            }
            catch (Exception e)
            {
                eroor = e.Message;
            }
            
            return Content($"name: {name} | weight: {weight} | height: { height} | error: {eroor}");
        }
    }
}