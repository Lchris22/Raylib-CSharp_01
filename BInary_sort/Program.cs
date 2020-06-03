using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Linq;

namespace BInary_sort
{
    class Program
    {
        static int screenWidth = 1370;
        static int screenHeight = 720;
        static int[] array = new int[1000];
        static int i_element = 0;
        static int j_element = 0;
        static bool temp = true;

        static bool drawing_repetition = false;
        static void Main(string[] args)
        {

            Raylib.InitWindow(screenWidth, screenHeight, "Notes");
            Raylib.SetTargetFPS(100);


            //ui elements
            Button button_Sort = new Button("Sort", 700, 100, 70, 40);
            Button button_Randomize = new Button("Randomize", 700, 180, 70, 40);


            //variables

            int width = 1000 / array.Length;

            set_array_values_random();
            while (!Raylib.WindowShouldClose())
            {
                



                Raylib.BeginDrawing();
                if (temp == true)
                {
                    draw_array_shapes();
                }










                //button press
                if (button_Randomize.is_buttonPressed())
                {
                    Raylib.ClearBackground(Color.RAYWHITE);
                    set_array_values_random();
                    temp = true;
                    drawing_repetition = false;
                }
                if (button_Sort.is_buttonPressed())
                {
                    drawing_repetition = true;
                    temp = false;
                }

                if(drawing_repetition==true)
                {
                    bubble_sort(array);
                    Raylib.ClearBackground(Color.RAYWHITE);
                    draw_array_shapes();
                    Console.WriteLine("rep on");
                }



                draw_ui_elements(button_Sort, button_Randomize);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
        private static void bubble_sort(int[] arr)
        {
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                time_passing(0.0);
                //j_element++;
                for (int i = i_element; i <= arr.Length - 2; i++)
                {
                    i_element++;
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                    

                }
                i_element = 0;
                
                //drawing_repetition = false;

            }
            return;

        }
        private static void set_array_values_random()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                array[i] = random.Next(100, 500);
            }
        }

        public static void draw_array_shapes()
        {
            int start_point = 10;
            int lowest = array[1];
            int highest = array[1];
            for (int i = 0; i < array.Length; i++)
            {
                //Rectangle rec = new Rectangle(start_point, 50, (100 / array.Length), array[i]);
                Raylib.DrawRectangle(start_point, 50, (1000 / array.Length), array[i], Color.BLUE);
                

                if(lowest>array[i])
                {
                    lowest = array[i];
                    Raylib.DrawRectangle(start_point, 50, (1000 / array.Length), array[i], Color.RED);
                }
                start_point += (1000 / array.Length);
            }
            temp = false;
        }

        public static void draw_ui_elements(Button button_Add, Button button_save)
        {
            Rectangle rec = new Rectangle(0, 0, screenWidth, screenHeight);
            Raylib.DrawRectangleLinesEx(rec, 5, Color.BLACK);
            button_Add.DrawButton();
            button_save.DrawButton();
        }
        private static void time_passing(double x)
        {
            double y = Raylib.GetTime() + x;
            while (Raylib.GetTime() < y)
            {
            }
            //Console.WriteLine(Raylib.GetTime());
        }

    }
}
