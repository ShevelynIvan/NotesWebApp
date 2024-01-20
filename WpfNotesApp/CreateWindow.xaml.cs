using Contracts;
using NotesProcessor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace WpfNotesApp
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private NoteProcessor _np;
        private Note _noteToCreate;
        public CreateWindow(NoteProcessor noteProcessor)
        {
            InitializeComponent();
            _np = noteProcessor;
            _noteToCreate = new Note();
            this.DataContext = _noteToCreate;
        }

        private void CreateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            int priority;
            if (int.TryParse(PriorityTextBox.Text, out priority))
            {
                _noteToCreate.Priority = priority;
                _noteToCreate.Name = NameTextBox.Text;
                _noteToCreate.Value = ValueTextBox.Text;
                if (CheckForNoteValidation(_noteToCreate))
                {
                    try
                    {
                        _np.Create(_noteToCreate);
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
