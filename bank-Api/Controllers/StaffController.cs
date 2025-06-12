using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace bank_Api.Controllers;

[Authorize(Roles = "staff")]
[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Staff")]
public class StaffController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
    {
		try
		{
            return await context.Staff.ToListAsync();

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}