using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    [MetadataTypeAttribute(typeof(Models.MetaData.ProductMetaData))]
    public partial class book
    {
        public bool IsImageChanged { get; set; }
    }
}