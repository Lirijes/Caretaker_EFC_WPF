using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static async Task<IEnumerable<Comment>> GetAllCOmmentAsync()
        {
            var _comments = new List<Comment>();

            foreach (var _comment in await _context.Comments.ToListAsync())
                _comments.Add(new Comment
                {
                    Id= _comment.Id,
                    Created = _comment.Created,
                    Description = _comment.Description
                });

            return _comments;
        }

        public static async Task UpdateCommentAsync(string errandOrdernumber, Comment comment)
        {
            var commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.ErrandOrdernumber == errandOrdernumber);
            if(commentEntity != null)
            {
                if(!string.IsNullOrEmpty(comment.Description))
                    commentEntity.Description = comment.Description;

                _context.Update(commentEntity);
                await _context.SaveChangesAsync();
            }
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
