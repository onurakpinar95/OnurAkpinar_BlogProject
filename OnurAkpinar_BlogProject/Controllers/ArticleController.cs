using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnurAkpinar_BlogProject.DAL;
using OnurAkpinar_BlogProject.Models.DTOs;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<Member> _userManager;

        public ArticleController(BlogDbContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager= userManager;  
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
            var blogDbContext = _context.Articles.Where(x=>x.MemberID==GetUserID());
            return View(await blogDbContext.ToListAsync());
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            Article_DTO article = new Article_DTO();
            article.Topics = _context.Topics.ToList();
            return View(article);
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create(Article_DTO a_dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Challenge();
                }

                var article = new Article
                {
                    ArticleHeader = a_dto.ArticleHeader,
                    ArticleContent = a_dto.ArticleContent,
                    CreatedDate = DateTime.Now,
                    MemberID = user.Id,
                    ReadingTime = a_dto.ReadingTime,
                    ViewCounter = 0
                    
                };

                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                List<int> selectedTopics = a_dto.SelectedTopics.Select(int.Parse).ToList();
                foreach (var topicID in selectedTopics)
                {
                    var articleCategory = new TopicArticle
                    {
                        ArticleID = article.ArticleID,
                        TopicID = topicID
                    };
                    _context.TopicArticles.Add(articleCategory);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            a_dto.Topics = _context.Topics.ToList();
            return View(a_dto);

        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Users, "Id", "Id", article.MemberID);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleID,ArticleHeader,ArticleContent,ReadingTime,CreatedDate,ViewCounter,MemberID")] Article article)
        {
            if (id != article.ArticleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleID))
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
            ViewData["MemberID"] = new SelectList(_context.Users, "Id", "Id", article.MemberID);
            return View(article);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }



        public int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

        public IActionResult ReadArticle(int id)
        {

            var articles = _context.Articles
            .Include(a => a.TopicArticles)
                .ThenInclude(ac => ac.Topic)
            .Include(a => a.Member)
            .ToList();

            Article? article = articles.FirstOrDefault(x => x.ArticleID == id);
            ++article.ViewCounter;
            _context.SaveChanges();
            return View(article);
        }

        public IActionResult MemberArticles(int id)
        {
            var articles = _context.Articles.Include(x=>x.Member).Include(x=>x.TopicArticles).Where(x => x.MemberID == id);

            return View(articles);

        }
    }

}
