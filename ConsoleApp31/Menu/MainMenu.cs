using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using ConsoleApp31.Enums;

namespace ConsoleApp31.Menu
{
    public class MainMenu
    {
        private readonly IBlogService _blogService;
        private readonly Login _login;
        public MainMenu(IBlogService blogService, Login login)
        {
            _blogService = blogService;
            _login = login;
        }
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Увійти в аккаунт\n2. Переглянути блоги\n9. Вихід");
                if (Enum.TryParse(Console.ReadLine(), out MainMenuOptions choice))
                {
                    switch (choice)
                    {
                        case MainMenuOptions.Login:
                            {
                                Console.Clear();
                                Console.Write("Введіть пароль: ");
                                string password = Console.ReadLine()!;
                                _login.Authenticate(password);
                                break;
                            }
                        case MainMenuOptions.CheckBlogs:
                            {
                                _blogService.ShowAllBlogsWithDetails();
                                Console.ReadLine();
                                break;
                            }
                        case MainMenuOptions.Exit:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Невідома опція");
                                break;
                            }
                    }
                }
            }
        }
    }
}
