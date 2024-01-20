using Contracts;
using NotesProcessor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace WpfNotesApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Note _note;
        private NoteProcessor _np;
        public EditWindow(Note note, NoteProcessor noteProcessor)
        {
            InitializeComponent();
            _np = noteProcessor;
            _note = note;
            this.DataContext = _note;
        }

        private void UpdateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            int priority;
            if(int.TryParse(PriorityTextBox.Text, out priority))
            {
                _note.Priority = priority;
                _note.Name = NameTextBox.Text;
                _note.Value = ValueTextBox.Text;
                if (CheckForNoteValidation(_note))
                {
                    try
                    {
                        _np.Update(_note);
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong...");
                    }

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private bool CheckForNoteValidation(Note note)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(note);

            if (!Validator.TryValidateObject(note, context, results, true))
                return false;
            
            return true;
        }
    }
}
