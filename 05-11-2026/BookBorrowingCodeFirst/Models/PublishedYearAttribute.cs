using System.ComponentModel.DataAnnotations;

namespace BookBorrowingCodeFirst.Models
{
    public class PublishedYearAttribute : RangeAttribute
    {
        public PublishedYearAttribute() : base(1900, DateTime.Now.Year)
        {
            ErrorMessage = "Năm xuất bản phải từ {1} đến {2}.";
        }
    }
}
