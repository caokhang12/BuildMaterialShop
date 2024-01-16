namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Tạo bởi")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Sửa bởi")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
