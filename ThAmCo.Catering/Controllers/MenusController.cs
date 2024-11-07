using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")] // Defines the route prefix for this controller. Requests to "api/Menus" will be directed here.
    [ApiController] //Marks this class as an API controller, enabling features like model validation and HTTP responses consistency.


    public class MenusController : ControllerBase  // The MenusController class manages HTTP requests related to "Menus" and inherits basic API functionality from ControllerBase.

    {
        private readonly CateringDbContext _context;  // Declares a private readonly variable to hold the database context for this controller.


        // Constructor that initializes the controller with a CateringDbContext instance.
        public MenusController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus - Retrieves a list of all menus.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {   
            // Asynchronously fetches all menus from the database and returns them as a list.
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menus/5 - Retrieves a single menu item by its ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            // Finds a menu by its ID.
            var menu = await _context.Menus.FindAsync(id);

            // If the menu does not exist, return a 404 Not Found response.
            if (menu == null)
            {
                return NotFound();
            }
            
            // Returns the found menu.
            return menu;
        }



        // PUT: api/Menus/5 - Updates an existing menu identified by its ID.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            // Checks if the ID in the URL matches the ID of the provided menu; if not, returns a 400 Bad Request.
            if (id != menu.MenuId)
            {
                return BadRequest();
            }

            // Marks the state of the menu entity as modified in the context.
            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                // Attempts to save the changes to the database.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If the menu no longer exists, returns a 404 Not Found.
                if (!MenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // If any other error occurs, rethrows the exception.
                    throw;
                }
            }

            // Returns a 204 No Content response, indicating successful update with no additional content.
            return NoContent();
        }


        // POST: api/Menus - Creates a new menu item.
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            // Adds the new menu to the database context.
            _context.Menus.Add(menu);

            // Saves changes asynchronously to persist the new menu in the database.
            await _context.SaveChangesAsync();

            // Returns a 201 Created response with a URI to the created resource.
            return CreatedAtAction("GetMenu", new { id = menu.MenuId }, menu);
        }



        // DELETE: api/Menus/5 - Deletes a menu by its ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            // Finds the menu by its ID.
            var menu = await _context.Menus.FindAsync(id);

            // If the menu doesn't exist, returns a 404 Not Found.
            if (menu == null)
            {
                return NotFound();
            }

            // Removes the menu from the database context.
            _context.Menus.Remove(menu);

            // Saves changes asynchronously to reflect deletion in the database.
            await _context.SaveChangesAsync();


            // Returns a 204 No Content response to indicate successful deletion.
            return NoContent();
        }



        // Helper method that checks if a menu exists by its ID.
        private bool MenuExists(int id)
        {

            // Returns true if any menu with the specified ID exists in the database.
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}


/*CRUD Operations:
GetMenus retrieves all menus.
GetMenu retrieves a specific menu by ID.
PutMenu updates a menu by ID.
PostMenu creates a new menu.
DeleteMenu deletes a menu by ID.

 */