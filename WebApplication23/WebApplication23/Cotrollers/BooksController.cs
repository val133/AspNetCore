using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication23.DTO;

namespace WebApplication23.Cotrollers
{
    [Route("api/authors/{authorId}/books")]
    //[ApiController]
    public class BooksController : Controller
    {
        private ILibraryRepository libraryRepository;

        public BooksController(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }
        [HttpGet]
        public IActionResult GetBooksForAuthor(Guid authorId)
        {
            if (!this.libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var booksForAutorsFromRepo = this.libraryRepository.GetBooksForAuthor(authorId);
            var booksForAuthor = Mapper.Map<IEnumerable<BookDto>>(booksForAutorsFromRepo);
            return Ok(booksForAuthor);
        }
    }
}