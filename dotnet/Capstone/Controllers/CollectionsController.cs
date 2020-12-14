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
            List<Collection> result = collectionDAO.GetAllPublicCollections();

            return Ok(result);
        }

        [HttpGet("user")]
        public ActionResult<List<Collection>> GetAllCollectionsByUserId()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            List<Collection> result = collectionDAO.GetCollectionsByUserId(userId);

            return Ok(result);
        }

        [HttpGet("{collectionId}")]

        public ActionResult GetNumberOfComicsInCollection(int collectionId)
        {
            int numberOfComics = collectionDAO.GetNumberOfComicsInCollection(collectionId);            
            
            return Ok(numberOfComics);      
            
            
        }

        [HttpPost("statsRequest/publisher")]
        
        public ActionResult GetNumOfComicsByPublisher (StatRequest statRequest)
        {
            List<Comic> listOfComics = collectionDAO.GetNumByPublisherInCollection(statRequest);

            return Ok(listOfComics);
        }

        [HttpPost("statsRequest/character")]

        public ActionResult GetNumOfComicsByCharacter (StatRequest statRequest)
        {
            List<Comic> listOfComics = collectionDAO.GetNumByCharacterInCollection(statRequest);

            return Ok(listOfComics);
        }
        
        [HttpPost("allComicsStats/publisher")]
        public ActionResult GetStatsForAllComicsByPublisher(StatRequest statRequest)
        {
            List<Comic> listOfComics = collectionDAO.GetAllComicsByPublisher(statRequest);

            return Ok(listOfComics);
        }

        [HttpPost("allComicsStats/character")]
        public ActionResult GetStatsForAllComicsByCharacter(StatRequest statRequest)
        {
            List<Comic> listOfComics = collectionDAO.GetAllComicsByCharacter(statRequest);

            return Ok(listOfComics);
        }

        [HttpGet("allComicsStats/count")]
        public ActionResult GetsCountOfAllComicsInCollections()
        {
            List<Comic> listOfComics = collectionDAO.GetCountOfAllComics();

            return Ok(listOfComics);
        }
    }
}
