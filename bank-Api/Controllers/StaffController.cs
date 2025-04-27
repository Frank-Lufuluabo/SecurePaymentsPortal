using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;

namespace bank_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }
    }
}
