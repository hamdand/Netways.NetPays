﻿namespace Netways.NetPays.UI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public float Price { get; set; }
        public string ImageUrl { get; set; } = "";// Image URL property
    }
}
