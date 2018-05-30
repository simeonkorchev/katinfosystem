using BusinessLogic;

namespace Presentation.Converters
{
    public class UserToGreetingConverter : ValueConverter<User, string>
    {
        protected override string Convert(User user) => $"Здравей, {user.Username}!";

        protected override User ConvertBack(string value)
        {
            return base.ConvertBack(value);
        }
    }
}
