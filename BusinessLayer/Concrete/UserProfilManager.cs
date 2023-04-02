using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserProfilManager
    {
        Repository<Author> repository = new Repository<Author>();
        Repository<Blog> blogRepo = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string mail)
        {
            return repository.List(x => x.AuthorMail == mail);
        }
        public List<Blog> GetAuthorByAuthor(int id)
        {
            return blogRepo.List(x => x.AuthorId == id);
        }
        public void EditAuthor(Author author)
        {
            var model = repository.GetById(author.AuthorId);
            model.AuthorPhone = author.AuthorPhone;
            model.AuthorName = author.AuthorName;
            model.AuthorAbout = author.AuthorAbout;
            model.AuthorMail = author.AuthorMail;
            model.AboutShort = author.AboutShort;
            model.AuthorPassword = author.AuthorPassword;
            model.AuthorTitle = author.AuthorTitle;
            model.AuthorImage = author.AuthorImage;
            repository.Update(model);
        }
    }
}
