using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IWebSocketHandler
    {
        Task HandleWebSocketAsync(WebSocket webSocket);
    }
}
