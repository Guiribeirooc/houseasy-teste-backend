namespace HouseasyModel.DTO
{
    public class LoginResponse
    {
        public string User { get; set; } = "";
        public bool Authenticated { get; set; }
        public string Token { get; set; } = "";
        public DateTime? ExpirationDate { get; set; }
    }
}