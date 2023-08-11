using Microsoft.EntityFrameworkCore;

namespace CompassMVC1.Models.Domain
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Booking { get; set; }
        public string? PassportNumber { get; set; }
        public string? TicketNumber { get; set; }
        [Precision(18, 2)]
        public Decimal? TicketFee { get; set; }
        [Precision(18, 2)]
        public Decimal? Tax { get; set; }
        [Precision(18, 2)]
        public Decimal? Commission { get; set; }
        [Precision(18, 2)]
        public Decimal? Total { get; set; }
        public DateTime RecordDate { get; set; }
        public string? Note { get; set; }
    }
}
