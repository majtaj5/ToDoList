using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToDoList.Core.Helpers;
using ToDoList.Core.ViewModels.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ToDoList.DataBase.Entities;

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
            foreach (var task in DataBaseLocator.Database.WorkTasks.ToList())
            {
                WorkTaskList.Add(new WorkTaskViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    CreatedDate = task.CreatedDate
                }); 
            }
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

            DataBaseLocator.Database.WorkTasks.Add(new WorkTask
            {
                
                Title = newTask.Title,
                Description = newTask.Description,
                CreatedDate = newTask.CreatedDate
            });

            DataBaseLocator.Database.SaveChanges();

            NetWorkTaskTitle = string.Empty;
            NetWotkTaskDesctipion = string.Empty;

        }
        private void DeleteSelectedTask()
        {
            var selctedTasks = WorkTaskList.Where(x => x.IsSelected).ToList();
            foreach (var task in selctedTasks)
            {
                WorkTaskList.Remove(task);
                var foundEntity = DataBaseLocator.Database.WorkTasks.FirstOrDefault(x=>x.Id==task.Id);

                if (foundEntity != null)
                {
                    DataBaseLocator.Database.WorkTasks.Remove(foundEntity);
                }

                DataBaseLocator.Database.SaveChanges();
            }
        }
    }
}
