using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationMinistry_TopLevelManagement.Controllers
{
    [ApiController]
    [Route("api/promotioneligibilities")]
    public class PromotionEligibilitiesController : ControllerBase
    {
        [HttpGet("{studentId}")]
        public IActionResult InCampusStudentIsEligibleForPromotion(Guid studentId)
        {
            // For demo purposes, Ali Kolahdoozan (id = 72f2f5fe-e50c-4966-8420-d50258aefdcb)
            // is eligible for promotion, other employees aren't
            if (studentId == Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"))
            {
                return Ok(new { EligibleForPromotion = true });
            }

            return Ok(new { EligibleForPromotion = false });
        }
    }
}
