﻿namespace Core.Entites
{
    public class PortfolioItem : EntityBase
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}
