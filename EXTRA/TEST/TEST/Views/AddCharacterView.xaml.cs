using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TEST.Models;
using TEST.Services;

namespace TEST.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCharacterView.xaml
    /// </summary>
    public partial class AddCharacterView : Window
    {
        public Character NewCharacter { get; set; }
        public AddCharacterView()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long nextID = GetNextCharacterID();

                NewCharacter = new Character
                {
                    CharacterId = nextID,
                    CharacterLogIn = CharacterLogInTextBox.Text,
                    CharacterName = CharacterNameTextBox.Text,
                    CharacterPassword = CharacterPasswordTextBox.Text,
                };
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private long GetNextCharacterID()
        {
            var service = new DataService<Character>();
            var lastDriver = service.GetAll().OrderByDescending(d => d.CharacterId).FirstOrDefault();
            var next = lastDriver?.CharacterId + 1 ?? 1;
            return next;
        }
    }
}
