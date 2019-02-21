using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace bootcamp_names.Pages
{
    public class IndexModel : PageModel
    {

        private IMongoCollection<Users> _users;
        private IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }
        public string Users { get; private set; } = "PageModel in C#";

        public async Task OnGet()
        {

            var client = new MongoClient(_config.GetConnectionString("UsersDb"));
            var database = client.GetDatabase("UsersDb");
            _users = database.GetCollection<Users>("Users");

            // Users userOne = new Users {
            //     Name= "Edmar"
            // };
            // _users.InsertOne(userOne);

            string myName = "Test";           
            var iterator = await _users.Find(p => true).ToListAsync();
            foreach(var user in iterator){
                myName = user.Name;
            }
            Users += myName;
        }
    }
}