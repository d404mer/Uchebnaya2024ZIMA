using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using TEST.Models;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TEST.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateCharacterWindow.xaml
    /// </summary>
    public partial class UpdateCharacterWindow : Window
    {
        public Character EditedCharacter { get; set; }
        private long _characterId;
        
        public UpdateCharacterWindow(Character character)
        {
            InitializeComponent();
            
            _characterId = character.CharacterId;
            CharacterLogInTextBox.Text = character.CharacterLogIn ?? string.Empty;
            CharacterNameTextBox.Text = character.CharacterName ?? string.Empty;
            CharacterPasswordTextBox.Text = character.CharacterPassword ?? string.Empty;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            EditedCharacter = new Character
            {
                CharacterId = _characterId,
                CharacterLogIn = CharacterLogInTextBox.Text,
                CharacterName = CharacterNameTextBox.Text,
                CharacterPassword = CharacterPasswordTextBox.Text,
            };
            
            this.DialogResult = true;
            this.Close();
        }
    }
}
