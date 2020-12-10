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

        public ActionResult<Comic> AddComicToCollection (Comic comic, int collectionId)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            ActionResult<Comic> result = comicsDAO.AddComicToCollection(comic, collectionId, userId);

            return Created("/comics", result);


           
        } 
    }
}
