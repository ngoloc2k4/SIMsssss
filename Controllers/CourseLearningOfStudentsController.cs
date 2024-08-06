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
    public class CourseLearningOfStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseLearningOfStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseLearningOfStudents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseLearningOfStudents.Include(c => c.Course).Include(c => c.Student).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseLearningOfStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLearningOfStudent = await _context.CourseLearningOfStudents
                .Include(c => c.Course)
                .Include(c => c.Student)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseLearningOfStudentID == id);
            if (courseLearningOfStudent == null)
            {
                return NotFound();
            }

            return View(courseLearningOfStudent);
        }

        // GET: CourseLearningOfStudents/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return View();
        }

        // POST: CourseLearningOfStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseLearningOfStudentID,CourseID,StudentID,TeacherID")] CourseLearningOfStudent courseLearningOfStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseLearningOfStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseLearningOfStudent.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", courseLearningOfStudent.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseLearningOfStudent.TeacherID);
            return View(courseLearningOfStudent);
        }

        // GET: CourseLearningOfStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLearningOfStudent = await _context.CourseLearningOfStudents.FindAsync(id);
            if (courseLearningOfStudent == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseLearningOfStudent.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", courseLearningOfStudent.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseLearningOfStudent.TeacherID);
            return View(courseLearningOfStudent);
        }

        // POST: CourseLearningOfStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseLearningOfStudentID,CourseID,StudentID,TeacherID")] CourseLearningOfStudent courseLearningOfStudent)
        {
            if (id != courseLearningOfStudent.CourseLearningOfStudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseLearningOfStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseLearningOfStudentExists(courseLearningOfStudent.CourseLearningOfStudentID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseLearningOfStudent.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", courseLearningOfStudent.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", courseLearningOfStudent.TeacherID);
            return View(courseLearningOfStudent);
        }

        // GET: CourseLearningOfStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLearningOfStudent = await _context.CourseLearningOfStudents
                .Include(c => c.Course)
                .Include(c => c.Student)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseLearningOfStudentID == id);
            if (courseLearningOfStudent == null)
            {
                return NotFound();
            }

            return View(courseLearningOfStudent);
        }

        // POST: CourseLearningOfStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseLearningOfStudent = await _context.CourseLearningOfStudents.FindAsync(id);
            if (courseLearningOfStudent != null)
            {
                _context.CourseLearningOfStudents.Remove(courseLearningOfStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseLearningOfStudentExists(int id)
        {
            return _context.CourseLearningOfStudents.Any(e => e.CourseLearningOfStudentID == id);
        }
    }
}
