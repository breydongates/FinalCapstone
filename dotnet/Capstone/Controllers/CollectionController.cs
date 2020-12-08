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
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionDAO collectionDAO;

        public CollectionController(ICollectionDAO dao)
        {
            collectionDAO = dao;
        }

        [HttpPost]
        public ActionResult<Collection> CreateCollection(Collection newCollection)
        {   
            return Created(collectionDAO.AddCollection(newCollection)); 
        }
    }
}
