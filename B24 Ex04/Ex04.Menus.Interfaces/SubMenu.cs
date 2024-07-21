using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        private List<MenuItem> m_MenuItemsList;
        private bool m_isFirstLevel;
        public SubMenu(string i_Title, bool i_isFirstLevel) : base(i_Title)
        {
            this.m_MenuItemsList = new List<MenuItem>();
            this.m_isFirstLevel = i_isFirstLevel;
        }
        internal void Show()
        {
            int userChoice;
            string userChoiceStr;

            while (true)
            {
                printSubMenu();
                userChoiceStr = getUserChoice();
                try
                {
                    userChoice = checkUserChoice(userChoiceStr);
                    if (userChoice == 0)
                    {
                        return;
                    }
                    else
                    {
                        handleMenuItemSelectedByUser(userChoice);
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Illegal User Choice(enter only digit)");
                    System.Threading.Thread.Sleep(2000);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("Illegal User Choice(out of range)");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
        private string getUserChoice()
        {
            string userChoiceStr;

            Console.WriteLine(string.Format(@"
------------------------------------------------------
Enter your request: ({0} to {1} or press '0' to {2}).",
                   1, this.m_MenuItemsList.Count, getTypeForQuitChoice()));
            userChoiceStr = Console.ReadLine();

            return userChoiceStr;
        }
        private int checkUserChoice(string userChoiceStr)
        {
            bool isDataInRange;
            int userChoice;

            userChoice = int.Parse(userChoiceStr);
            isDataInRange = userChoice <= this.m_MenuItemsList.Count && userChoice >= 0;
            if (!isDataInRange)
            {
                throw new IndexOutOfRangeException();
            }

            return userChoice;
        }
        private void handleMenuItemSelectedByUser(int i_UserChoice)
        {
            if (this.m_MenuItemsList[i_UserChoice - 1] is SubMenu)
            {
                (this.m_MenuItemsList[i_UserChoice - 1] as SubMenu).Show();
            }

            if (this.m_MenuItemsList[i_UserChoice - 1] is FinalItem)
            {
                (this.m_MenuItemsList[i_UserChoice - 1] as FinalItem).OnSelected();
                System.Threading.Thread.Sleep(2000);
            }
        }
        private void printSubMenu()
        {
            Console.Clear();
            printMenuTitle();
            for (int i = 0; i < this.m_MenuItemsList.Count; i++)
            {
                Console.WriteLine(string.Format(@"{0} -> {1}", (i + 1), this.m_MenuItemsList[i].Title));
            }

            Console.Write(string.Format(@"{0} -> {1}", 0, getTypeForQuitChoice()));
        }
        private void printMenuTitle()
        {
            Console.WriteLine(string.Format(@"***{0}***
------------------------------------------------------",this.Title));
        }
        private string getTypeForQuitChoice()
        {
            return this.m_isFirstLevel ? "Exit" : "Back";
        }
        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItemsList.Add(i_MenuItem);
        }
    }
}
