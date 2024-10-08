﻿using clases_asistenciaAPI.DTO;
using System.Net.Http.Headers;

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

        public async Task<List<AsistenciumResponse>> GetAsistencia()
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. IniciarSesion");
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<AsistenciumResponse>>("Api/Asistencia");

                return response;
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener Asistencia. Revisar conexion a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("A ocurrido un error inesperado al obtener clase.");
            }
        }
    }
}
