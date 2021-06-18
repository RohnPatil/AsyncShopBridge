using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AsyncShopBridge.Models
{
    [Table("tblProducts")]
    public class ShopItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter product Name")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Please enter product Price")]
        public Nullable<decimal> productPrice { get; set; }
        [Required(ErrorMessage = "Please enter product Description")]
        public string productDescription { get; set; }
        [Required(ErrorMessage = "Please enter product quantity")]
        [Range(1, 1000, ErrorMessage = "Enter quantity between 1 to 1000")]
        public int productQuantity { get; set; }

    }
}