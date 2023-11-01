using Microsoft.AspNetCore.Mvc;
using SchoolFrom.Model;
using SchoolFrom.Service;

namespace SchoolFrom.Controllers
{
    [ApiController]
    public class InsertController : Controller
    {
        private readonly DataBaseMethods dataBaseMethods;
        [HttpPost]
        [Route("InsertUser")]
        public bool InsertCandidate(Candidate _model) {
            if (dataBaseMethods.GetAllCandidates().Result.Find(name => name.Name_SubName == _model.Name_SubName) != null) {
                return false;
            }
            dataBaseMethods.InsertCandidate(_model);
            return true;
        }
    }
}
