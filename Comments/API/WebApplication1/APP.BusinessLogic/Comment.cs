using System.ComponentModel.DataAnnotations;


namespace APP.BusinessLogic
{
    public partial class Comment
    {
        [Key]
        public int ID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? Body { get; set; }
    }
}