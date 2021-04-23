using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeProject_core.Data;
using EmployeeProject_core.Models;
using EmployeeProject_core.ViewModel;
using Microsoft.Data.SqlClient;

namespace EmployeeProject_core.Controllers
{
    public class EmployeeToProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeToProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeToProject
        public IActionResult Index()
        {
            FilterSearch filtermodel = new FilterSearch();

            return View(filtermodel);
        }
        public async Task<ActionResult> EmployeeToProjectList(string search = "", string sdate = "", string edate = "", int cPage = 1, int Pagesize = 3)
        {

            search = (search == null) ? "" : search;
            sdate = (sdate == null) ? "" : sdate;
            edate = (edate == null) ? "" : edate;
            //cPage => current Page
            var parameters = new List<object>() {
                new SqlParameter("@search", search),
                new SqlParameter("@sdate", sdate),
                new SqlParameter("@edate", edate),
                new SqlParameter("@pagesize", Pagesize),
                new SqlParameter("@pagenum", cPage)
                };
            var outparam = new SqlParameter
            {
                ParameterName = "possiblerows",
                DbType = System.Data.DbType.String,
                Size = Int32.MaxValue,
                Direction = System.Data.ParameterDirection.Output
            };
            parameters.Add(outparam);
            string query = "exec GetData @search,@sdate,@edate,@pagesize,@pagenum,@possiblerows OUTPUT";
            List<EmployeeToProjectViewModel> Employeelist = await _context.GetData(query, parameters);

            int possiblerows = Convert.ToInt32(outparam.Value);
            if (possiblerows > Pagesize)
            {
                var TotalPages = (int)Math.Ceiling((double)((decimal)possiblerows / Pagesize));
                ViewBag.TotalPages = TotalPages;
                ViewBag.CurrPage = cPage;
            }
            return PartialView(Employeelist);
        }
        // GET: EmployeeToProject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeToProject = await _context.EmployeeToProject
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeToProject == null)
            {
                return NotFound();
            }

            return View(employeeToProject);
        }

        // GET: EmployeeToProject/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            return View();
        }

        // POST: EmployeeToProject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ProjectId")] EmployeeToProject employeeToProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeToProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeToProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeToProject.ProjectId);
            return View(employeeToProject);
        }

        // GET: EmployeeToProject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeToProject = await _context.EmployeeToProject.FindAsync(id);
            if (employeeToProject == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeToProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeToProject.ProjectId);
            return View(employeeToProject);
        }

        // POST: EmployeeToProject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ProjectId")] EmployeeToProject employeeToProject)
        {
            if (id != employeeToProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeToProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeToProjectExists(employeeToProject.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeToProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", employeeToProject.ProjectId);
            return View(employeeToProject);
        }

        // GET: EmployeeToProject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeToProject = await _context.EmployeeToProject
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeToProject == null)
            {
                return NotFound();
            }

            return View(employeeToProject);
        }

        // POST: EmployeeToProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeToProject = await _context.EmployeeToProject.FindAsync(id);
            _context.EmployeeToProject.Remove(employeeToProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeToProjectExists(int id)
        {
            return _context.EmployeeToProject.Any(e => e.Id == id);
        }
    }
}
