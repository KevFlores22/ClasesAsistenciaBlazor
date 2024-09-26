namespace clases_asistenciaAPI.DTO
{
    public class UsuarioSession
    {
        public string UsuarioNombre { get; set; } = null!;
        public string UsuarioPassword { get; set; } = null!;

    }
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }

        public string UsuarioNombre { get; set; } = null!;

        //public string UsuarioPassword { get; set; } = null!;
    }
}
