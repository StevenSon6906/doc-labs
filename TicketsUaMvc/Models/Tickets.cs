using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsUaMvc.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип транспорту")]
        public string TransportType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Місто відправлення")]
        public string FromCity { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Місто прибуття")]
        public string ToCity { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Час відправлення")]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Display(Name = "Час прибуття")]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [Range(0, 100000)]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Перевізник")]
        public string Carrier { get; set; } = string.Empty;

        [Required]
        [Range(0, 500)]
        [Display(Name = "Кількість вільних місць")]
        public int AvailableSeats { get; set; }
    }
}