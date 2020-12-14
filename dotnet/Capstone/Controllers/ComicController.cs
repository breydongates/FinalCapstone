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

        [HttpGet("{collectionId}")]
        public ActionResult ViewComicsByCollection (int collectionId)
        {
            List<Comic> result = comicsDAO.GetComicsByCollectionId(collectionId);

            return Ok(result);

        }

        [HttpPost]
        public ActionResult AddComicToCollection (Comic comic)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            Comic result = comicsDAO.AddComicToCollection(comic, comic.CollectionId, userId);

            return Created("/Comics", result);

        } 
    }
}
