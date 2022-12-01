using AutoMapper;
using Business;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InCampusStudentController : ControllerBase
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;



        public InCampusStudentController(IStudentService studentService, 
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InCampusStudentDTO>>> GetInCampusStudent()
        {

            var inCampusStudent = await _studentService.FetchInCampusStudentAsync();

            // with manual mapping
            //var InCampusStudentData =
            //    inCampusStudent.Select(e => new InCampusStudentDTO()
            //    {
            //        Id = e.Id,
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        Level = e.Level,
            //        AttendedLessons = e.AttendedLessons,
            //        InitialTuitionFee = e.InitialTuitionFee,
            //        MinimumScholarShipGiven = e.MinimumScholarShipGiven,
            //        SuggestedUnits = e.SuggestedUnits,
            //        YearsOfStudy = e.YearsOfStudy
            //    });


            var InCampusStudentData =
               _mapper.Map<IEnumerable<InCampusStudentDTO>>(inCampusStudent);


            return Ok(InCampusStudentData);
        }

    }
}