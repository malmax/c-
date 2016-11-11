using System;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.Show();
            Game.Init(form);
            
            Application.Run(form);
        }
    }
}
