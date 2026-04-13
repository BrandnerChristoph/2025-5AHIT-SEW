using StudentGradeManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentGradeManagement.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Student> Students { get; set; } = new();

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        // Neue Note
        private int _newGradeValue;
        public int NewGradeValue
        {
            get => _newGradeValue;
            set
            {
                _newGradeValue = value;
                OnPropertyChanged();
            }
        }

        private string _newSubject;
        public string NewSubject
        {
            get => _newSubject;
            set
            {
                _newSubject = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public RelayCommand AddStudentCommand { get; }
        public RelayCommand DeleteStudentCommand { get; }
        public RelayCommand AddGradeCommand { get; }

        public StudentViewModel()
        {
            AddStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            AddGradeCommand = new RelayCommand(AddGrade);
        }

        private void AddStudent()
        {
            Students.Add(new Student { Name = "Neuer Schüler", Class = "IT" });
        }

        private void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                var result = MessageBox.Show($"Soll der Student ({SelectedStudent.Name}) gelöscht werden?", "Löschen bestätigen", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                    Students.Remove(SelectedStudent);
            }
            else
                MessageBox.Show("Es konnte kein Schüler gelöscht werden, da keiner gewählt wurde!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddGrade()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("kein Schüler gewählt", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (NewGradeValue < 1 || NewGradeValue > 5)
            {
                MessageBox.Show("kein gültige Noteneingabe", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(NewSubject))
            {
                MessageBox.Show("kein Fach angegeben!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SelectedStudent.Grades.Add(new Grade(NewSubject, NewGradeValue));
            OnPropertyChanged(nameof(SelectedStudent));
            NewGradeValue = 0;
            NewSubject = "";            
        }
    }
}