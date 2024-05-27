using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnurAkpinar_BlogProject.DAL;
using OnurAkpinar_BlogProject.Models;
using OnurAkpinar_BlogProject.Models.Entities;
using OnurAkpinar_BlogProject.Models.ViewModels;
using System.Diagnostics;

namespace OnurAkpinar_BlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Member> _userManager;
        private readonly BlogDbContext _context;
        private readonly SignInManager<Member> _signInManager;  
        public HomeController(ILogger<HomeController> logger, UserManager<Member> userManager,BlogDbContext context, SignInManager<Member> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context; 
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            ArticleVM vm= new ArticleVM();



            vm.Articles = _context.Articles.Include(x => x.TopicArticles).ThenInclude(ta => ta.Topic).Include(x => x.Member).OrderByDescending(x => x.ViewCounter).Take(6).ToList();
           
            vm.Topics=_context.Topics.Include(x=>x.TopicArticles).ThenInclude(at=>at.Article).ThenInclude(tm=>tm.Member).Where(topic => topic.TopicArticles.Any(ta => ta.Article != null)).ToList();

            if(_signInManager.IsSignedIn(User))
            {
                vm.AddableTopics = _context.Topics.ToList();
                vm.MemberTopics = _context.Topics
                        .Include(x => x.FollowingTopics)
                            .ThenInclude(tm => tm.Member)
                        .Include(x => x.TopicArticles)
                            .ThenInclude(ta => ta.Article)
                        .Where(topic => topic.FollowingTopics.Any(ta => ta.MemberID == GetUserID()) && topic.TopicArticles.Any())
                        .ToList();
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(ArticleVM? vm)
        {
            if (vm.FollowedTopics.Count < 1)
            {
                TempData["Hata"] = "Hiç konu seçmediniz!";
                return RedirectToAction("Index", "Home");
            }
            else
                FollowTopics(vm.FollowedTopics);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void FollowTopics(List<string> topics)
        {
            List<int> selectedTopics = topics.Select(int.Parse).ToList();
            foreach (var topicID in selectedTopics)
            {
                var memberTopic = new TopicMember
                {
                    MemberID = GetUserID(),
                    TopicID = topicID
                };
                _context.TopicMembers.Add(memberTopic);
            }
            _context.SaveChanges();
        }
        public int GetUserID()
        {
            int id = int.Parse(_userManager.GetUserId(User));
            return id ;
        }
    }
}
