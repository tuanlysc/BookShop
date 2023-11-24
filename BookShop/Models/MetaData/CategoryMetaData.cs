using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookShop.Models.MetaData
{
    public class CategoryMetaData
    {
        [DisplayName("Mã danh mục")]
        public int id { get; set; }
        [DisplayName("Tên danh mục")]
        public string category_name { get; set; }
        [DisplayName("Trạng thái")]
        public Nullable<bool> category_status { get; set; }
        [DisplayName("Ảnh")]
        public string img { get; set; }
    }
}