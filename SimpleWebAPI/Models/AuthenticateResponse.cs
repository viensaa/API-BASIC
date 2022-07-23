namespace SampleWebAPI.Models
{
    public class AuthenticateResponse
    {
        private Domain.User user;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Domain.User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }

        //public AuthenticateResponse(Domain.User user, string token)
        //{
        //    this.user = user;
        //    Token = token;
        //}
    }
}