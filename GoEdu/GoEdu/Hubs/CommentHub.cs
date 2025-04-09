using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Hubs
{
    public class CommentHub : Hub
    {
        private readonly UnitOfWork unitOfWork;

        public CommentHub(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddComment(Comment c)
        {
            //add to database
                Comment comment = new Comment
                {
                    Content = c.Content,
                    Date = DateTime.Now,
                    LectureID = c.LectureID,
                    UserID = 1 // identity
                };
                unitOfWork.CommentRepo.Insert(comment);
                unitOfWork.save();

                Student std = unitOfWork.StudentRepo.GetByID(1);
                VMComment newcomm = new VMComment
                {
                    Content = comment.Content,
                    Date = comment.Date,
                    UserName = std.Name,
                    UserImageUrl = std.ImageUrl,
                    LectureId = comment.LectureID
                };
                //broadcast to all users
                Clients.All.SendAsync("CommentAdded", newcomm );//obj .net
        }
    }
}
