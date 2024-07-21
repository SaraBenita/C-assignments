
namespace Ex02_System
{
    public class BoardCell
    {
        private int m_PairSymbol;
        private bool m_IsVisibleCell;
        internal BoardCell(int m_PairSymbol)
        {
            this.m_PairSymbol = m_PairSymbol;
            this.m_IsVisibleCell = false;
        }
        public int PairSymbol
        {
            get
            {
                return this.m_PairSymbol;
            }
        }
        public bool IsVisibleCell
        {
            get
            {
                return this.m_IsVisibleCell;
            }
            internal set
            {
                this.m_IsVisibleCell = value;
            }
        }
    }
}
