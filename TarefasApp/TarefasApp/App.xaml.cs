using Microsoft.Maui.Controls;
using TarefasApp.Pages;
using TarefasApp.Services;

namespace TarefasApp
{
    public partial class App : Application
    {
        public static TaskService TaskService { get; private set; }

        public App()
        {
            InitializeComponent();

            TaskService = new TaskService();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}