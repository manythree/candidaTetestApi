using candidateapi.Models;

namespace candidateapi.IRepository
{
    public interface ICandidateRepository
    {
       public bool addOrupdateData(Candidate candidate);
       public List<Candidate> getAllCandidates();

    }
}
