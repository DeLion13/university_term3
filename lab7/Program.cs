using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================TASK-1=============================================");
            
            List<ProductStruct> buys = new List<ProductStruct>();

            ProductStruct cheese = new ProductStruct("Cheese Bri", 12345, 12);
            ProductStruct cake = new ProductStruct("Cake Prazen", 12346, 54);
            ProductStruct juice = new ProductStruct("Juice Sandora", 12347, 31);
            ProductStruct sushi = new ProductStruct("Roll California", 12348, 5);

            List<DiscountStruct> discounts = new List<DiscountStruct>();

            DiscountStruct cheese_d = new DiscountStruct(80, 12345);
            DiscountStruct cake_d = new DiscountStruct(50, 12346);
            DiscountStruct sushi_d = new DiscountStruct(90, 12348);

            discounts.Add(cheese_d);
            discounts.Add(cake_d);
            discounts.Add(sushi_d);

            buys.Add(cheese);
            buys.Add(cake);
            buys.Add(juice);
            buys.Add(sushi);

            DiscountChecker check = new DiscountChecker(discounts);

            check.DoDiscount(buys);

            Console.WriteLine("=============================================TASK-2=============================================");
            
            int height = 30;
            int width = 60;
            char[,] map = new char[height, width];
            ColorFactory factory = new ColorFactory();

            for (int i = 0; i < height / 2; i++) {
                for (int j = 0; j < width; j++) {
                    map[i, j] = 'B';
                }
            }

            for (int i = height / 2; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    map[i, j] = 'Y';
                }
            }

            Console.WriteLine("==================Ukraine==================");
            
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    Color bit = factory.GetColor(map[i, j]);
                    bit.Display();
                }
                Console.Write('\n');
            }

            Console.WriteLine("==================Deuchland==================");
            
            for (int i = 0; i < height / 3; i++) {
                for (int j = 0; j < width; j++) {
                    map[i, j] = 'D';
                }
            }

            for (int i = height / 3; i < 2 * height / 3; i++) {
                for (int j = 0; j < width; j++) {
                    map[i, j] = 'R';
                }
            }

            for (int i = 2 * height / 3; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    map[i, j] = 'Y';
                }
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    Color bit = factory.GetColor(map[i, j]);
                    bit.Display();
                }
                Console.Write('\n');
            }

            Console.ReadKey();
        }
    }
}
