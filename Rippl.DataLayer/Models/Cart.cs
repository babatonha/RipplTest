﻿namespace Rippl.DataLayer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
