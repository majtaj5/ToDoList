using System.Windows.Controls;
using ToDoList.Core.ViewModels.Pages;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for WorkTaskPage.xaml
    /// </summary>
    public partial class WorkTaskPage : Page
    {
        public WorkTaskPage()
        {
            InitializeComponent();
            DataContext = new WorkTaskPagesViewModel();
        }
    }
}
