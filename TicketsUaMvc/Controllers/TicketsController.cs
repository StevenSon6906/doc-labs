using Microsoft.AspNetCore.Mvc;
using TicketsUaMvc.Models;
using TicketsUaMvc.Services;

namespace TicketsUaMvc.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _service;

        public TicketsController(TicketService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var tickets = _service.GetAll();
            return View(tickets);
        }

        public IActionResult Details(int id)
        {
            var ticket = _service.GetById(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _service.Add(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            var ticket = _service.GetById(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _service.Update(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public IActionResult Delete(int id)
        {
            var ticket = _service.GetById(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}