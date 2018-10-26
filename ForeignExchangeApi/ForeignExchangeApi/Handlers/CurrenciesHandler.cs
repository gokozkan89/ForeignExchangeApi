using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using ForeignExchangeApi.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Handlers {
    public class CurrenciesHandler : WebSocketHandler {
        private readonly IHttpClientServices httpClientServices;
        public CurrenciesHandler(WebSocketConnectionManager webSocketConnectionManager,IHttpClientServices httpClientServices) : base(webSocketConnectionManager) {
            this.httpClientServices = httpClientServices;
        }
        public override async Task OnConnected(WebSocket socket) {
            await base.OnConnected(socket);

            var socketId = WebSocketConnectionManager.GetId(socket);
            var response = httpClientServices.GetList<Currency>("currencies/all/latest");
            await SendMessageToAllAsync(JsonConvert.SerializeObject(response));
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer) {
            var socketId = WebSocketConnectionManager.GetId(socket);
            var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            var response = httpClientServices.GetList<Currency>("currencies/all/latest");

            await SendMessageToAllAsync(JsonConvert.SerializeObject(response));
        }

    }
}
