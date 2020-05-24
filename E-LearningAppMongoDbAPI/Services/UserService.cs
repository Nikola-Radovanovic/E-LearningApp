using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningAppMongoDbAPI.Models;
using MongoDB.Driver;

namespace E_LearningAppMongoDbAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IE_LearningDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        // GET /api/users
        public List<User> Get() =>
            _users.Find(u => true).ToList();

        // GET /api/users/{id}
        public User Get(string id) =>
            _users.Find(u => u.Id == id).FirstOrDefault();

        // POST
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        // PUT
        public void Update(string id, User user) =>
            _users.ReplaceOne(u => u.Id == id, user);

        //DELETE
        public void Remove(string id) =>
            _users.DeleteOne(u => u.Id == id);
    }
}
