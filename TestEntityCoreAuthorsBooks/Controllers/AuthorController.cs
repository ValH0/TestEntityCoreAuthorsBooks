using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using TestEntityCoreAuthorsBooks.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;


namespace TestEntityCoreAuthorsBooks.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IAuthorsBooksService _authorsBooksService;
        private readonly IPageUiService _pageUiService;

        private readonly ILogger<AuthorController> _logger;

        private ShowModel _paginatedProperties;
        
        public AuthorController(ILogger<AuthorController> logger,
            IAuthorService authorService,
            IAuthorsBooksService authorsBooksService,
            IPageUiService pageUiService)
        {
            _logger = logger;

            _authorService = authorService;
            _authorsBooksService = authorsBooksService;
            _pageUiService = pageUiService;    
        }

        // Get /Views/Author/AddPage
        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorModel obj)
        {
            
           
            for (int i = 0; i < 120; i++)
            {
                string lName = obj.LastName.Clone() as string;
                string fName = obj.FirstName.Clone() as string;

                lName = lName += i.ToString();
                fName = fName += i.ToString();
                AuthorModel model = new AuthorModel()
                {
                    LastName = lName,
                    FirstName = fName,
                };
                await _authorService.CreateAuthor(model);
                //await _authorService.CreateAuthor(obj);

            }
            
            return Redirect("ShowAllPage");
        }

        // Get /Views/Author/ShowAllPage
        [HttpGet]
        public async Task<IActionResult> ShowAllPage(ShowModel paginatedProperties)
        {
            Debug.WriteLine("Debug.WriteLine = ShowAllPage(ShowModel paginatedProperties)");

            PageUiModel pageUiModel = null;
            try
            {
                pageUiModel = new PageUiModel()
                {
                    ItemsPerPage = "2",
                };

                int id = await _pageUiService.CreatePageUi(pageUiModel);
                if(id == -1)
                {
                    var temp = (await _pageUiService.GetAllPageUis()).FirstOrDefault();
                    pageUiModel.Id = temp.Id;
                }
                paginatedProperties.PageUiModel = pageUiModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            _paginatedProperties = await _authorService.Search(paginatedProperties); 
            _paginatedProperties.RecordsPerPage = Convert.ToInt32(pageUiModel.ItemsPerPage);
            

            if (!string.IsNullOrEmpty(_paginatedProperties.SortField))
            {
                return View(SortAuthorsData(_paginatedProperties));
            }

            return View(_paginatedProperties);
        }

        [HttpGet]
        public async Task<ActionResult> Sort
            (ShowModel paginatedProperties,
            int page,
            string sortField,
            string currentSortField,
            string currentSortOrder)
        {
            Debug.WriteLine("Debug.WriteLine = Sort(ShowModel paginatedProperties)");

            PageUiModel pageUiModel = null;

            try
            {
                pageUiModel = (await _pageUiService.GetAllPageUis()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            if (pageUiModel != null && !string.IsNullOrEmpty(pageUiModel.ItemsPerPage))
            {
                paginatedProperties.RecordsPerPage = Convert.ToInt32(pageUiModel.ItemsPerPage);
            }
            
            _paginatedProperties = await _authorService.Search(paginatedProperties);
            if (page > -1)
            {
                _paginatedProperties.Page = page;
                _paginatedProperties.SortField = sortField;
                _paginatedProperties.CurrentSortOrder = currentSortOrder;
                _paginatedProperties.CurrentSortField = currentSortField;
            }
            if (!string.IsNullOrEmpty(_paginatedProperties.SortField))
            {
                return PartialView("_AuthorsList", SortAuthorsData(_paginatedProperties));
            }

            return PartialView("_AuthorsList", _paginatedProperties);
        }

        [HttpGet]
        public async Task<ActionResult> PagerStep(ShowModel paginatedProperties, int page)
        {
            Debug.WriteLine("Debug.WriteLine = PagerStep(ShowModel paginatedProperties, int page)");

            PageUiModel pageUiModel = null;

            try
            {
                pageUiModel = (await _pageUiService.GetAllPageUis()).FirstOrDefault();
                paginatedProperties.PageUiModel = pageUiModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            if (pageUiModel != null && !string.IsNullOrEmpty(pageUiModel.ItemsPerPage))
            {
                paginatedProperties.RecordsPerPage = Convert.ToInt32(pageUiModel.ItemsPerPage);
            }
           
            _paginatedProperties = await _authorService.Search(paginatedProperties);
            if(page > -1)
            {
                _paginatedProperties.Page = page;
            }

            //if (pageUiModel != null && !string.IsNullOrEmpty(pageUiModel.ItemsPerPage))
            //{
            //    //_paginatedProperties.RecordsPerPage = Convert.ToInt32(pageUiModel.ItemsPerPage);
            //}

            return PartialView("_AuthorsList", _paginatedProperties);
        }

        [HttpGet]
        public async Task<ActionResult> Search(ShowModel paginatedProperties, string term, string idPageUi)
        {
            Debug.WriteLine("Debug.WriteLine = Search(ShowModel paginatedProperties)");

            if (term != null && term.Contains('%'))
            {
                term = term.Replace('%', ' ');
            }

            if(!string.IsNullOrEmpty(term))
            {
                paginatedProperties.Term = term;
            }
            

            _paginatedProperties = await _authorService.Search(paginatedProperties);

            _paginatedProperties.RecordsPerPage = (int)paginatedProperties.ItemsPerPage;

            if (string.IsNullOrEmpty(term) && !string.IsNullOrEmpty(idPageUi))
            {
                PageUiModel pageUiModel = await _pageUiService.GetPageUiById(Convert.ToInt32(idPageUi));
                if (pageUiModel != null)
                {
                    _paginatedProperties.RecordsPerPage = Convert.ToInt32(pageUiModel.ItemsPerPage);
                    _paginatedProperties.PageUiModel = pageUiModel;
                }
            }

            return PartialView("_AuthorsList", _paginatedProperties);
        }

        [HttpPost]
        public async Task<IActionResult> EditPage(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ShowAllPage", "Author");
                }
                AuthorModel author = await _authorService.GetAuthorById(Convert.ToInt32(id));
                return PartialView("EditPage", author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(AuthorModel obj)
        {
            await _authorService.UpdateAuthor(obj);
            return RedirectToAction("ShowAllPage");
        }

        [HttpPost]
        public async Task<IActionResult> ShowAuthorBooks(string id)
        {
            AuthorModel author = await _authorService.GetAuthorById(Convert.ToInt32(id));
            IEnumerable<BookModel> bookModels = await _authorsBooksService.FindAuthorsBooks(author);
            return PartialView("_ShowBooks", bookModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string page)
        {
            Debug.WriteLine("Debug.WriteLine = Delete(string id)");
            await _authorService.RemoveAuthor(Convert.ToInt32(id));
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerPage(string perpage, string idPageUi)
        {
            Debug.WriteLine("Debug.WriteLine = UpdatePerPage(string id)");

            try
            {
                int perPage = GetItemsPerPage(perpage);
                PageUiModel pageUiModel = new PageUiModel();
                
                if(perPage > 0 && !string.IsNullOrEmpty(idPageUi))
                {
                    pageUiModel.ItemsPerPage = Convert.ToString(perPage);
                    pageUiModel.Id = Convert.ToInt32(idPageUi);
                    await _pageUiService.UpdatePageUi(pageUiModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            return new EmptyResult();
        }

        [NonAction]
        private ShowModel SortAuthorsData(ShowModel paginatedProperties)
        {
            if (string.IsNullOrEmpty(paginatedProperties.SortField))
            {
                return null;
            }
            else
            {
                if (paginatedProperties.CurrentSortField == paginatedProperties.SortField)
                {
                    ViewBag.SortOrder = paginatedProperties.CurrentSortOrder == "Asc" ? "Desc" : "Asc";
                }
                else
                {
                    ViewBag.SortOrder = "Asc";
                }
                ViewBag.SortField = paginatedProperties.SortField;
            }

            var propertyInfo = typeof(AuthorModel).GetProperty(ViewBag.SortField);

            paginatedProperties.Authors = ViewBag.SortOrder == "Asc"
                ?
                paginatedProperties.Authors.OrderBy(s => propertyInfo.GetValue(s, null)).ToList()
                :
                paginatedProperties.Authors.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();

            return paginatedProperties;
        }

        [NonAction]
        private int GetItemsPerPage(string perpage)
        {
            ItemsPerPage itemsPerPage = ItemsPerPage.Two;
            if (Enum.TryParse<ItemsPerPage>(perpage, true, out itemsPerPage))
            {}    
            
            return (int)itemsPerPage;
        }
    }
}
