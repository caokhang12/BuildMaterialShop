namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int ID { get; set; }

        [StringLength(50), DisplayName("Họ tên"),Required]
        public string Name { get; set; }

        [StringLength(50), DisplayName("Số điện thoại"), Required]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50), DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(250), DisplayName("Nội dung"), Required]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
