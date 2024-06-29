namespace Model.EF
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext"),DisplayName("Thông tin liên lạc"), Required]
        public string Content { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }
    }
}
