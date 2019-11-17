using LetsHack.Api.FireBase;
using LetsHack.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsHack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LetsHackController : ControllerBase
    {
        private readonly FireBaseUtility _firebaseUtility = new FireBaseUtility(DbUrl);

        private readonly ILogger<LetsHackController> _logger;

        public LetsHackController(ILogger<LetsHackController> logger)
        {
            _logger = logger;
        }

        private const string DbUrl = "https://let-s-hack-7052b.firebaseio.com/";
        private const string UsersTable = "Users";
        private const string HacksTable = "Hacks";
        private const string CommentsTable = "Comments";


        //public async Task Get()
        //{
        //    //await _firebaseUtility.AddAsync<User>(UsersTable, new User
        //    //{
        //    //    Id = 100,
        //    //    Name = "Goutham",
        //    //    Email = "gousir@nq.com",
        //    //    IsAdmin = true,
        //    //    NickName = "Sir",
        //    //    Password = "shhh"
        //    //});

        //    //await _firebaseUtility.AddAsync<User>(UsersTable, new User
        //    //{
        //    //    Id = 101,
        //    //    Name = "Ramya",
        //    //    Email = "ramya@nq.com",
        //    //    IsAdmin = false,
        //    //    NickName = "ramya",
        //    //    Password="shhh"
        //    //});

        //}

        [HttpGet, Route("users")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _firebaseUtility.GetAllAsync<User>(UsersTable);
        }

        [HttpGet, Route("user/{id}")]
        public async Task<User> GetUser(int id)
        {
            var users = await _firebaseUtility.GetAllAsync<User>(UsersTable);
            return users.FirstOrDefault(u => u.Id == id);
        }

        [HttpPost, Route("user")]
        public async Task PostUser(User user)
        {
            await _firebaseUtility.AddAsync<User>(UsersTable, user);
        }

        [HttpGet, Route("hacks")]
        public async Task<IEnumerable<Hack>> GetHacks()
        {
            return await _firebaseUtility.GetAllAsync<Hack>(HacksTable);
        }

        [HttpGet, Route("hack/{hackId}")]
        public async Task<User> GetHack(int hackId)
        {
            var hacks = await _firebaseUtility.GetAllAsync<User>(UsersTable);
            return hacks.FirstOrDefault(h => h.Id == hackId);
        }

        [HttpPost, Route("hack")]
        public async Task PostHack(Hack hack)
        {
            await _firebaseUtility.AddAsync<Hack>(UsersTable, hack);
        }

        [HttpGet, Route("comments/{hackId}")]
        public async Task<IEnumerable<Comment>> GetCommentsAsync(int hackId)
        {
            var allComments = await _firebaseUtility.GetAllAsync<Comment>(CommentsTable);
            return allComments.Where(c => c.HackId == hackId);
        }

        [HttpPost, Route("comment")]
        public async Task AddCommentAsync(Comment comment)
        {
            await _firebaseUtility.AddAsync<Comment>(CommentsTable, comment);
        }

    }
}
