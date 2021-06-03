namespace NewFrontApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SubCategory")]
    public partial class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
    }
}
