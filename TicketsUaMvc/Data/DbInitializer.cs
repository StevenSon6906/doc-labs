using TicketsUaMvc.Models;

namespace TicketsUaMvc.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Tickets.Any())
                return;

            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    TransportType = "Автобус",
                    FromCity = "Львів",
                    ToCity = "Київ",
                    DepartureTime = new DateTime(2026, 4, 15, 8, 30, 0),
                    ArrivalTime = new DateTime(2026, 4, 15, 16, 45, 0),
                    Price = 850,
                    Carrier = "FlixBus",
                    AvailableSeats = 12
                },
                new Ticket
                {
                    TransportType = "Поїзд",
                    FromCity = "Львів",
                    ToCity = "Одеса",
                    DepartureTime = new DateTime(2026, 4, 16, 21, 10, 0),
                    ArrivalTime = new DateTime(2026, 4, 17, 7, 20, 0),
                    Price = 1200,
                    Carrier = "Укрзалізниця",
                    AvailableSeats = 28
                },
                new Ticket
                {
                    TransportType = "Літак",
                    FromCity = "Київ",
                    ToCity = "Варшава",
                    DepartureTime = new DateTime(2026, 4, 18, 11, 0, 0),
                    ArrivalTime = new DateTime(2026, 4, 18, 12, 20, 0),
                    Price = 3200,
                    Carrier = "LOT",
                    AvailableSeats = 7
                },
                new Ticket
                {
                    TransportType = "Автобус",
                    FromCity = "Тернопіль",
                    ToCity = "Львів",
                    DepartureTime = new DateTime(2026, 4, 15, 14, 0, 0),
                    ArrivalTime = new DateTime(2026, 4, 15, 16, 0, 0),
                    Price = 250,
                    Carrier = "Ecolines",
                    AvailableSeats = 19
                }
            };

            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}