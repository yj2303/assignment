internal class Program
{
    private static Pagination GetCategoryPaging(int startPage, int totalPage)
    {
        string pageClass = string.Empty; int pageSize = 10, innerCount = 5;

        Pagination pagination = new Pagination();
        pagination.Pages = new List<PageEntity>();
        pagination.Next = startPage + 1;
        pagination.Previous = startPage - 1 > 0 ? startPage - 1 : 1;

        int totalPages = totalPage % pageSize == 0 ? totalPage / pageSize : totalPage / pageSize + 1;

        int loopStart = 1, loopCount = 1;

        if (start - 2 > 0)
        {
            loopStart = currentPage - 2;
        }

        for (int i = loopStart; i <= totalPages; i++)
        {
            pagination.Pages.Add(new PageEntity { Page = i, Class = string.Empty });

            if (loopCount == innerCount)
            { break; }

            loopCount++;
        }

        if (pagination.Pages.Count() <= 1)
        {
            pagination.Display = false;
        }

        return pagination;
    }
}