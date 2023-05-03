using Microsoft.AspNetCore.Mvc;
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

        private ShowModel _paginatedProperties;
        //private JsonHelpers _jsonHelpers;

        public AuthorController(IAuthorService authorService,
            IAuthorsBooksService authorsBooksService)
        {
            _authorService = authorService;
            _authorsBooksService = authorsBooksService;
           
            
            try
            {
               
                //_jsonHelpers = new JsonHelpers(filePath);

                //UserApplicationModel applicationModel = _jsonHelpers.Deserialize();
                //Console.WriteLine(applicationModel);
                //if(applicationModel != null && applicationModel.ItemsPerPage == null)
                //{
                //    applicationModel.ItemsPerPage = "2";
                //    _jsonHelpers.Serialize(applicationModel);
                //}
            }
            catch (Exception ex)
            {

            }           
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
            _paginatedProperties = await _authorService.Search(paginatedProperties);

            //UserApplicationModel applicationModel = _jsonHelpers.Deserialize();
            //if (applicationModel != null)
            //{
            //    _paginatedProperties.RecordsPerPage = Convert.ToInt32(applicationModel.ItemsPerPage);
            //}

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

            //UserApplicationModel applicationModel = null;
            //try
            //{
            //    applicationModel = _jsonHelpers.Deserialize();

            //    if (applicationModel != null)
            //    {
            //        paginatedProperties.RecordsPerPage = Convert.ToInt32(applicationModel.ItemsPerPage);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.ToString());
            //}

            Debug.WriteLine("Debug.WriteLine = Sort(ShowModel paginatedProperties)");
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
            //UserApplicationModel applicationModel = null;
            //try
            //{
            //    applicationModel = _jsonHelpers.Deserialize();

            //    if(applicationModel != null)
            //    {
            //        paginatedProperties.RecordsPerPage = Convert.ToInt32(applicationModel.ItemsPerPage);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.ToString());
            //}
           
            Debug.WriteLine("Debug.WriteLine = PagerStep(ShowModel paginatedProperties, int page)");
            _paginatedProperties = await _authorService.Search(paginatedProperties);
            if(page > -1)
            {
                _paginatedProperties.Page = page;
            }
            //if (applicationModel != null)
            //{
            //    _paginatedProperties.RecordsPerPage = Convert.ToInt32(applicationModel.ItemsPerPage);
            //}

            return PartialView("_AuthorsList", _paginatedProperties);
        }

        [HttpGet]
        public async Task<ActionResult> Search(ShowModel paginatedProperties, string term)
        {
            if(term != null && term.Contains('%'))
            {
                term = term.Replace('%', ' ');
            }

            if(!string.IsNullOrEmpty(term))
            {
                paginatedProperties.Term = term;
            }

            Debug.WriteLine("Debug.WriteLine = Search(ShowModel paginatedProperties)");
            _paginatedProperties = await _authorService.Search(paginatedProperties);

            _paginatedProperties.RecordsPerPage = (int)paginatedProperties.ItemsPerPage;


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
            catch (Exception)
            {
                throw;
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
        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    //await _authorService.RemoveAuthor(Convert.ToInt32(id));
        //    Debug.WriteLine("Debug.WriteLine = Delete(string id)");
        //    if (_paginatedProperties == null)
        //    {
        //        _paginatedProperties = new ShowModel();// await _authorService.Search(new ShowModel());
        //    }
        //    //await _authorService.RemoveAuthor(Convert.ToInt32(id));
        //    return RedirectToAction("ShowAllPage", _paginatedProperties);
        //    //return Json(new { IsProcessDone = true, ProcessMessage = "success" });
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string page)
        {
            Console.WriteLine(_paginatedProperties);
            Debug.WriteLine("Debug.WriteLine = Delete(string id)");
            await _authorService.RemoveAuthor(Convert.ToInt32(id));
            return new EmptyResult();
            //if (_paginatedProperties == null)
            //{
            //    _paginatedProperties = new ShowModel();
            //}
            //await _authorService.RemoveAuthor(Convert.ToInt32(id));
            //return View("ShowAllPage", _paginatedProperties);
            //return Json(new { IsProcessDone = true, ProcessMessage = "success" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerPage(ShowModel paginatedProperties, string perpage)
        {

            ItemsPerPage itemsPerPage = ItemsPerPage.Two;
            if(Enum.TryParse<ItemsPerPage>(perpage, true, out itemsPerPage))
            {

            }
            //Console.WriteLine(_paginatedProperties);
            //Debug.WriteLine(Convert.ToString((int)itemsPerPage));

            Debug.WriteLine("Debug.WriteLine = UpdatePerPage(string id)");

            //UserApplicationModel item = new UserApplicationModel();
            //item.ItemsPerPage = Convert.ToString((int)itemsPerPage);
            //_jsonHelpers.Serialize(item);


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
    }
}
