using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }
        public List<Comment> CommentListByBlog(int id)
        {
            return _commentDal.List(x => x.BlogId == id);
        }

        public void CommentStatusChangeToFalse(int id)
        {
            //var model = repository.Find(x => x.CommentId == id);
            //model.CommentStatus = false;
            //repository.Update(model);

            var model = _commentDal.GetById(id);
            model.CommentStatus = false;
            _commentDal.Update(model);
        }
        public void CommentStatusChangeTrue(int id)
        {
            var model = _commentDal.GetById(id);
            model.CommentStatus = true;
            _commentDal.Update(model);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public Comment GetById(int id)
        {
           return _commentDal.GetById(id);
        }


        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
