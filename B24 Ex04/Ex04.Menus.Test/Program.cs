
namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu mainMenuInterface;
            Events.MainMenu mainMenuEvents; 

            mainMenuInterface = BuildMenu.BuildMenuInterface();
            mainMenuInterface.Show();
            mainMenuEvents = BuildMenu.BuildMenuEvents();
            mainMenuEvents.Show();
        }
    }
}
