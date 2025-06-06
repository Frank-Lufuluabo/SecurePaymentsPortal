using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace bank_Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StaffController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
    {
        return await context.Staff.ToListAsync();
    }
}