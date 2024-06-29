namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [StringLength(250),DisplayName("Hình ảnh"),Required]
        public string Image { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50), DisplayName("Miêu tả"), Required]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50), DisplayName("Tạo bởi")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50), DisplayName("Sửa bởi")]
        public string ModifiedBy { get; set; }
        [DisplayName("Trạng thái")]

        public bool Status { get; set; }
    }
}
