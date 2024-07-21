using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string r_Title;
        internal MenuItem(string i_Title)
        {
            this.r_Title = i_Title;
        }
        internal string Title
        {
            get
            {
                return r_Title;
            }
        }
    }
}
