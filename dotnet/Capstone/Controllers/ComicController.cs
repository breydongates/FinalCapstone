using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComicsDAO comicsDAO;

        public ComicsController(IComicsDAO dao)
        {
            comicsDAO = dao;
        }

        [HttpPost]
        public ActionResult AddComicToCollection (Comic comic)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            Comic result = comicsDAO.AddComicToCollection(comic, comic.CollectionId, userId);

            return Created("/comics", result);


           
        } 
    }
}
