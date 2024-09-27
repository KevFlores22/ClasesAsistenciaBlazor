namespace clases_asistenciaAPI.DTO
{
    public class ReportesAsistenciumResponse
    {
        public int ReporteId { get; set; }

        public int EstudianteId { get; set; }

        public int ClaseId { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public int TotalAsistencias { get; set; }

        public int TotalAusencias { get; set; }

        public virtual ClaseResponse Clase { get; set; } = null!;

        public virtual EstudianteResponse Estudiante { get; set; } = null!;
    }
}
