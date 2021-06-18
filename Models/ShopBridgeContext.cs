using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;

namespace AsyncShopBridge.Models
{
    public class ShopBridgeContext : DbContext
    {

        public DbSet<ShopItem> ShopItems { get; set; }
    }
}