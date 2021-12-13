using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagingTask.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public int RangePages { get; set; }

        public int StartPageNumber =>( CurrentPage - RangePages / 2)<=0? 1: CurrentPage - RangePages  / 2;

        public int EndPageNumber => (CurrentPage + RangePages / 2)>TotalPages?TotalPages :CurrentPage + RangePages  / 2;

        //public PagingInfo()
        //{

        //    if ((CurrentPage - RangePages / 2) <= 0)
        //    {
        //        StartPageNumber = 1;
        //        EndPageNumber = (1 + RangePages);
        //    }
        //    else if ((CurrentPage + RangePages / 2) > TotalPages)
        //    {
        //        EndPageNumber = TotalPages;
        //        StartPageNumber = TotalPages - RangePages;


        //    }

        //}

    }
}
