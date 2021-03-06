﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Enities
{
    public enum ConditionType
    {
        unKnown,
        New,
        Used,
        Refurbished
    }

    [Table("Products")]
    public class Product: IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }

        [Display(Name = "Average Review")]
        [Range(0.0, 5.0)]
        public double AvgCustomerReview { get; set; } = 0;

        public bool IsAvailiable { get; set; } = true;
        [Required]
        public int SubDepartmentId { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }
        public ConditionType Condition { get; set; }
        public int Quantity { get; set; }
        public string Discriminator { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string Brand { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

    }
}
