using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Data;
using Data.Mappings;
using Data.Queries;
using Domain.Entities;
using Highway.Data;
using Highway.Data.Repositories;
using UI.Properties;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController()
        {
            var driverEd = new DriverEd(Settings.Default.Connection);
            var context = new DomainContext<DriverEd>(driverEd);
            _repository = new DomainRepository<DriverEd>(context, driverEd);
        }

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult Index()
        {
            var courses = _repository.Find(new AllCourses());
            return View(courses.ToList());
        }

        public ActionResult About()
        {
            var vetInstructors = _repository.Find(new InstructorsByCourseCount(10));
            return View(vetInstructors.ToList());
        }

        public ActionResult Details(int courseId)
        {
            var course = _repository.Find(new GetById<int, Course>(courseId));
            return View(course);
        }

        public ActionResult Details(string courseName)
        {
            var course = _repository.Find(new CourseByName(courseName));
            return View(course);
        }

        public ActionResult Delete(int courseId)
        {
            _repository.Execute(new DeleteCourse(courseId));
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    
}