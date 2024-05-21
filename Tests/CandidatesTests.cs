using candidateapi.Business;
using candidateapi.Controllers;
using candidateapi.IRepository;
using candidateapi.Models;
using FakeItEasy;
using System.Threading.Tasks.Dataflow;

namespace candidates.Tests
{
    public class CandidatesTests
    {
        [Fact]
        public void addOrUpdateCandidatesTest()
        {

            var dataStore = A.Fake<ICandidateRepository>();
            var controller = new CanidateController(dataStore);

            // Act
            // Example: Add a candidate and check the response
            var candidate = new Candidate
            {
                Id = 1,
                firstName = "John",
                lastName = "Doe",
                phoneNumber = 1234567890,
                Email = "",
                timeToCall = DateTime.Now,
                linkedinUrl = "http://linkedin.com/in/johndoe",
                githubUrl = "http://github.com/johndoe",
                freeTextComment = "A great candidate!"
            };
            var result = controller.updateCandidate(candidate);

            // Assert
            A.CallTo(() => dataStore.addOrupdateData(candidate)).MustHaveHappened();

        }
    }
}