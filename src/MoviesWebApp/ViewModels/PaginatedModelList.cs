﻿using MoviesWebApp.Core.Models;

namespace MoviesWebApp.ViewModels
{
    public class PaginatedModelList<T> : List<T> where T : class, new()
    {
        public PaginatedModelList()
        {
            
        }
        public PaginatedModelList(List<T> datas, int pageSize, int dataCount, int  page)
        {
            CurrentPage = page!=0 ? page :1 ;
            PageCount = (int)Math.Ceiling(dataCount / (double)pageSize);
            this.AddRange(datas);

        }
        public int PageCount { get; set; }
        public  int  CurrentPage { get; set; } 
        public bool HasNext{get => PageCount > CurrentPage;set { }}
        public bool HasPrev { get => CurrentPage != 1; set { } }

        public static PaginatedModelList<T> Create(IQueryable<T> query, int  page, int pageSize)
        {page=page>0 ? page :1;
            
            
            return new PaginatedModelList<T>(query.Skip((page - 1) * pageSize).Take(pageSize).ToList(), pageSize, query.ToList().Count, page);
        }
    }
}
