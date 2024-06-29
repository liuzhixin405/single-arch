using Project.Base.Model;

namespace ADM001_User.Model
{
    public class User:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
