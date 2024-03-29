﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // a operação Any do Linq irá testar se há algum registro
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                // se houver, não irá fazer nada
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");
            Department d5 = new Department { Id = 5, Name = "Toys" };

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Thomas Jefferson", "thomjef@gmail.com", new DateTime(1994, 5, 13), 1500.0, d2);
            Seller s3 = new Seller(3, "Joana D'Arc", "jdarc@outlook.com", new DateTime(1990, 8, 23), 1400.0, d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2017, 5, 18), 300.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2015, 2, 7), 3000.0, SaleStatus.Pending, s2);

            // o método AddRange permite que se inclua vários objetos de uma só vez
            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3);
            _context.SalesRecord.AddRange(r1, r2);

            _context.SaveChanges();
        }
    }
}
