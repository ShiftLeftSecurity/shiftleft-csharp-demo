using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace netcoreWebapi.Controllers
{
    public class PatientController : Controller
    {
        private readonly LibraryContext _objContext;

        private readonly ILogger _logger;

        public PatientController(ILoggerFactory loggerFactory)
        {
            _objContext = new LibraryContext();
            _logger = loggerFactory.CreateLogger("Controller.PatientController");
        }

        public ActionResult Index()
        {
            var patients = _objContext.Patients.ToList();
            return View(patients);
        }

        public ViewResult Details(int id)
        {
            Patient patient = _objContext
                .Patients
                .Where(x => x.PatientId == id).SingleOrDefault();
            return View(patient);
        }

        public ActionResult Create()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            _objContext.Patients.Add(patient);
            _objContext.SaveChanges();
            _logger.LogInformation("Creating patient with id: {0}", patient.PatientId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Patient patient = _objContext
                .Patients
                .Where(x => x.PatientId == id).SingleOrDefault();
            _logger.LogInformation("Editing patient with id: {0}", patient.PatientId);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient model)
        {
            Patient patient = _objContext
                .Patients
                .Where(x => x.PatientId == model.PatientId).SingleOrDefault();

            if (patient != null)
            {
                _objContext.Entry(patient).CurrentValues.SetValues(model);
                _objContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Patient patient = _objContext.Patients.Find(id);
            _logger.LogInformation("Deleting patient with id: {0}", patient.PatientId);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Delete(int id, Patient model)
        {
            var patient = _objContext.Patients.Where(x => x.PatientId == id).SingleOrDefault();
            if (patient != null)
            {
                _objContext.Patients.Remove(patient);
                _objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
