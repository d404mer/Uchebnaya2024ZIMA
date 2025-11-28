using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TEST.Services;
using TEST.Views;

namespace TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LogInTextBox.Text;
            string password = PasswordTextBox.Text;

            AuthService authService = new AuthService();

            if (authService.Login(login, password))
            {
                MessageBox.Show($"Добро пожаловать, {AuthService.CurrentUser.CharacterLogIn}!");

                var datagrid = new Views.CharactersDataGridView();
                datagrid.Show();

                this.Close();
            }
            else { MessageBox.Show("Неверный логин или пароль"); }
        }
    }
}