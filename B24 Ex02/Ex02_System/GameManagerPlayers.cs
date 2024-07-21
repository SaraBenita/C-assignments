using System.Collections.Generic;

namespace Ex02_System
{
    internal class GameManagerPlayers
    {
        private List<Player> m_PlayersArray;
        private int m_numPlayers;
        private int m_CurrentPlayerOfRound;
        internal GameManagerPlayers()
        {            
            this.m_PlayersArray = new List<Player>();
            this.m_numPlayers = 0;
            this.m_CurrentPlayerOfRound = 0;
        }
        private void addPlayerToGame(string i_PlayerName, bool i_IsComputer)
        {
            Player newPlayer = new Player(i_PlayerName, i_IsComputer);

            this.m_PlayersArray.Add(newPlayer);
            this.m_numPlayers++;
        }
        internal void AddPointToScoreForCurrentPlayer()
        {
            this.m_PlayersArray[this.m_CurrentPlayerOfRound].AddPointToScore();
        }
        internal void AddPlayersToListOfPlayers(List<string> i_PlayersNames,
            List<bool> i_IsComputerPerIndexInListNames)
        {
            for(int i=0; i < i_PlayersNames.Count; i++)
            {
                addPlayerToGame(i_PlayersNames[i], i_IsComputerPerIndexInListNames[i]);
            }
        }
        internal void GetNamesListAndScoresListOfPlayers(List<string> i_PlayersName,
            List<int> i_ScorePerIndexInListPlayersNames)
        {
            foreach(Player player in this.m_PlayersArray)
            {
                i_PlayersName.Add(player.PlayerName);
                i_ScorePerIndexInListPlayersNames.Add(player.PointScore);
            }
        }
        internal void GetNameAndScoreOfCurrentPlayer(out string o_PlayerName, out int o_PlayerScore)
        {
            o_PlayerName = this.m_PlayersArray[this.m_CurrentPlayerOfRound].PlayerName;
            o_PlayerScore = this.m_PlayersArray[this.m_CurrentPlayerOfRound].PointScore;
        }
        internal void SwitchPlayerTurn()
        {
            this.m_CurrentPlayerOfRound = (this.m_CurrentPlayerOfRound + 1) % this.m_numPlayers;
        } 
        internal bool IsComputerTurn()
        {
            return this.m_PlayersArray[this.m_CurrentPlayerOfRound].IsComputerPlayer;
        }
    }
}
