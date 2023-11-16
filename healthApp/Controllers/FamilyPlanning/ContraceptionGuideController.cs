using healthApp.Areas.Identity.Data;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace healthApp.Controllers.FamilyPlanning
{
    public class ContraceptionGuideController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContraceptionGuideController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContraceptionGuide
        public async Task<IActionResult> Index()
        {
            var contraceptionGuideRecords = await _context.ContraceptionGuideRecords.ToListAsync();
            return View(contraceptionGuideRecords);
        }

        // GET: ContraceptionGuide/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraceptionGuideRecord = await _context.ContraceptionGuideRecords.FindAsync(id);
            if (contraceptionGuideRecord == null)
            {
                return NotFound();
            }

            return View(contraceptionGuideRecord);
        }

        // GET: ContraceptionGuide/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContraceptionGuide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.


        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public

async Task<IActionResult> Create([Bind("ContraceptionType,Effectiveness,SideEffects,Cost")] ContraceptionGuideRecord contraceptionGuideRecord)
        {
            if (ModelState.IsValid)
            {
                _context.ContraceptionGuideRecords.Add(contraceptionGuideRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(contraceptionGuideRecord);
        }

        // GET: ContraceptionGuide/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraceptionGuideRecord = await _context.ContraceptionGuideRecords.FindAsync(id);
            if (contraceptionGuideRecord == null)
            {
                return NotFound();
            }

            return View(contraceptionGuideRecord);
        }

        // POST: ContraceptionGuide/Edit/5


        // To protect from overposting attacks, enable the specific properties you want to bind to.


        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public

async Task<IActionResult> Edit(int id, [Bind("Id,ContraceptionType,Effectiveness,SideEffects,Cost")] ContraceptionGuideRecord contraceptionGuideRecord)
        {
            if (id != contraceptionGuideRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contraceptionGuideRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContraceptionGuideRecordExists(contraceptionGuideRecord.Id))
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

            return View(contraceptionGuideRecord);
        }

        private bool ContraceptionGuideRecordExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: ContraceptionGuide/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraceptionGuideRecord = await _context.ContraceptionGuideRecords.FindAsync(id);
            if (contraceptionGuideRecord == null)
            {
                return NotFound();
            }

            return View(contraceptionGuideRecord);
        }
    }
}
