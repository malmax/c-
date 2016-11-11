﻿using System;
using System.Windows.Forms;
using System.Drawing;
namespace Asteroids
{
    static class Game
    {
        //
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static BaseObject[] objs;

        //Свойства
        //Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {
        }

        static public void Init(Form form)  
        {
            //Графическое устройство для вывода графики
            Graphics g;
            //Предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();//Создаем объект - поверхность рисования и связываем его с формой
             //Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            //Связываем буфер в памяти с графическим объектом.
            //Для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            //Таймер для обработки Update и Draw
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        static public void Load()
        {
            objs = new BaseObject[30];
            for (int i = 0; i < objs.Length; i++)
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
        }
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
                obj.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }
    }
}