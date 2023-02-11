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
    public class CourseDetailsController : Controller
    {
        private readonly StudentContext _context;

        public CourseDetailsController(StudentContext context)
        {
            _context = context;
        }

        // GET: CourseDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.CourseDetails.ToListAsync());
        }

        // GET: CourseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseDetails == null)
            {
                return NotFound();
            }

            var courseDetail = await _context.CourseDetails
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseDetail == null)
            {
                return NotFound();
            }

            return View(courseDetail);
        }

        // GET: CourseDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,Fee,Result")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseDetail);
        }

        // GET: CourseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseDetails == null)
            {
                return NotFound();
            }

            var courseDetail = await _context.CourseDetails.FindAsync(id);
            if (courseDetail == null)
            {
                return NotFound();
            }
            return View(courseDetail);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,Fee,Result")] CourseDetail courseDetail)
        {
            if (id != courseDetail.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDetailExists(courseDetail.CourseId))
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
            return View(courseDetail);
        }

        // GET: CourseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseDetails == null)
            {
                return NotFound();
            }

            var courseDetail = await _context.CourseDetails
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseDetail == null)
            {
                return NotFound();
            }

            return View(courseDetail);
        }

        // POST: CourseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseDetails == null)
            {
                return Problem("Entity set 'StudentContext.CourseDetails'  is null.");
            }
            var courseDetail = await _context.CourseDetails.FindAsync(id);
            if (courseDetail != null)
            {
                _context.CourseDetails.Remove(courseDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDetailExists(int id)
        {
          return _context.CourseDetails.Any(e => e.CourseId == id);
        }
    }
}
