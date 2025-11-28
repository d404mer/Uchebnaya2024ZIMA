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
using TEST.ViewModels;

namespace TEST.Views
{
    /// <summary>
    /// Логика взаимодействия для CharactersDataGridView.xaml
    /// </summary>
    public partial class CharactersDataGridView : Window
    {

        private CharactersViewModel _viewModel;
        public CharactersDataGridView()
        {

            InitializeComponent();

            _viewModel = new CharactersViewModel();
            this.DataContext = _viewModel;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteCharacters();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCharacters();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _viewModel.UpdateCharacters();
        }


    }
}
