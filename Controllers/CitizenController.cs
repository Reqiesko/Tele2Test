using Microsoft.AspNetCore.Mvc;

namespace TeleTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private static List<Сitizen> citizens = new List<Сitizen>();

        [HttpGet]
        public async Task<ActionResult<List<Сitizen>>> GetAll(int page = 1, string filter = "all") // Filters: "male", "female", "all".
        {
            if (page < 1) 
                throw new ArgumentException("The page number cannot be less than 1.");
            HttpClient httpClient = new HttpClient();
            citizens = httpClient.GetFromJsonAsync<List<Сitizen>>("http://testlodtask20172.azurewebsites.net/task").Result;
            var pageResults = 3f;
            var pageCount = Math.Ceiling(citizens.Count / pageResults);
            var someCitizens = citizens.Where(x => x.Sex == filter || filter == "all")
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .ToList();
           // someCitizens.Add(new Сitizen
           // {
           //     Id = "1",
           //     Name = "Stan Lee",
           //     Sex = "male"
           //     Age = (int)already dead
           // });
            CitizenResponse response = new CitizenResponse
            {
                Сitizens = someCitizens,
                CurrentPages = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Сitizen>> GetCitizen(string id)
        {
            var citizen = citizens.Find(x => x.Id.Equals(id));
            if (citizen == null)
                return BadRequest("Citizen not Found.");
            return Ok(citizen);
        }

        [HttpPost]
        public async Task<ActionResult<List<Сitizen>>> AddCitizen(Сitizen сitizen)
        {
            citizens.Add(сitizen);
            return Ok(citizens);
        }
    }
}
