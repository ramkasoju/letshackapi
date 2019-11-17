using LetsHack.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LetsHack.Api.FireBase
{
    public class SampleTest
    {
        private const string DbUrl = "https://let-s-hack-7052b.firebaseio.com/";
        private const string UsersTable = "Users";
        private const string IdeasTable = "Ideas";

        public async Task TestAddUtility()
        {
            var fbUtil = new FireBaseUtility(DbUrl);

            var uses = await fbUtil.GetAllAsync<User>(UsersTable);

            var user = new User
            {
                Id = 1,
                Name = "Goutham",
                Email = "gousir@hackathon.com",
                NickName = "Leader",
                IsAdmin = true
            };

            var idea = new Hack
            {
                Id = 1,
                Title = "Hackathon Utility",
                Owner = user,
                Description = @"Let's Hack, please contact gousir for more details",
                Participants = new List<User> { user }
            };

            await AddUser();
            await AddIdea();

            async Task AddUser()
            {
                await fbUtil.AddAsync(UsersTable, user);
            }

            async Task AddIdea()
            {
                await fbUtil.AddAsync(IdeasTable, idea);
            }
        }

        public async Task TesGetUtility()
        {
            var fbUtil = new FireBaseUtility(DbUrl);
            var users = await fbUtil.GetAllAsync<User>("Users");
            var ideas = await fbUtil.GetAllAsync<Hack>("Ideas");

        }
    }
}
