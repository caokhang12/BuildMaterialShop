namespace Model.EF
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Footer")]
    public partial class Footer
    {
        public long ID { get; set; }
        [DisplayName("Nội dung")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
