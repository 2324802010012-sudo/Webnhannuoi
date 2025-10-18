using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webnhannuoi.Data;

namespace Webnhannuoi.Controllers
{
    public class ThuCungController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ThuCungController(ApplicationDbContext context) => _context = context;

        // Danh sách (tùy chọn)
        public IActionResult Index()
        {
            var ds = _context.ThuCungs.Include(t => t.MaLoaiNavigation).ToList();
            return View(ds);
        }

        // Chi tiết
        public IActionResult Details(int id)
        {
            var tc = _context.ThuCungs
                .Include(t => t.MaLoaiNavigation)
                .FirstOrDefault(t => t.MaThuCung == id);

            if (tc == null) return NotFound();
            return View(tc);
        }
    }
}
