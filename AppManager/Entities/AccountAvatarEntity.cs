using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
	[Table("AccountAvatar")]
    public class AccountAvatarEntity
    {
		[Key]
		public int Id { get; set; }
		public int AccountId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int FileId { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
