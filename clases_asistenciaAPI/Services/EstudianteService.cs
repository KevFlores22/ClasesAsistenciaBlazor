using clases_asistenciaAPI.DTO;
using System.Net.Http.Headers;

namespace clases_asistenciaAPI.Services
{
    public class EstudianteService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public EstudianteService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }
        public async Task<List<EstudianteResponse>> GetEstudiantes()
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. IniciarSesion");
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<EstudianteResponse>>("Api/Estudiante");

                return response;
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener Estudiantes. Revisar conexion a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("A ocurrido un error inesperado al obtener clase.");
            }

        }
    }
}
