namespace candidateapi.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int phoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime timeToCall { get; set; }
        public string linkedinUrl { get; set; }
        public string githubUrl { get; set; }
        public string freeTextComment { get; set; }
    }
}
