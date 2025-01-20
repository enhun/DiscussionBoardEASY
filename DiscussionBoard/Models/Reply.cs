using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionBoard.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入回覆內容")]
        [Display(Name = "回覆內容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "請輸入回覆人")]
        [StringLength(50, ErrorMessage = "回覆人名稱最多50個字")]
        [Display(Name = "回覆人")]
        public string Author { get; set; }

        [Display(Name = "回覆時間")]
        public DateTime ReplyTime { get; set; } = DateTime.Now;

        // Foreign key for Post
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}