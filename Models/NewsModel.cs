using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studying.Models
{
    [Table("news")]
    public class NewsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("keyword")]
        public string Keyword { get; set; }


        [Column("language")]
        public string Language { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("published_at")]
        private DateTime _publishedAt; 

        public DateTime PublishedAt
        {
            get => _publishedAt;
            set => _publishedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
