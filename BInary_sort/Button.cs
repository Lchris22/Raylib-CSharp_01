using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace BInary_sort
{
    class Button
    {

        public string name;
        public bool btnState;
        public Rectangle rec = new Rectangle();
        public Button(string _name, int x, int y, int width, int height)
        {
            Console.WriteLine(name);
            btnState = false;
            name = _name;
            rec.x = x;
            rec.y = y;
            rec.width = width;
            rec.height = height;

        }
        public bool is_buttonPressed()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec))
            {
                if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON)) btnState = true;
                else btnState = false;

            }
            else btnState = false;

            return btnState;
        }

        public void DrawButton()
        {
            Raylib.DrawRectangleRec(rec, Color.GREEN);
            Raylib.DrawText(name, Convert.ToInt32(rec.x) + 10, Convert.ToInt32(rec.y) + 10, 15, Color.BLACK);


        }
    }

}

