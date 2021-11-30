using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Models.Comments;

namespace WebApplication5.Data.Repository
{
    public class Repository : IRepository
    {

        private AppDbContext _ctx;
        private int pageSize = 1;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }


        


        public async Task<bool> SaveChangesAsync()
        {
            if(await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public Item GetItem(int id)
        {
            var item = _ctx.Items.Include(el => el.MainComments)
                .ThenInclude(el => el.SubComments)
                .FirstOrDefault(el => el.Id == id);
            return item;
        }

        public List<Item> GetAllItems()
        {
            var items = _ctx.Items.ToList();
            return items;
        }

        public List<Item> GetAllItems(int pageNumber, int? categoryId)
        {
            //double pagesCount = GetPagesCount();
            var items = GetAllItemsWithoutPagination(categoryId);
            return items.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public void AddItem(Item item)
        {
            _ctx.Items.Add(item);
        }

        public void RemoveItem(int id)
        {
            _ctx.Items.Remove(GetItem(id));
        }

        public void UpdateItem(Item item)
        {
            _ctx.Items.Update(item);
        }

        public Category GetCategory(int id)
        {
            var category = _ctx.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _ctx.Categories.ToList();
            return categories;
        }

        public void AddCategory(Category category)
        {
            _ctx.Categories.Add(category);
        }

        public void RemoveCategory(int id)
        {
            _ctx.Categories.Remove(GetCategory(id));
        }

        public void UpdateCategory(Category category)
        {
            _ctx.Categories.Update(category);
        }

        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }

        public double GetPagesCount(int? categoryId)
        {
            var items = GetAllItemsWithoutPagination(categoryId);
            return Math.Ceiling((double)items.Count() / (double)pageSize);
        }

        public int GetItemsCount(int? categoryId)
        {
            return GetAllItemsWithoutPagination(categoryId).Count();
        }

        public int GetItemsPerPageCount()
        {
            return pageSize;
        }

        public bool CanGoToNextPage(int pageNumber, int? categoryId)
        {
            return pageNumber < 1 || (pageNumber - 1) * GetItemsPerPageCount() > GetItemsCount(categoryId);
        }

        public List<Item> GetAllItemsWithoutPagination(int? categoryId)
        {
            return categoryId == null ? _ctx.Items.ToList() : _ctx.Items.Where(el => el.CategoryId == categoryId).ToList();
        }
    }
}
