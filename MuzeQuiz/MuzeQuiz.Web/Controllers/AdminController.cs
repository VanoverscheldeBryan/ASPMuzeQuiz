using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzeQuiz.Models;
using MuzeQuiz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MuzeQuiz.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly UserManager<AppUser> _userMgr;
        private readonly IRatingRepo _ratingRepo;

        public AdminController(RoleManager<IdentityRole> roleMgr, UserManager<AppUser> userMgr, IRatingRepo ratingRepo)
        {
            this._roleMgr = roleMgr;
            this._userMgr = userMgr;
            this._ratingRepo = ratingRepo;
        }

        // GET: Admin

        public ActionResult Users()
        {
            var result = _userMgr.Users;
            return View(result);
        }

        public async Task<ActionResult> Ratings()
        {
            var result = await _ratingRepo.GetRatingsAsync();
            return View(result);
        }

        public ActionResult Roles()
        {
            var result = _roleMgr.Roles;
            return View(result);//De view ontvangt een @model IEnumerable<IdentityRole>
        }

        public ActionResult AddRoleToUser(string UserId)
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}