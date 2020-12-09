using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionDAO collectionDAO;
        

        public CollectionsController(ICollectionDAO dao)
        {
            collectionDAO = dao;
        }

        [HttpPost]
        public ActionResult<Collection> CreateCollection(Collection newCollection)
        {
            //this.User.Identity.Name
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            Collection collection = collectionDAO.AddCollection(newCollection, userId);
            return Created("/collections", collection); 
        }

        [HttpGet]
        public ActionResult<List<Collection>> GetAllPublicCollections()
        {
            ActionResult<List<Collection>> result = collectionDAO.GetAllPublicCollections();

            return Ok(result);
        }

        [HttpGet("/user")]
        public ActionResult<List<Collection>> GetAllCollectionsByUserId()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            ActionResult<List<Collection>> result = collectionDAO.GetCollectionsByUserId(userId);

            return Ok(result);
        }
    }
}
