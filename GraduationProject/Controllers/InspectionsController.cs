using GraduationProject.API.Data;
using GraduationProject.API.Data.Models;
using GraduationProject.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraduationProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class InspectionsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _environment;


        public InspectionsController(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> AddInspection([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("File is not selected or is empty.");
            }
            var randomFileName = Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(image.FileName);

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, randomFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            using (var httpClient = new HttpClient())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(fileStream), "image", image.FileName);

                    var response = await httpClient.PostAsync("http://167.99.131.165:3000/predict", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest("Failed to send file to the AI Model.");
                    }
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var predictionResult = JsonConvert.DeserializeObject<AIModelResult>(responseContent);


                    var tratment = _context.Treatments.FirstOrDefault(a => a.Key == predictionResult!.ClassName);

                    if (tratment == null)
                        return BadRequest("Failed to send file to the AI Model.");

                    var inspection = new Inspection
                    {
                        FileUrl = randomFileName,
                        TreatmentId = tratment.Id,
                        Date = DateTime.Now,
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    _context.Inspections.Add(inspection);
                    _context.SaveChanges();
                    var baseUrl = $"{Request.Scheme}://{Request.Host}";

                    var data = new InspectionDto
                    {
                        Id = inspection.Id,
                        Date = inspection.Date,
                        TreatmentContent = tratment.Content,
                        TreatmentKey = tratment.Key,
                        TreatmentTitle = tratment.Title,
                        ImageUrl = baseUrl + "/images/" + randomFileName
                    };

                    return Ok(data);

                }
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<InspectionDto>> GetInspectionHistory()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var data = _context.Inspections
                .Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .OrderByDescending(a => a.Id)
                .Select(a => new InspectionDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    TreatmentContent = a.Treatment!.Content,
                    TreatmentKey = a.Treatment!.Key,
                    TreatmentTitle = a.Treatment!.Title,
                    ImageUrl = baseUrl + "/images/" + a.FileUrl!
                }).ToList();

            return Ok(data);
        }
        [HttpGet]
        public ActionResult<IEnumerable<InspectionDto>> GetRecentlyInspection()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var data = _context.Inspections
               .Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
               .OrderByDescending(a => a.Id)
               .Take(3)
               .Select(a => new InspectionDto
               {
                   Id = a.Id,
                   Date = a.Date,
                   TreatmentContent = a.Treatment!.Content,
                   TreatmentKey = a.Treatment!.Key,
                   TreatmentTitle = a.Treatment!.Title,
                   ImageUrl = baseUrl + "/images/" + a.FileUrl!
               }).ToList();

            return Ok(data);
        }
    }
}
