using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Models;


namespace TEST.Services
{
    public class AuthService
    {
        public static Character CurrentUser {  get; set; }


        /// <summary>
        /// Выполняет вход пользователя в систему
        /// </summary>
        /// <param name="username">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>True, если вход выполнен успешно, иначе False</returns>
        public bool Login(string username, string password)
        {
            try
            {
                var user = new DataService<Character>().GetAll().FirstOrDefault(u => u.CharacterLogIn == username);


                if (user == null)
                {
                    Debug.WriteLine($"Login: Пользователь с логином '{username}' не найден");
                    return false;
                }
                
             
                if (password == user.CharacterPassword)
                {
                    CurrentUser = user;
                    Debug.WriteLine($"Login: Авторизация успешна");
                    return true;
                }
                
                Debug.WriteLine($"Login: Неверный пароль");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка авторизации: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
