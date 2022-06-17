using System;

namespace Hermes
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string userType { get; set; }
        public string profilePicture { get; set; }
        public DateTime created { get; set; }
    }
}
