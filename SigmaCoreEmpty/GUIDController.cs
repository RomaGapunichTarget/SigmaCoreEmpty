using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SigmaCoreEmpty.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SigmaCoreEmpty
{
    [ApiController]
    [Route("api/test")]
    public class GuidController : Controller
    {
        AdoNetRepository repository = new AdoNetRepository(new SqlConnection());
        // GET: /<controller>/
        
        [Route("start")]
        [HttpGet]
        public IActionResult Indexs()
        {
            
            List<GenarateAnimals> lstAnimalses = new List<GenarateAnimals>();
            lstAnimalses = repository.SelectAnimals();
            return View(lstAnimalses);
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}
