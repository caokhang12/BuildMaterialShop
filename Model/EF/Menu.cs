namespace Model.EF
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [DisplayName("Nội dung")]
        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Link { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Target { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        public int? TypeID { get; set; }
    }
}
