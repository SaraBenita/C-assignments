
namespace Ex04.Menus.Test
{
    internal class BuildMenu
    {
        internal static Interfaces.MainMenu BuildMenuInterface()
        {
            Interfaces.MainMenu mainMenu;
            Interfaces.FinalItem finalItem;

            Interfaces.SubMenu mainSubMenu = new Interfaces.SubMenu("Interface Main Menu", true);
            Interfaces.SubMenu firstSubMenu = new Interfaces.SubMenu("Version and Capitals", false);
            finalItem = new Interfaces.FinalItem("Show Version");
            finalItem.addActionChoiceHandlerToList(new ShowVersion());
            firstSubMenu.AddMenuItem(finalItem);
            finalItem = new Interfaces.FinalItem("Count Capitals");
            finalItem.addActionChoiceHandlerToList(new CountCapitals());
            firstSubMenu.AddMenuItem(finalItem);
            Interfaces.SubMenu secondSubMenu = new Interfaces.SubMenu("Show Data/Time", false);
            finalItem = new Interfaces.FinalItem("Show Time");
            finalItem.addActionChoiceHandlerToList(new ShowTime());
            secondSubMenu.AddMenuItem(finalItem);
            finalItem = new Interfaces.FinalItem("Show Date");
            finalItem.addActionChoiceHandlerToList(new ShowDate());
            secondSubMenu.AddMenuItem(finalItem);
            mainSubMenu.AddMenuItem(firstSubMenu);
            mainSubMenu.AddMenuItem(secondSubMenu);
            mainMenu = new Interfaces.MainMenu(mainSubMenu);

            return mainMenu;
        }
        internal static Events.MainMenu BuildMenuEvents()
        {
            Events.MainMenu mainMenu;

            Events.SubMenu mainSubMenu = new Events.SubMenu("Delegates Main Menu", true);
            Events.SubMenu firstSubMenu = new Events.SubMenu("Version and Capitals", false);
            firstSubMenu.AddMenuItem(new Events.FinalItem("Show Version", ActionsForMenuEvents.ShowVersion));
            firstSubMenu.AddMenuItem(new Events.FinalItem("Count Capitals", ActionsForMenuEvents.CountCapitals));
            Events.SubMenu secondSubMenu = new Events.SubMenu("Show Data/Time", false);
            secondSubMenu.AddMenuItem(new Events.FinalItem("Show Time", ActionsForMenuEvents.ShowTime));
            secondSubMenu.AddMenuItem(new Events.FinalItem("Show Date", ActionsForMenuEvents.ShowDate));
            mainSubMenu.AddMenuItem(firstSubMenu);
            mainSubMenu.AddMenuItem(secondSubMenu);
            mainMenu = new Events.MainMenu(mainSubMenu);

            return mainMenu;
        }
    }
}
