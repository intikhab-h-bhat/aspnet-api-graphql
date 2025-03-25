using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Graphql.Data;
using WebApi.Graphql.Model;

namespace WebApi.Graphql.GraphQl
{
    public class Mutation
    {
        private readonly ApplicationDbContext _context;
        public Mutation(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Books> AddBook(string title, string author)
        {
            try
            {

                var newBook = new Books { Title = title, Author = author };
                _context.Books.Add(newBook);
                await _context.SaveChangesAsync();

                return newBook;
            }
            catch(Exception e)
            {
                return null;
            }
        }


        public async Task<Books> UpdateBook(int id, string title, string author)
        {

            try
            {
                

                var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

                if (existingBook == null)
                    return null;
                
                existingBook.Title = title;
                existingBook.Author = author;

                _context.Books.Update(existingBook);
                await _context.SaveChangesAsync();

                  


                return existingBook;

            }
            catch(Exception e)
            {
                return null;

            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
