using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIM_Project.Data;
using SIM_Project.Models;

namespace SIM_Project.Controllers
{
    public class CourseTeachOfTeachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseTeachOfTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseTeachOfTeachers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseTeachOfTeachers.Include(c => c.Course).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseTeachOfTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeachOfTeacher = await _context.CourseTeachOfTeachers
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseTeachOfTeacherID == id);
            if (courseTeachOfTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeachOfTeacher);
        }

        // GET: CourseTeachOfTeachers/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return View();
        }

        // POST: CourseTeachOfTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseTeachOfTeacherID,CourseID,TeacherID")] CourseTeachOfTeacher courseTeachOfTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTeachOfTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseTeachOfTeacher.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseTeachOfTeacher.TeacherID);
            return View(courseTeachOfTeacher);
        }

        // GET: CourseTeachOfTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeachOfTeacher = await _context.CourseTeachOfTeachers.FindAsync(id);
            if (courseTeachOfTeacher == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseTeachOfTeacher.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseTeachOfTeacher.TeacherID);
            return View(courseTeachOfTeacher);
        }

        // POST: CourseTeachOfTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseTeachOfTeacherID,CourseID,TeacherID")] CourseTeachOfTeacher courseTeachOfTeacher)
        {
            if (id != courseTeachOfTeacher.CourseTeachOfTeacherID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTeachOfTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTeachOfTeacherExists(courseTeachOfTeacher.CourseTeachOfTeacherID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseTeachOfTeacher.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseTeachOfTeacher.TeacherID);
            return View(courseTeachOfTeacher);
        }

        // GET: CourseTeachOfTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeachOfTeacher = await _context.CourseTeachOfTeachers
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseTeachOfTeacherID == id);
            if (courseTeachOfTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeachOfTeacher);
        }

        // POST: CourseTeachOfTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTeachOfTeacher = await _context.CourseTeachOfTeachers.FindAsync(id);
            if (courseTeachOfTeacher != null)
            {
                _context.CourseTeachOfTeachers.Remove(courseTeachOfTeacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTeachOfTeacherExists(int id)
        {
            return _context.CourseTeachOfTeachers.Any(e => e.CourseTeachOfTeacherID == id);
        }
    }
}
