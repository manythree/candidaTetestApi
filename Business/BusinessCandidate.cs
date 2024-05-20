using candidateapi.Controllers;
using candidateapi.Data;
using candidateapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace candidateapi.Business
{
    public class BusinessCandidate
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
            _context.Candidats.Add(candidate);
            _context.SaveChanges();
            return true;
        }

        public bool updateData(Candidate candidate)
        {
            var candidateToUpdate = _context.Candidats.Where(x => x.Id == candidate.Id).FirstOrDefault();
            if (candidateToUpdate != null)
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
            return false;
        }


    }
}
