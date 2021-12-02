using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToDoList.Core.Helpers;
using ToDoList.Core.ViewModels.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ToDoList.Core.ViewModels.Pages
{
    public class WorkTaskPagesViewModel :BaseViewModel
    {   
        

        public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();
        public string NetWorkTaskTitle { get; set; }
        public string NetWotkTaskDesctipion { get; set; }
        public ICommand AddNewTaskCommand { get; set; }
        public ICommand DeleteSelectedTaskCommand { get; set; }
        public WorkTaskPagesViewModel()
        {
            AddNewTaskCommand = new RelayCommand(AddNewTask);
            DeleteSelectedTaskCommand = new RelayCommand(DeleteSelectedTask);
        }
        
        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NetWorkTaskTitle,
                Description = NetWotkTaskDesctipion,
                CreatedDate = DateTime.Now
            };
            WorkTaskList.Add(newTask);

            NetWorkTaskTitle = string.Empty;
            NetWotkTaskDesctipion = string.Empty;

        }
        private void DeleteSelectedTask()
        {
            var selctedTasks = WorkTaskList.Where(x => x.IsSelected).ToList();
            foreach (var task in selctedTasks)
            {
                WorkTaskList.Remove(task);
            }
        }
    }
}
