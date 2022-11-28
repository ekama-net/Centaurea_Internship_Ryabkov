﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTickets
{
    //TODO: maybe need to create services for all types of concerts
    public class ConcertService : IConcertService
    {
        private readonly AppDbContext _context;
        public ConcertService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Concert concert)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public async Task<IEnumerable<Concert>> GetAll()
        {
            var result = await _context.Concerts.ToListAsync();
            return result;
        }

        public Concert GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Concert Update(int id, Concert newConcert)
        {
            throw new System.NotImplementedException();
        }
    }
}
