namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }
        [StringLength(250), DisplayName("Tên sản phẩm"), Required]
        public string Name { get; set; }

        [StringLength(10),DisplayName("Mã")]
        public string Code { get; set; }

        [StringLength(250), DisplayName("Từ khóa tiêu đề"), Required]
        public string MetaTitle { get; set; }

        [StringLength(500), DisplayName("Miêu tả"), Required]
        public string Description { get; set; }

        [StringLength(250), DisplayName("Hình ảnh"),Required]
        public string Image { get; set; }

        [Column(TypeName = "xml"),DisplayName("Thêm hình ảnh")]
        public string MoreImages { get; set; }
        [DisplayName("Giá"),Required]
        public decimal? Price { get; set; }
        [DisplayName("Giá khuyến mãi")]
        public decimal? PromotionPrize { get; set; }
        [DisplayName("Số lượng"),Required]
        public int Quantity { get; set; }
        [DisplayName("Mục sản phẩm")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext"),DisplayName("Chi tiết")]
        public string Detail { get; set; }
        [DisplayName("Bảo hành")]
        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50), DisplayName("Tạo bởi")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50), DisplayName("Sửa bởi")]
        public string ModifiedBy { get; set; }

        [StringLength(250), DisplayName("Từ khóa tiêu đề"), Required]
        public string MetaKeywords { get; set; }

        [StringLength(250), DisplayName("Tiêu đề miêu tả"), Required]
        public string MetaDescriptions { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Bán chạy")]
        public DateTime? TopHot { get; set; }

        [StringLength(10), DisplayName("Lượt xem")]
        public string ViewCount { get; set; }
    }
}
