using P140_API.Entities;

namespace P140_API.Exceptions
{
    public class GroupIsNotFoundException:Exception
    {
        public GroupIsNotFoundException(string message):base(message)
        {
            
        }
    }
}
