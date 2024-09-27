namespace clases_asistenciaAPI.Services
{
    public class AsistenciaService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public AsistenciaService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }
    }
}
