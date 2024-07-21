using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public delegate void ActionChoiceHandler();
    public class FinalItem : MenuItem
    {
        public event ActionChoiceHandler Selected;
        public FinalItem(string i_Title, ActionChoiceHandler i_ActionChoiceHandler) : base(i_Title)
        {
            this.Selected += i_ActionChoiceHandler;
        }
        internal void FinalItem_Selected()
        {
            OnSelected();
        }
        protected virtual void OnSelected()
        {
            Selected?.Invoke();
        }
    }
}
