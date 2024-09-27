﻿using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using clases_asistenciaAPI.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace clases_asistenciaAPI.Services
{
    public class AuthService
    {
        private readonly ProtectedLocalStorage _localStorage;
        private readonly HttpClient _httpClient;
        private string? _token;

        public AuthService(ProtectedLocalStorage localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        //Enviar datos a Endpoint Login
        public async Task<string> Login(UsuarioSession usuarioSession)
        {
            var response = await _httpClient.PostAsJsonAsync("Api/usuario/login", usuarioSession);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }

            return null;
        }

        //Guardar token en el navegador 
        public async Task SetToken(string token)
        {
            _token = token;
            await _localStorage.SetAsync("token", token);
        }

        //Obtener token del navegador
        public async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                var localStorageResult = await _localStorage.GetAsync<string>("token");
                if(localStorageResult.Success || string.IsNullOrEmpty(localStorageResult.Value))
                {
                    _token = null;
                    return null;
                }

                _token = localStorageResult.Value;
            }
            return _token;
        }

        //Verificar si el usuario esta autentificado
        public async Task<bool> IsAuthenticated()
        {
            var token = await GetToken();

            return !string.IsNullOrEmpty(token) && !IsTokenExpired(token) ;
        }

        //Verificar si el token a expirado
        public bool IsTokenExpired(string token)
        {
            var jwtToken = new JwtSecurityToken();
            return jwtToken.ValidTo < DateTime.UtcNow;
        }

        //Cerrar sesion
        public async Task Logout()
        {
            _token= null;
            await _localStorage.DeleteAsync("token");
        }
    }
}