using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private SubMenu m_SubMenu;
        public MainMenu(SubMenu i_SubMenu)
        {
            this.m_SubMenu = i_SubMenu;
        }
        public void Show()
        {
            m_SubMenu.Show();
        } 
    }
}
