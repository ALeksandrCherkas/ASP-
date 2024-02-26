namespace WebApplication1
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Email { get; set; }
        public User()
        {

        }
        public User(int id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }
        public string GetUserInfo()
        {
            return $"<td>{Name}</td><td>{Age}</td><td>{Email}</td>";
        }
    }

}
