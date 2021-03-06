using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Models.Comments;

namespace WebApplication5.Data.Repository
{
    public interface IRepository
    {
    
        Item GetItem(int id);

        List<Item> GetAllItems();
        List<Item> GetAllItems(int pageNumber, int? categoryId);
        List<Item> GetAllItemsWithoutPagination(int? categoryId);

        void AddItem(Item item);
        void RemoveItem(int id);
        void UpdateItem(Item item);
        double GetPagesCount(int? categoryId);
        int GetItemsCount(int? categoryId);

        int GetItemsPerPageCount();

        bool CanGoToNextPage(int pageNumber, int? categoryId);

        Category GetCategory(int id);
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void UpdateCategory(Category category);

        void AddSubComment(SubComment comment);

        Task<bool> SaveChangesAsync();
    }
}
