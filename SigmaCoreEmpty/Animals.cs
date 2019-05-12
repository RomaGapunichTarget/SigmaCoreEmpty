using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SigmaCoreEmpty.Models;

namespace SigmaCoreEmpty
{
    [ApiController]
    [Route("api/[controller]")]
    public class Animals : ControllerBase
    {
       
        private List<GenarateAnimals> lstAnimalses = GenarateAnimals.lstAnimals(100);
        // GET: /<controller>/
        // GET
        //public IActionResult Index()
        //{
        //    var controller = RouteData.Values["controller"].ToString();
        //    var action = RouteData.Values["action"].ToString();
        //    return Content($"controller: {controller} | action: {action}");
        //}
        //public IActionResult Add()
        //{
        //    string eroor = "все гуд";
        //    var name = RouteData.Values["name"].ToString();
        //    var weight = RouteData.Values["weight"].ToString();
        //    var height = RouteData.Values["height"].ToString();
        //    Repository _repository = new Repository(new SqlConnection());
        //    try
        //    {
        //        _repository.AddAnimals(name, Convert.ToDecimal(weight), Convert.ToDecimal(height));
        //    }
        //    catch (Exception e)
        //    {
        //        eroor = e.Message;
        //    }

        //    return Content($"name: {name} | weight: {weight} | height: { height} | error: {eroor}");
        //}
        [HttpGet("{id?}")]
        public IActionResult Get([FromRoute] int? id)
        {
            var animal = lstAnimalses.FirstOrDefault(animals => animals.Id == id);
            if (animal != null)
            {
                return new JsonResult(animal);
            }

                return NotFound();

        }

        public IActionResult Get()
        {
            if (lstAnimalses.Count > 0)
            {
                return new JsonResult(lstAnimalses);
            }

            return NotFound();

        }

        /// <summary>
        /// Делал через postman
        /// </summary>
        /// <param name="id">1</param>
        /// <param name="genarate">{"name":"Zebra","id":1,"weigth":1.0,"height":79.0}</param>
        /// <returns></returns>
        [HttpPut("{id?}")]
        public IActionResult Put([FromRoute] int? id,GenarateAnimals genarate)
        {
            var animal = lstAnimalses.FirstOrDefault(animals => animals.Id == id);
            if (animal != null)
            {
                genarate.Id = (int)id;
                lstAnimalses.Remove(animal);
                lstAnimalses.Add(genarate);
                return new JsonResult(genarate);
            }

            return NotFound();

        }

        /// <summary>
        /// Просто удалялю через постмен по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id?}")]
        public IActionResult Delete([FromRoute] int? id)
        {
            var animal = lstAnimalses.FirstOrDefault(animals => animals.Id == id);
            if (animal != null)
            {
                lstAnimalses.Remove(animal);
                return new JsonResult(lstAnimalses);
            }

            return NotFound();

        }

    }
}