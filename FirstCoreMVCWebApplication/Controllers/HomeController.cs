using FirstCoreMVCWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository? _studentRepository=null;
        private readonly SomeOtherService? _someOtherService=null;

        public HomeController(ILogger<HomeController> logger,IStudentRepository studentRepository,SomeOtherService someOtherService)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _someOtherService = someOtherService;
        }

        public JsonResult Index()
        {
            List<Student>? allStudentDetails = _studentRepository?.GetAllStudent();
            _someOtherService?.SomeMethod();

            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _studentRepository?.GetStudentById(Id);
            _someOtherService?.SomeMethod();
            return Json(studentDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
