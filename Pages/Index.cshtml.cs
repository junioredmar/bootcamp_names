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
        public List<Users> Users { get; private set; } = new List<Users>();

        public async Task OnGet()
        {

            var client = new MongoClient(_config.GetConnectionString("UsersDb"));
            var database = client.GetDatabase("UsersDb");
            _users = database.GetCollection<Users>("Users");

           //  Users userOne = new Users {
              //  FirstName= "Edmar",
                //LastName = "Junior"
                
             //};
             //_users.InsertOne(userOne);

            List<Users> listResult = new List<Users>();
            
            var iterator = await _users.Find(p => true).ToListAsync();
            foreach(var user in iterator){
                listResult.Add(new Users {
                     FirstName = user.FirstName,
                     LastName = user.LastName,
                     Nationality = user.Nationality,
                     Age = user.Age,
                     Id = user.Id
                         
                });
            }
            Users = listResult;
        }
        
        
        public IActionResult OnGetSelectById(string id)
        {
            var data =  _users.Find(id).ToListAsync();

            return new JsonResult(data);
        }
    }
}