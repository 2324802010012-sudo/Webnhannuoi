using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webnhannuoi.Data;

namespace Webnhannuoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy danh sách thú cưng đang chờ nhận nuôi
            var thuCung = _context.ThuCungs
                .Include(t => t.MaLoaiNavigation)
                .Where(t => t.TrangThai == "Đang được chăm sóc")
                .ToList();

            return View(thuCung);
        }
    }
}
