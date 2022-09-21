namespace chat.domain
{
    public record User (int Id) : IUser
    {
        public string Name { get; set; }
        public string Birthday { get; set; }

        public bool IsAdult()
        {
            var isAdult = Utils.GetYearsDifference(DateTime.Parse(Birthday), DateTime.Now) >= 18;
            return isAdult;
        }
    }
    
}

