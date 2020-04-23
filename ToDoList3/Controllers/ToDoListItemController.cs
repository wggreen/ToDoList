using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoList3.Data;
using ToDoList3.Models;
using ToDoList3.Models.ViewModels;

namespace ToDoList3.Controllers
{
    [Authorize]
    public class ToDoListItemController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoListItemController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ToDoListItem
        public async Task<ActionResult> Index(string filter)
        {
            var user = await GetCurrentUserAsync();

            if (filter == "To Do")
            {
                var items = await _context.ToDoListItems
          .Where(ti => ti.ApplicationUserId == user.Id)
          .Where(ti => ti.ToDoStatusId == 2)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();


                return View(items);
            }
            else if (filter == "Progress")
            {
                var items = await _context.ToDoListItems
          .Where(ti => ti.ApplicationUserId == user.Id)
          .Where(ti => ti.ToDoStatusId == 3)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();

                return View(items);
            }
            else if (filter == "Done")
            {
                var items = await _context.ToDoListItems
          .Where(ti => ti.ApplicationUserId == user.Id)
            .Where(ti => ti.ToDoStatusId == 4)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();

                return View(items);
            }
            else
            {

                var items = await _context.ToDoListItems
                    .Where(ti => ti.ApplicationUserId == user.Id)
                    .Include(ti => ti.ToDoStatus)
                    .ToListAsync();

                return View(items);
            }



        }

        // GET: ToDoListItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoListItem/Create
        public async Task<ActionResult> Create()
        {
            var allStatuses = await _context.ToDoStatuses
                .Select(tds => new SelectListItem() { Text = tds.Title, Value = tds.Id.ToString() })
                .ToListAsync();

            var viewModel = new ToDoListItemFormViewModel();

            viewModel.ToDoStatusOptions = allStatuses;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoListItemFormViewModel toDoListItemAddViewModel)
        {
            try
            {
                var toDoListItem = new ToDoListItem
                {
                    Title = toDoListItemAddViewModel.Title,
                    ToDoStatusId = toDoListItemAddViewModel.ToDoStatusId,
                };

                var user = await GetCurrentUserAsync();

                toDoListItem.ApplicationUserId = user.Id;

                _context.ToDoListItems.Add(toDoListItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListItem/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _context.ToDoListItems.FirstOrDefaultAsync(tdli => tdli.Id == id);
            var loggedInUser = await GetCurrentUserAsync();

            var allStatuses = await _context.ToDoStatuses
                .Select(tds => new SelectListItem() { Text = tds.Title, Value = tds.Id.ToString() })
                .ToListAsync();

            var viewModel = new ToDoListItemFormViewModel()
            {
                Id = id,
                Title = item.Title,
                ToDoStatusId = item.ToDoStatusId,
                ToDoStatusOptions = allStatuses,
            };

            if (item.ApplicationUserId != loggedInUser.Id)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: ToDoListItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ToDoListItemFormViewModel toDoListItem)
        {
            try
            {
                var toDoItem = new ToDoListItem()
                {
                    Id = toDoListItem.Id,
                    Title = toDoListItem.Title,
                    ToDoStatusId = toDoListItem.ToDoStatusId
                };

                var user = await GetCurrentUserAsync();
                toDoItem.ApplicationUserId = user.Id;

                _context.ToDoListItems.Update(toDoItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListItem/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ToDoListItems.Include(i => i.ToDoStatus).FirstOrDefaultAsync(i => i.Id == id);

            return View(item);
        }

        // POST: ToDoListItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ToDoListItem toDoListItem)
        {
            try
            {

                _context.ToDoListItems.Remove(toDoListItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}