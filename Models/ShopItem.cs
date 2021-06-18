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
        public string productName { get; set; }
        public Nullable<decimal> productPrice { get; set; }
        public string productDescription { get; set; }
        public int productQuantity { get; set; }

    }
}