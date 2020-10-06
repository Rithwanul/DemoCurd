using System.Linq;
using System.Threading.Tasks;
using DemoCurd.DbContexts;
using DemoCurd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCurd.Controllers
{
    public class AuthorController : Controller
    {

        private readonly AuthorDbContext context;

        public AuthorController(AuthorDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Author.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Author = await context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if(Author == null)
            {
                return NotFound();
            }
            return View(Author);
        }

        /**
         * Method For Get Edit Page
         */
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Author = await context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if(Author == null)
            {
                return NotFound();
            }
            return View(Author);
        }

        /**
         *  Method for post Edit page
         */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int? id, 
            [Bind("Id, FirstName, LastName, EmailAddress, Phone, Address, City, State, Zip")] Author author
        )
        {
            if(id != author.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    context.Update(author);
                    await context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!context.Author.Any(a => a.Id == id))
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

            return RedirectToAction(nameof(Index));
        }

        /*
         * Method get create page
         * **/
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, EmailAddress, Phone, Address, City, State, Zip")] Author author)
        {
            if(ModelState.IsValid)
            {
                context.Add(author);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();    
        }

        /*
         * Get method for delete user
         */

        public async Task<IActionResult> Delete(int? id)
        {
            var author = await context.Author.FirstOrDefaultAsync(a => a.Id == id);
            return View(author);
        }

        /*
         * Post message for confirm delete operation.
         */

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var author = await context.Author.FindAsync(id);
            if(author != null)
            {
                context.Author.Remove(author);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
