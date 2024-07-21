using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class InputDataDefinition
    {
        private string m_MsgForUser;
        private Type m_InputType;
        private bool m_IsInputSelectedFromList = false;
        private int m_MaxRange = 0;
        internal InputDataDefinition(string i_MsgForUser, Type i_InputType)
        {
            this.m_MsgForUser = i_MsgForUser;
            this.m_InputType = i_InputType;
        }
        public string MsgForUser
        {
            get
            {
                return this.m_MsgForUser;
            }
        }
        public Type InputType
        {
            get
            {
                return this.m_InputType;
            }
        }
        public bool IsInputSelectedFromList
        {
            get
            {
                return this.m_IsInputSelectedFromList;
            }
            internal set
            {
                this.m_IsInputSelectedFromList = value;
            }
        }
        public int MaxRange
        {
            get
            {
                return this.m_MaxRange;
            }
            internal set
            {
                this.m_MaxRange = value;
            }
        }
    }
}
