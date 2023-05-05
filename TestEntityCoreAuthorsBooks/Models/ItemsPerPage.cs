using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace TestEntityCoreAuthorsBooks.Models
{
    public class ItemsPerPage
    {
        public ItemsPerPage()
        {
            List<string> list = new List<string>();
            list.Add("2");
            list.Add("4");
            list.Add("6");
            list.Add("8");

            ListItems = new SelectList(list);
        }

        public SelectList ListItems { get; }
        
    }
}