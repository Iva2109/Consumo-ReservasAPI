namespace ReservasRestaurante.DTO
{
    public class ReservaResponse
    {
        public int IdReserva { get; set; }

        public int? UserId { get; set; }

        public DateTime FechaReserva { get; set; }

        public TimeSpan HoraReserva { get; set; }

        public int? NumPersonas { get; set; }

        public string? Estado { get; set; }


        public virtual UserResponse UserIdNavigation { get; set; }
    }
}
