using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }
    }


}
