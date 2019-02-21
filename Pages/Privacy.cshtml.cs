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
    public class PrivacyModel : PageModel
    {
        
        private IMongoCollection<Users> _users;
        private IConfiguration _config;

        public PrivacyModel(IConfiguration config)
        {
            _config = config;
        }
        public void OnGet()
        {
            
            var client = new MongoClient(_config.GetConnectionString("UsersDb"));
            var database = client.GetDatabase("UsersDb");
            _users = database.GetCollection<Users>("Users");

            Users userOne = new Users {
                Name= "Edmar"
            };
            _users.InsertOne(userOne);
        }
    }
}