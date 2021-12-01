using System;
using System.Collections.Generic;
using ToDoList.Core.ViewModels.Controls;

namespace ToDoList.Core.ViewModels.Pages
{
    class WorkTaskPagesViewModel
    {
        private string netWorkTasktitle;

        public List<WorkTaskViewModel> WotkTaskList { get; set; } = new List<WorkTaskViewModel>();
        public string NetWorkTaskTitle { get; set; }
        public string NetWotkTaskDesctipion { get; set; }
        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NetWorkTaskTitle,
                Description = NetWotkTaskDesctipion,
                CreatedDate = DateTime.Now
            };
            WotkTaskList.Add(newTask);

        }
    }
}
