using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookBorrowingCodeFirst.Models
{
    public class BorrowingRecord : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày mượn.")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày mượn")]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày trả")]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người mượn.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên người mượn từ 3 đến 100 ký tự.")]
        [Display(Name = "Người mượn")]
        public string BorrowerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [Display(Name = "Email")]
        public string BorrowerEmail { get; set; } = string.Empty;

        [Display(Name = "Sách")]
        public int BookId { get; set; }

        [ValidateNever]
        public virtual Book? Book { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReturnDate.HasValue && ReturnDate.Value.Date < BorrowDate.Date)
            {
                yield return new ValidationResult(
                    "Ngày trả không được nhỏ hơn ngày mượn.",
                    new[] { nameof(ReturnDate) });
            }
        }
    }
}
