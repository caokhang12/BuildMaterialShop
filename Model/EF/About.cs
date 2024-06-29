namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("About")]
    public partial class About
    {
        public long ID { get; set; }

        [StringLength(250),DisplayName("Tên"),Required]
        public string Name { get; set; }

        [StringLength(250), DisplayName("Từ khóa tiêu đề"),Required]
        public string MetaTitle { get; set; }

        [StringLength(500), DisplayName("Miêu tả"),Required]
        public string Description { get; set; }

        [Column(TypeName = "ntext"), DisplayName("Chi tiết")]
        public string Detail { get; set; }

        [StringLength(250), DisplayName("Hình ảnh"),Required]
        public string Image { get; set; }

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
    }
}
