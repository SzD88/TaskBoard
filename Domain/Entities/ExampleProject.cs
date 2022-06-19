using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExampleProject
    {
        public Project Project1 { get; protected set; } = new Project("Empty");
         
        public SubTask MasterTask1 { get; protected set; } = new SubTask("Empty");


        public ExampleProject()
        {
            SetMasterTask();
            SetProject();
        }
         
        public SubTask SubTask1 = new SubTask("Wykonanie grzałek")
        {
            Note = new Note("Grzałki zamówić do 12 października 2023"),
            Tasks = new List<SubTask>()
            {
                new SubTask("Dobrać grzałki 12x3kW"),
                new SubTask("Wpasować grzałki w kanał")
            }

        };
        public SubTask SubTask2 = new SubTask("Wykonanie mieszacza")
        {
            Note = new Note("Zamówic standardowy mieszacz fi 400"),
            Tasks = new List<SubTask>()
            {
                new SubTask("Sprawdzić stan magazynowy"),
                new SubTask("Dopilnować zamówienia")
            }

        };

        private void SetMasterTask()
        {
            MasterTask1.Description = "Wykonanie komory grzania";
            MasterTask1.Tasks.Add(SubTask1);   
            MasterTask1.Tasks.Add(SubTask2);   
            
        }
        private void SetProject()
        {
            Project1.Description = "Piec komorowy";
            Project1.MasterTasks.Add(MasterTask1);
        }
    }
}
