using System;
using Project.Meta.UI.Auth;
using UnityEngine;

namespace Project.Meta.Services.Chat
{
    public sealed class AuthService : IAuthService, IDisposable
    {
        private AuthClient _authClient;
        
        public AuthService()
        {
            Init();
        }

        private void Init()
        {
            // TCP server address
            string address = "127.0.0.1";

            // TCP server port
            int port = 1111;

            Debug.Log($"TCP server address: {address}");
            Debug.Log($"TCP server port: {port}");

            Debug.Log("");

            // Create a new TCP chat client
            _authClient = new AuthClient(address, port);

            // Connect the client
            Debug.Log("Client connecting...");
            _authClient.ConnectAsync();
            Debug.Log("Done!");

            Debug.Log("Press Enter to stop the client or '!' to reconnect the client...");
        }

        public void Auth(AuthData authData)
        {
            if (string.IsNullOrEmpty(authData.Login))
            {
                Debug.Log("Client disconnecting...");
                _authClient.DisconnectAndStop();
                Debug.Log("Done!");
                return;
            }

            // Disconnect the client
            if (authData.Login == "!")
            {
                Debug.Log("Client disconnecting...");
                _authClient.DisconnectAsync();
                Debug.Log("Done!");
                return;
            }

            // Send the entered text to the chat server
            _authClient.SendAsync(authData.Login);
        }

        public void Dispose()
        {
            _authClient.DisconnectAndStop();
        }
    }
}