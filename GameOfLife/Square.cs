using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameOfLife
{
    class Square
    {
        private Panel m_panel;
        private bool m_alive;
        private bool m_nextState;
        public Square(Point location, int size)
        {
            // Default state, not alive
            m_alive = false;
            m_nextState = false;
            // Setting up graphical representation
            m_panel = new Panel();
            m_panel.Height = size;
            m_panel.Width = size;
            m_panel.Location = location;
            m_panel.BackColor = Color.White;
            m_panel.Click += new EventHandler(Square_Click);

        }

        private void toggle()
        {
            if (m_alive)
            {
                this.m_panel.BackColor = Color.White;
            }
            else
            {
                this.m_panel.BackColor = Color.Black;
            }

            m_alive = !m_alive;
        }

        private void update()
        {
            if (m_alive)
            {
                this.m_panel.BackColor = Color.Black;
            }
            else
            {
                this.m_panel.BackColor = Color.White;
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            toggle();      
        }

        public void updateDisplay()
        {
            m_alive = m_nextState;
            update();
        }

        public Panel panel()
        {
            return this.m_panel;
        }

        public bool isAlive()
        {
            return m_alive;
        }

        public void setState(bool state)
        {
            m_nextState = state;
        }

        public void setState()
        {
            m_nextState = m_alive;
        }

    }
}
