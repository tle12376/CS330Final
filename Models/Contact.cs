using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CS330Final.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [JsonPropertyName("user_email")]
        [Required]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required]
        public string UserPassword { get; set; }

        [JsonPropertyName("service_date")]
        public DateTime? CreatedDate { get; set; }
    }
}
