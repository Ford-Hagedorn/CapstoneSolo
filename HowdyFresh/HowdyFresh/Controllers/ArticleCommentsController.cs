using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HowdyFresh.Data;
using HowdyFresh.Models;
using Microsoft.AspNetCore.Http;

namespace HowdyFresh.Controllers
{
    public class ArticleCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArticleComments
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleComment.ToListAsync());
        }

        // GET: ArticleComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticleComment
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (articleComment == null)
            {
                return NotFound();
            }
            

            return View(articleComment);
        }

        // GET: ArticleComments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var articleId = int.Parse(form["ArticleId"]);
            var rating = int.Parse(form["Rating"]);

            ArticleComment artComment = new ArticleComment()
            {
                ArticleId = articleId,
                Comment = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now

            };

            _context.ArticleComment.Add(artComment);
            _context.SaveChanges();
            return RedirectToAction("Details", "Articles", new { id = articleId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Comment,ThisDateTime,ArticleId,Rating")] ArticleComment articleComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleComment);
        }

        // GET: ArticleComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticleComment.FindAsync(id);
            if (articleComment == null)
            {
                return NotFound();
            }
            return View(articleComment);
        }

        // POST: ArticleComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Comment,ThisDateTime,ArticleId,Rating")] ArticleComment articleComment)
        {
            if (id != articleComment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleCommentExists(articleComment.CommentId))
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
            return View(articleComment);
        }

        // GET: ArticleComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticleComment
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (articleComment == null)
            {
                return NotFound();
            }

            return View(articleComment);
        }

        // POST: ArticleComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleComment = await _context.ArticleComment.FindAsync(id);
            _context.ArticleComment.Remove(articleComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleCommentExists(int id)
        {
            return _context.ArticleComment.Any(e => e.CommentId == id);
        }
    }
}
