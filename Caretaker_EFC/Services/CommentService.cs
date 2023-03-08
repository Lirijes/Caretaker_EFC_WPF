using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.Services
{
    internal class CommentService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Comment> comments = new ObservableCollection<Comment>();

        public static async Task SaveCommentAsync(Comment comment)
        {
            var errand = ErrandService.GetErrandAsync(comment.ErrandOrdernumber);

            if (errand != null)
            {
                var commentEntity = new CommentEntity
                {
                    Created = comment.Created,
                    Description = comment.Description
                };

                _context.Add(commentEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Comment> Comments()
        {
            return comments;
        }
    }
}
