using System;
using System.Windows.Forms;
using System.Drawing;

/**
 * Малахов Максим
 * 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в
 * наследниках.
 * 3. Сделать так, чтобы при столкновениях пули с астероидом пуля и астероид регенерировались в
 * разных концах экрана;
 * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина больше
 * 1000 или принимает отрицательное значение, то выбросить исключение
 * ArgumentOutOfRangeException().
 * 5. *Создать собственное исключение GameObjectException, которое появляется при попытке
 * создать объект с неправильными характеристиками (например, отрицательные размеры,
 * слишком большая скорость или позиция).
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
