using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuto.Plugins
{
    public class Pager1
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public string NumOfRegistration { set; get; }
        public int Id_Status { set; get; }
        public int Page { set; get; }

        public Pager1(int totalItems, int ptotalPages, int? page, int pageSize = 20)
        {
            // calculate total, start and end pages
            var totalPages = ptotalPages;
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}