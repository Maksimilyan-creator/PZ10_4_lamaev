using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace PZ10_4_lamaev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Status_notes> Current;
        List<Status_notes> ActiveNotes;
        List<Status_notes> CompleteNotes;
        private List<string> SelectedItems { get; set; } = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Current = new List<Status_notes>() { new Status_notes("dsdlkd", Status.Active)};
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Current_TextBox.Text == "" || Current_TextBox.Text == null) return;
            Current.Add(new Status_notes(Current_TextBox.Text, Status.Active));
            Update();
        }

        private void Current_tasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Current_tasks.SelectedItem == null) return;
            var a = Current.FindIndex(u => u == Current_tasks.SelectedItem);
            Current[a].status = Status.completed;
            Update();
        }
        public void Update()
        {
            ActiveNotes = Current.Where(u => u.status == Status.Active).ToList();
            CompleteNotes = Current.Where(u => u.status == Status.completed).ToList();
            Current_tasks.ItemsSource = ActiveNotes;
            Сompleted_tasks.ItemsSource = CompleteNotes;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Сompleted_tasks.SelectedItems == null) return;
            foreach (var item in Сompleted_tasks.SelectedItems)
            {
                Current.Remove((Status_notes)item);
            }
            Update();

        }
    }
}
