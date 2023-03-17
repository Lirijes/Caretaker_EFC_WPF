using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Caretaker_EFC.Services
{
    public static class CommentService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Comment> comments = new ObservableCollection<Comment>();

        public static async Task SaveCommentAsync(Comment comment)
        {
            var commentEntity = new CommentEntity
            {
                Id = comment.Id,
                Created = comment.Created,
                Description = comment.Description,
                ErrandOrdernumber = comment.ErrandOrdernumber
            };

            _context.Add(commentEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<ObservableCollection<CommentEntity>> GetAllCOmmentAsync(string ordernumber)
        {
            var _comments = new ObservableCollection<CommentEntity>();

            foreach (var _comment in await _context.Comments.Where(x => x.ErrandOrdernumber == ordernumber).ToListAsync())
                _comments.Add(new CommentEntity
                {
                    Id = _comment.Id,
                    Created = _comment.Created,
                    Description = _comment.Description,
                    ErrandOrdernumber = _comment.ErrandOrdernumber
                });

            return _comments;
        }

        public static async Task RemoveCommentAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Comment> Comments()
        {
            return comments;
        }
    }
}
