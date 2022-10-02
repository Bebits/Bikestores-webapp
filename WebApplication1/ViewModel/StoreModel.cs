using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class StoreModel
    {

        [Key]
        public int StoreId { get; set; }

        [Required(ErrorMessage ="Please enter Store Name!")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Please enter Phone!")]
        [DataType (DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone number must be 10 digit.", MinimumLength = 10)]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Please enter EmailAddress!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string ZipCode { get; set; }
        public int ProductId { get; set; }
        public int? quantity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created_Date { get; set; }
        public int ?ModifiedBy { get; set; }
        public DateTime ?ModifiedDate { get; set; }
    }
}