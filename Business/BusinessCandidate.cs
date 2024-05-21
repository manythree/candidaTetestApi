using candidateapi.Controllers;
using candidateapi.Data;
using candidateapi.IRepository;
using candidateapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace candidateapi.Business
{
    public class BusinessCandidate:ICandidateRepository
    {
        AppDbContext _context;

        public BusinessCandidate( AppDbContext context)
        {
            _context = context;
        }


        public List<Candidate> getAllCandidates()
        {
            return _context.Candidats.ToList();
        }

        public bool addCandidate(Candidate candidate)
        {
            try
            {
                _context.Candidats.Add(candidate);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex) {
                return false;
            }
            
        }
        public bool updateCandidate(Candidate candidateToUpdate, Candidate candidate)
        {
            try
            {
                candidateToUpdate.firstName = candidate.firstName;
                candidateToUpdate.lastName = candidate.lastName;
                candidateToUpdate.phoneNumber = candidate.phoneNumber;
                candidateToUpdate.linkedinUrl = candidate.linkedinUrl;
                candidateToUpdate.githubUrl = candidate.githubUrl;// Update relevant properties
                candidateToUpdate.Email = candidate.Email;
                candidateToUpdate.freeTextComment = candidate.freeTextComment;
                candidateToUpdate.timeToCall = candidate.timeToCall;
                _context.Update(candidateToUpdate);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

       

        public bool addOrupdateData(Candidate candidate)
        {
            var candidateToUpdate = _context.Candidats.Where(x => x.Id == candidate.Id).FirstOrDefault();
            if (candidateToUpdate != null)
            {
                bool updateResult = this.updateCandidate(candidateToUpdate, candidate);
                return updateResult;
            }
            else
            {
                bool result = this.addCandidate(candidate);
                return result;
            }
        }
    }
}
