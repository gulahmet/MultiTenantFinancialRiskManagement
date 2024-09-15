using FinancialRiskManagement.Business.Repositories;
using FinancialRiskManagement.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Services
{
    public class WebSocketHandler : IWebSocketHandler
    {
        private readonly IUserService _userService;
        private readonly ILogger<WebSocketHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WebSocketHandler(IUserService userService, ILogger<WebSocketHandler> logger, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _logger = logger;
            _unitOfWork = unitOfWork;
    }

        public async Task HandleWebSocketAsync(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = null;

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    // Mesaj al
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        // Bağlantı kapatılıyor
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        continue;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    // Mesajdan kullanıcı ID'si çıkar
                    if (int.TryParse(message, out var userId))
                    {
                        // Kullanıcıyı veritabanından al
                        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

                        var responseMessage = user != null
                            ? $"User found: {user.UserName}"
                            : "User not found";

                        // Yanıtı hazırlayıp gönder
                        var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                        var responseBuffer = new ArraySegment<byte>(responseBytes);

                        await webSocket.SendAsync(responseBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                    else
                    {
                        var errorMessage = "Invalid message format";
                        var errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                        var errorBuffer = new ArraySegment<byte>(errorBytes);

                        await webSocket.SendAsync(errorBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling WebSocket.");
            }
            finally
            {
                // Bağlantıyı kapat
                if (webSocket.State == WebSocketState.Open)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                }
            }
        }
    }
}
