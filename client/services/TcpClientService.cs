using Airport_Kiosk_System.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Kiosk_System.Services {
    public class TcpClientService {
        static readonly string loopbackIpAddress = "127.0.0.1";
        static readonly int serverPort = 4001;

        public TcpClientService() {}

        public IPAddress getIpAddress() {
            return IPAddress.Parse(loopbackIpAddress);
        }
        
        public bool isConnectedToServer(TcpClient client) {
            if (client == null || client.GetStream() == null) {
                return false;
            }

            return client.Client.Poll(10, SelectMode.SelectRead) && client.Client.Available == 0;
        }

        public async Task<TcpClient> createTcpClient() {
            IPEndPoint ipEndPoint = new IPEndPoint(getIpAddress(), serverPort);

            TcpClient client = new TcpClient();
            await client.ConnectAsync(ipEndPoint);

            return client;
        }

        public async Task<string?> fetchMessageFromServer(TcpClient client) {
            string? message = null;
            
            try {
                byte[] readBuffer = new byte[1024];
                int received = await client.GetStream().ReadAsync(readBuffer);

                message = Encoding.UTF8.GetString(readBuffer, 0, received);
                Debug.WriteLine(message);
            }

            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }

            return message;
        }

        public async Task<User?> loginTravellerToServer() {
            using TcpClient client = await createTcpClient();
            User? user = null;

            try {
                string writeMessage = "LOGIN_TRAVELLER|";
                byte[] writeBuffer = Encoding.UTF8.GetBytes(writeMessage);
                await client.GetStream().WriteAsync(writeBuffer);

                string? authToken = await fetchMessageFromServer(client);

                if (authToken != null) {
                    user = new User(USER_TYPE.TRAVELLER, authToken);
                }
            }

            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }

            return user;
        }

        public async Task<string?[]> getUserInfoFromServer(User user, string[] infoToGet) {
            using TcpClient client = await createTcpClient();
            string?[] userInfo = [];
            
            try {
                string writeMessage = "GET_USER_INFO|" + user.getAuthToken() + "|";

                foreach (string infoType in infoToGet) {
                    writeMessage += infoType + ";";
                }

                byte[] writeBuffer = Encoding.UTF8.GetBytes(writeMessage);
                await client.GetStream().WriteAsync(writeBuffer);

                string? userInfoReceived = await fetchMessageFromServer(client);
            }

            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
            
            return userInfo;
        }
    }
}
