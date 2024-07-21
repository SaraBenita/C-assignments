using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_ValueDescription;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ValueDescription)
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
            this.m_ValueDescription = i_ValueDescription;
        }
        public override string Message
        {
            get
            {
                return string.Format("The {0} must be between {1} - {2}",
                    this.m_ValueDescription, this.m_MinValue, this.m_MaxValue);
            }
        }
    }
}
