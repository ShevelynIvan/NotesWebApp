using System.Windows;
using NotesProcessor;
using NotesDAL.Repos;
using Contracts;

namespace WpfNotesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NoteProcessor _noteProc; 
        public MainWindow()
        {
            InitializeComponent();
            _noteProc = new NoteProcessor(new NoteRepository());
            DGN.ItemsSource = _noteProc.GetAll();
        }

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow(_noteProc);
            createWindow.Show();
            this.Close();
        }

        private void EditNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note noteToUpdate = DGN.SelectedItem as Note;
            if (noteToUpdate is null)
                return;

            EditWindow editWindow = new EditWindow(noteToUpdate, _noteProc);
            editWindow.Show();
            this.Close();
        }

        private void DeleteNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note noteToDelete = DGN.SelectedItem as Note;
            if (noteToDelete is null)
                return;

            MessageBoxResult result = MessageBox.Show(
                $"Are you sure you want to delete this note:\n{noteToDelete.Name} ?", 
                "Message", 
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _noteProc.Delete(noteToDelete.Id);
                    DGN.ItemsSource = _noteProc.GetAll();
                }
                catch 
                {
                    MessageBox.Show("Something went wrong...");
                }
            }
        }
    }
}
