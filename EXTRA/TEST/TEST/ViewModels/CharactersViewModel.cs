using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TEST.Models;
using TEST.Services;
using TEST.Views;

namespace TEST.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        // --------------------- ПОДГОТОВИТЕЛЬНЫЕ ШТУКИ --------------------- 




        private DataService<Character> _characterService = new DataService<Character>();
        private List<Character> _allCharacters;
        private ObservableCollection<Character> _characters;
        private Character _selectedCharacter;

        public RelayCommand LoadCharactersCommand { get; }
        public RelayCommand AddCharactersCommand { get; }
        public RelayCommand DeleteCharactersCommand { get; }
        public RelayCommand UpdateCharactersCommand { get; }


        public ObservableCollection<Character> Characters
        {
            get => _characters;
            set { _characters = value; OnPropertyChanged(); }
        }


        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set { _selectedCharacter = value; OnPropertyChanged(); }
        }





        // --------------------- МЯСО --------------------- 



        // Конструктор DriverViewModel
        public CharactersViewModel()
        {
            // Инициализируем коллекцию
            _characters = new ObservableCollection<Character>();

            LoadCharactersCommand = new RelayCommand(LoadCharacters);
            AddCharactersCommand = new RelayCommand(AddCharacters);
            DeleteCharactersCommand = new RelayCommand(DeleteCharacters);
            UpdateCharactersCommand = new RelayCommand(LoadCharacters);

            LoadCharacters();
        }


        public void LoadCharacters() // ЧТЕНИЕ
        {
            try
            {
                _allCharacters = _characterService.GetAll();
                _characters.Clear();
                foreach (var character in _allCharacters)
                {
                    _characters.Add(character);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Ошибка при загрузке списка");
            }

        }


        public void AddCharacters() // ДОБАВЛЕНИЕ
        {
            var addCharacter = new AddCharacterView();

            if (addCharacter.ShowDialog() == true)
            {
                var newCharacter = addCharacter.NewCharacter;
                if (newCharacter != null)
                {
                    try
                    {
                        _characterService.Add(newCharacter);
                        LoadCharacters();
                        MessageBox.Show("Персонаж успешно добавлен!");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        MessageBox.Show($"Ошибка при добавлении персонажа: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteCharacters()
        {
            if (SelectedCharacter != null)
            {
                var result = MessageBox.Show(
                 $"Удалить {SelectedCharacter.CharacterName}?",
                 "Подтверждение",
                 MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    _characterService.Delete(SelectedCharacter);
                    LoadCharacters() ;
                }
            }
        }

        public void UpdateCharacters()
        {
            if (SelectedCharacter != null)
            {
                var updateWindow = new UpdateCharacterWindow(SelectedCharacter);
                if (updateWindow.ShowDialog() == true)
                {
                    var updatedDriver = updateWindow.EditedCharacter;

                    try
                    {
                        _characterService.Update(updatedDriver);
                        LoadCharacters();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }
        }
    }
}
