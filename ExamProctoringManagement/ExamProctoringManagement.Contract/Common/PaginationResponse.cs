using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Common;

public class PaginationResponse<T>
{
    public PaginationResponse(IEnumerable<T> data, int currentPage, int itemsPerPage, int totalItems, int totalPages)
    {
        Data = data;
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        TotalItems = totalItems;
        TotalPages = totalPages;
    }

    public IEnumerable<T> Data { get; set; }

    public int CurrentPage { get; set; }

    public int ItemsPerPage { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }
}

