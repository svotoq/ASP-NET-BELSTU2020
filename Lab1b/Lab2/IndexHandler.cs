using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace Lab2
{
    public class IndexHandler : IHttpHandler
    {
        WebSocket socket;
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
          
        }
        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            string msg = await Recieve();
            await Send(msg);
            int i = 0;
            while (socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(2000);
                await Send("[" + (i++).ToString() + "]");
            }
        }
        private async Task<string> Recieve()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }

        private async Task Send(string msg)
        {
            var sendBuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("Response: " + msg));
            await socket.SendAsync(sendBuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
        }
        #endregion
    }
}
