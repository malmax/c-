using System;
using System.Windows.Forms;
using System.Drawing;

/**
 * Малахов Максим
 */

namespace thegame
{
    class Program
    {
        static void Main(string[] arg)
        {
            
            Form form = new Form();
            form.Width = 800;
            form.Height = 530;
            form.BackgroundImage = Image.FromFile("space.jpg");
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }



    }
}
