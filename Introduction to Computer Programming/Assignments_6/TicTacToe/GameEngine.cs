﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_6.TicTacToe
{
    class GameEngine
    {
        private char[] boardArray;
        private const char crossSign = 'X';
        private const char roundSign = 'O';
        private char currentSign;
        private bool mainLoop;
        private const string statsFilePath = "../../GameStatistics/Stats.txt";
        private string crossPlayerName;
        private string roungPlayerName;
        private bool isCrossWin;

        public GameEngine()
        {
            this.boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';
            this.currentSign = roundSign;
            this.mainLoop = true;
            this.isCrossWin = false;
        }

        public char GetCurrentSign()
        {
            return this.currentSign;
        }

        public void PerformMove(int index)
        {
            boardArray[index] = currentSign;
        }

        public bool WinConditions()
        {
            return (boardArray[0] & boardArray[1] & boardArray[2] & currentSign) == currentSign
                ||
                (boardArray[0] & boardArray[3] & boardArray[6] & currentSign) == currentSign
                ||
                (boardArray[0] & boardArray[4] & boardArray[8] & currentSign) == currentSign
                ||
                (boardArray[1] & boardArray[4] & boardArray[7] & currentSign) == currentSign
                ||
                (boardArray[2] & boardArray[5] & boardArray[8] & currentSign) == currentSign
                ||
                (boardArray[2] & boardArray[4] & boardArray[6] & currentSign) == currentSign
                ||
                (boardArray[3] & boardArray[4] & boardArray[5] & currentSign) == currentSign
                ||
                (boardArray[6] & boardArray[7] & boardArray[8] & currentSign) == currentSign;
        }

        public void SignSwitch()
        {
            currentSign = currentSign == crossSign ? roundSign : crossSign;
        }

        public char[] GetBoardArray()
        {
            return this.boardArray;
        }

        public void SetMainloop()
        {
            this.mainLoop = false;
        }

        public bool GetMainLoop()
        {
            return this.mainLoop;
        }

        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index) && index >= 0 && index < 9 && boardArray[index] == ' ';
        }

        public void Reset()
        {
            this.boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';
            this.currentSign = roundSign;
        }

        public void SetCrossPlayerName(string newName)
        {
            this.crossPlayerName = newName;
        }

        public void SetRoundPlayerName(string newName)
        {
            this.roungPlayerName = newName;
        }

        public void setCrossWin()
        {
            this.isCrossWin = true;
        }

        public void SaveStatistics()
        {
            using (StreamWriter sw = File.AppendText(statsFilePath))
            {
                switch (this.isCrossWin)
                {
                    case true:
                        sw.WriteLine($"{crossPlayerName} 1 {roungPlayerName} 0");
                        break;
                    default:
                        sw.WriteLine($"{crossPlayerName} 0 {roungPlayerName} 1");
                        break;
                }
            }
        }
    }
}
