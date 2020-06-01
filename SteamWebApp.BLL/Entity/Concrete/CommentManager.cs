using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void Add(Comment entity)
        {
            _commentRepository.Add(entity);
        }

        public bool Any(Expression<Func<Comment, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            _commentRepository.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetByDefault(Expression<Func<Comment, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> GetCommentWithUser(int gameId)
        {
            return _commentRepository.GetCommentWithUser(gameId);
        }

        public List<Comment> GetDefault(Expression<Func<Comment, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
