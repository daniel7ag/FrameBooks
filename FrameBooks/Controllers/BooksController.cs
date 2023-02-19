using FrameBooks.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace FrameBooks.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BooksController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(new
            {
                success = true,
                data = await _appDbContext.Books.ToListAsync()
            });
        }
    }
}
