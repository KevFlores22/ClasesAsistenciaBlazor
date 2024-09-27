namespace clases_asistenciaAPI.DTO
{
    public class AsistenciumResponse
    {
        public int AsistenciaId { get; set; }

        public int EstudianteId { get; set; }

        public int ClaseId { get; set; }

        public DateOnly Fecha { get; set; }

        public string Estado { get; set; } = null!;

        public virtual ClaseResponse Clase { get; set; } = null!;

        public virtual EstudianteResponse Estudiante { get; set; } = null!;
    }
}
