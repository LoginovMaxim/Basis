using System;
using Basis.UI.Screens;
using TMPro;
using UnityEngine;
using UnityWeld.Binding;

namespace Project.Meta.UI.Auth
{
    [Binding]
    public sealed class AuthScreenViewModel : ScreenViewModel
    {
        [SerializeField] private TMP_InputField _loginInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        
        public event Action<AuthData> OnAuthRequested; 
        
        [Binding]
        public void OnAuth()
        {
            var authData = new AuthData(_loginInputField.text, _passwordInputField.text);
            OnAuthRequested?.Invoke(authData);
        }
    }

    public struct AuthData
    {
        public string Login { get; }
        public string Password { get; }

        public AuthData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}