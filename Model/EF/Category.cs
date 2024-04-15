namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public class Category
    {
        public long ID { get; set; }

        [StringLength(250), DisplayName("Tên danh mục"), Required]
        public string Name { get; set; }

        [StringLength(250),DisplayName("Tiêu đề"), Required]
        public string MetaTitle { get; set; }
        [DisplayName("Danh mục cha")]
        public long? ParentID { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(250), DisplayName("Tiêu đề")]
        public string SeoTitle { get; set; }

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
        [DisplayName("Hiển thị tại trang chủ")]
        public bool ShowOnHome { get; set; }
    }
}
