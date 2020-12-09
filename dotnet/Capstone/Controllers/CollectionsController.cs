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
            Collection collection = collectionDAO.AddCollection(newCollection);
            return Created("/collections", collection); 
        }

        [HttpGet]
        public ActionResult<List<Collection>> GetAllPublicCollections()
        {
            ActionResult<List<Collection>> result = collectionDAO.GetAllPublicCollections();

            return Ok(result);
        }

        [HttpGet("/{userId}")]
        public ActionResult<List<Collection>> GetAllCollectionsByUserId(int username)
        {
            ActionResult<List<Collection>> result = collectionDAO.GetCollectionsByUsername(username);

            return Ok(result);
        }
    }
}
