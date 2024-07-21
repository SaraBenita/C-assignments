

namespace Ex02_System
{
    internal class Player
    {
        private readonly string r_PlayerName;
        private readonly bool r_IsComputerPlayer;
        private int m_PointScore;
      
        internal Player(string i_PlayerName, bool i_IsComputerPlayer)
        {
            this.r_PlayerName = i_PlayerName;
            this.r_IsComputerPlayer = i_IsComputerPlayer;
            this.m_PointScore = 0;
        }
        internal int PointScore
        {
            get
            {
                return this.m_PointScore;
            }
        }
        internal string PlayerName
        {
            get
            {
                return this.r_PlayerName;
            }
        }
        internal bool IsComputerPlayer
        {
            get
            {
                return this.r_IsComputerPlayer;
            }
        }
        internal void AddPointToScore()
        {
            this.m_PointScore++;
        }
    }
}
