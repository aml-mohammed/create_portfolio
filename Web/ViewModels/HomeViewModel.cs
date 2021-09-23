using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeViewModel
    {

        public Owner Owner { get; set; }
        public List<PortfolioItem> PortoflioItems { get; set; }
        public List<MoServices> MoServices { get; set; }
    }
}
