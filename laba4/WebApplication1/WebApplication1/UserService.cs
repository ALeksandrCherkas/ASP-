using System.Text;

namespace WebApplication1
{
    public class UserService
    {
        User user1;
        IConfiguration appConfig;
        public UserService(IConfiguration appConfig)
        {
            this.appConfig = appConfig;
        }
        public String GetUserProfile(int? id)
        {
            StringBuilder sb = new();
            sb.Append("<table>");
            foreach (var user in appConfig.GetSection("users").GetChildren())
            {
                User user1 = user.Get<User>();
                if (user1.Id == id)
                {
                    sb.Append("<tr>" + user1.GetUserInfo() + "</tr>");
                }
                if (id == null)
                {
                    id = 0;
                    if (user1.Id == id)
                    {
                        sb.Append("<tr>" + user1.GetUserInfo() + "</tr>");
                    }
                }
            };
            sb.Append("</table>");
            return sb.ToString();
        }
    }
}
