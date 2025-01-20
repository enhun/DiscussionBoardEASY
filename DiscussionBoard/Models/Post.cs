using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscussionBoard.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入主題")]
        [StringLength(100, ErrorMessage = "主題最多100個字")]
        [Display(Name = "主題")]
        public string Title { get; set; }

        [Required(ErrorMessage = "請輸入內容")]
        [Display(Name = "內容")]
        public string Content { get; set; }

        [Display(Name = "照片")]
        public byte[]? Photo { get; set; }

        [Display(Name = "照片類型")]
        [StringLength(50)]
        public string? PhotoContentType { get; set; }

        [Required(ErrorMessage = "請輸入發表人")]
        [StringLength(50, ErrorMessage = "發表人名稱最多50個字")]
        [Display(Name = "發表人")]
        public string Author { get; set; }

        [Display(Name = "發表時間")]
        public DateTime PostTime { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}