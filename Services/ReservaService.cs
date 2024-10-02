using ReservasRestaurante.DTO;
using System.Net.Http.Headers;

namespace ReservasRestaurante.Services
{
    public class ReservaService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ReservaService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<ReservaResponse>> GetReservas() {
            try
            {
                var token = await _authService.GetToken();
                if (string.IsNullOrEmpty(token)) {
                    throw new InvalidOperationException("El token es nulo o inválido. Iniciar sesión");
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<ReservaResponse>>("api/reservas");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener reservas. Revisar conexion a internet.");
            }
            catch (Exception ex) {
                throw new Exception("Ha ocurrido un errror inesperado al obtener reservas");
            }
        }
    }

   


}
