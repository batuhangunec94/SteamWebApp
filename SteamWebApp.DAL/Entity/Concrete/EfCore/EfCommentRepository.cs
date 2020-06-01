using Microsoft.EntityFrameworkCore;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.DAL.Entity.Concrete.EfCore.Context;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamWebApp.DAL.Entity.Concrete.EfCore
{
    public class EfCommentRepository:EfBaseRepository<Comment>,ICommentRepository
    {
        private ProjectContext _context;
        public EfCommentRepository(ProjectContext context):base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentWithUser(int gameId)
        {
            using (_context)
            {
                return _context.Comments.Where(x => x.GameId == gameId).Include(x => x.User).ToList();
            }
        }
    }
}
