using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class FinalItem : MenuItem
    {
        private List<IActionChoiceHandler> m_ActionsListChoiceHandler;
        public FinalItem(string i_Title) : base(i_Title)
        {
            this.m_ActionsListChoiceHandler = new List<IActionChoiceHandler>();           
        }
        public void addActionChoiceHandlerToList(IActionChoiceHandler i_ActionChoiceHandler)
        {
            m_ActionsListChoiceHandler.Add(i_ActionChoiceHandler);
        }
        public void OnSelected()
        {
            foreach(IActionChoiceHandler actionFinalItem in m_ActionsListChoiceHandler)
            {
                actionFinalItem.InvokeAction();
            }
        }
    }
}
