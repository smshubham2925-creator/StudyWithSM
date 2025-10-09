using Microsoft.AspNetCore.Mvc;
using StudyWithMe.Data;
using StudyWithMe.Models;

namespace StudyWithMe.Controllers
{
    public class StudyMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudyMaterials
        public IActionResult Index()
        {
            var materials = _context.StudyMaterials.ToList();
            return View(materials);
        }

        // GET: StudyMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudyMaterials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyMaterial model, IFormFile? PdfFile)
        {
            if (ModelState.IsValid)
            {
                if (PdfFile != null && PdfFile.Length > 0)
                {
                    var fileName = Path.GetFileName(PdfFile.FileName);
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await PdfFile.CopyToAsync(stream);
                    }

                    model.PdfUrl = "/uploads/" + fileName;
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
