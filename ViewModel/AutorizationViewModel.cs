﻿using ClientApi.Model;
using ClientApi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientApi.ViewModel
{
    public class AutorizationViewModel: INotifyPropertyChanged
    {
        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }
        private string? login;
        public string Login
        {
            get { return login!; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private string? password;
        public string LoginPassword
        {
            get { return password!; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(LoginPassword));
            }
        }

        private RelayCommand? loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(async obj =>
                  {
                      PasswordBox? password = obj as PasswordBox;
                      HttpClient client = new HttpClient();
                      User user = new User { Login = Login, Password = password!.Password };
                      JsonContent content = JsonContent.Create(user);
                   using var response = await client.PostAsync("http://localhost:5000/login", content);
                      string responseText = await response.Content.ReadAsStringAsync();
                      if (responseText != "")
                      {
                          Response? resp = JsonSerializer.Deserialize<Response>(responseText);
                          if (resp != null)
                          {
                              RegisterUser.UserName = resp.username;
                              RegisterUser.access_token = resp.access_token;
                              Visibility = Visibility.Hidden;
                              MenuWindow window = new MenuWindow();
                              window.Show();
                              MainWindow.Instance!.Close();
                          }
                      }
                      else MessageBox.Show("Пользователь с таким именем или паролем " +
                              "не существует!");

                  }));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
