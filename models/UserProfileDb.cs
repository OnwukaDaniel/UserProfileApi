using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.models
{
    public class UserProfileDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; internal set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? dob { get; set; }
        public string? createdAt { get; set; }
    }
}
