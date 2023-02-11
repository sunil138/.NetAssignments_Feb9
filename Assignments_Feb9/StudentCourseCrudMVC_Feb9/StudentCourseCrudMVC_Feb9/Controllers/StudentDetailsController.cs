using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseCrudMVC_Feb9.Models;

namespace StudentCourseCrudMVC_Feb9.Controllers
{
    public class StudentDetailsController : Controller
    {
        private readonly StudentContext _context;

        public StudentDetailsController(StudentContext context)
        {
            _context = context;
        }

        // GET: StudentDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentDetails.ToListAsync());
        }

        // GET: StudentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentDetails == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return View(studentDetail);
        }

        // GET: StudentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Age,Address,CourseId")] StudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDetail);
        }

        // GET: StudentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentDetails == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }
            return View(studentDetail);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Age,Address,CourseId")] StudentDetail studentDetail)
        {
            if (id != studentDetail.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDetailExists(studentDetail.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentDetail);
        }

        // GET: StudentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentDetails == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return View(studentDetail);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentDetails == null)
            {
                return Problem("Entity set 'StudentContext.StudentDetails'  is null.");
            }
            var studentDetail = await _context.StudentDetails.FindAsync(id);
            if (studentDetail != null)
            {
                _context.StudentDetails.Remove(studentDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDetailExists(int id)
        {
          return _context.StudentDetails.Any(e => e.StudentId == id);
        }
    }
}
