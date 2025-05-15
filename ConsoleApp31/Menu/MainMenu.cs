using ConsoleApp31.DataBase;
using ConsoleApp31.Enums;

namespace ConsoleApp31.Menu
{
    public class MainMenu
    {
        private readonly BlogService blogService;
        private readonly Login login;
        public MainMenu(BlogService blogService, Login login)
        {
            this.blogService = blogService;
            this.login = login;
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
                                login.Authenticate(password);
                                break;
                            }
                        case MainMenuOptions.CheckBlogs:
                            {
                                blogService.ShowAllBlogsWithDetails();
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
