using Linkdout.DAL;
using Linkdout.Moodels;

namespace Linkdout.Services
{
    public class UserService
    {
        private DataLayer db;
        public UserService(DataLayer _db) { db = _db; }

        public async Task <UserModel> GetUserById(int id)
        {
            return db.Users.Find(id);
        }
        public async Task <int> Register(UserModel user)
        {
             db.Users.Add(user);
            db.SaveChanges();
            UserModel created = db.Users.FirstOrDefault(u => u.username == user.username);
            return created.Id;
        }
    }
}
