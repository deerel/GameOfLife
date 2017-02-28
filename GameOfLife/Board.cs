using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        private Square[] squares;
        private int m_count = 16;
        private int m_squareSize = 15;
        private int m_topMargin = 40;

        public Board(int count, int squareSize, int topMargin)
        {
            m_count = count;
            m_squareSize = squareSize;
            m_topMargin = topMargin;
            squares = new Square[m_count * m_count];
            init();
        }

        private void init()
        {
            for(int i = 0; i < (m_count * m_count); i++)
            {
                int x = (i % m_count) * (m_squareSize + 1);
                int y = (i / m_count) * (m_squareSize + 1) + m_topMargin;
                squares[i] = new Square(new System.Drawing.Point(x,y), m_squareSize);
            }
        }

        public Square square(int i)
        {
            if(i<(m_count*m_count) && i>-1)
            {
                return squares[i];
            }

            return null;
        }

        public void run(object data)
        {
            int s = (int)data;
            while (s > 0)
            {
                updateSquareState();
                updateSquareDisplay();
                s--;
                System.Threading.Thread.Sleep(100);
            }
            
        }

        private void updateSquareState()
        {
            for(int i = 0; i<squares.Length; i++)
            {
                int neighbours = getNeighbourCount(i);
                if(neighbours > 3 || neighbours < 2)
                {
                    squares[i].setState(false);
                }
                else if (neighbours == 3)
                {
                    squares[i].setState(true);
                }
                else
                {
                    squares[i].setState();
                }
            }
        }

        private void updateSquareDisplay()
        {
            foreach(Square s in squares)
            {
                s.updateDisplay();
            }
        }

        private int getNeighbourCount(int squareIndex)
        {
            int[] neighbours = getNeighbourIndexes(squareIndex);
            int neighbourCount = 0;
            foreach(int i in neighbours)
            {
                if(i >= 0 && i < squares.Length && squares[i].isAlive() && i != squareIndex && Math.Abs((i%m_count)-(squareIndex%m_count)) <= 1)
                {
                    neighbourCount++;
                }
            }

            return neighbourCount;
        }

        private int[] getNeighbourIndexes(int si)
        {
            int[] index = new int[9];

            index[0] = si - m_count - 1;
            index[1] = si - m_count;
            index[2] = si - m_count + 1;

            index[3] = si - 1;
            index[4] = si;
            index[5] = si + 1;

            index[6] = si + m_count - 1;
            index[7] = si + m_count;
            index[8] = si + m_count + 1;

            return index;
        }
    }

}
