﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_hls68.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        public void AddItem (Books Book, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Books.BookId == Book.BookId)
                .FirstOrDefault();

            if(Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = Book,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            //bring in book price(different from video)
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }
    }
    
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Books { get; set; }
        public int Quantity { get; set; }
    }
}
