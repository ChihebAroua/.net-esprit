using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {

        private readonly IServiceFlight serviceFlight;
        private readonly IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight,IServicePlane servicePlane )
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }
        // GET: FlightController
        public ActionResult Index(DateTime ?filter)
        {

            if (filter== null)
            {
                return View(serviceFlight.GetAll().ToList());
            }
            else
            {
                return View(serviceFlight.GetAll().ToList().Where(f => f.FlightDate.Date == filter.Value.Date));

            }
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
           
            return View(serviceFlight.GetById(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
           var liste= servicePlane.GetAll().ToList();
            ViewBag.Planes = new SelectList(liste,"PlaneId", "ManufactureDate");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile pilote_image)
        {
              
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","image",pilote_image.FileName);
                var stream = new FileStream(path,FileMode.Create);
                pilote_image.CopyTo(stream);
                flight.pilote = pilote_image.FileName;
                serviceFlight.Add(flight);
                serviceFlight.Commit();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Flight flight, IFormFile pilote_image)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", pilote_image.FileName);
                var stream = new FileStream(path, FileMode.Create);
                pilote_image.CopyTo(stream);
                flight.pilote = pilote_image.FileName;
                serviceFlight.Update(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Flight filght)
        {
            try
            {
                serviceFlight.Delete(serviceFlight.GetById(id));
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
