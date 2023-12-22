using System;
using System.Linq;
using System.Collections.Generic;


namespace SomeMeth
{
    class Render
    {
        private List<int[]> numbers;
        private int tableLenght;
        char renderSumbol;

        public Render(List<int[]> numbersForRender, int lenghtOfTable = 100, string sumbol = "_")
        {
            
            numbers = numbersForRender;
            tableLenght = lenghtOfTable;
            renderSumbol = Convert.ToChar(sumbol);
        }

        private string getRenderOneNumber(int first, int second, int result)
        {

            string stringNumber = $"{first}*{second}   |   {result}";

            int lenghtDifference = tableLenght - stringNumber.Length;

            double value = lenghtDifference / 2;
            double spacesCount = Math.Floor(value);

            int spacesLenght = Convert.ToInt32(spacesCount);
            string spaces = string.Concat(Enumerable.Repeat(" ", spacesLenght));


            return $"|{spaces}{stringNumber}{spaces}|";
        }

        private void renderOneNumber(int first, int second, int result)
        {


            string renderResult = getRenderOneNumber(first, second, result);

            Console.WriteLine(renderResult);
        }

        private string getRenderOneLine(bool withVerticalLine = false)
        {
            string text;

            if (withVerticalLine == true)
            {
                string line = string.Concat(Enumerable.Repeat(renderSumbol, tableLenght));
                text = $"{line}|";
            }

            else
            {
                string line = string.Concat(Enumerable.Repeat(renderSumbol, tableLenght));
                text = $"{line}";
            }

            return text;
        }


        private void renderOneLine(bool withVerticalLine = false)
        {
            string line = getRenderOneLine(withVerticalLine);

            Console.WriteLine(line);
        }

        public void render()
        {

            renderOneLine();

            int lenght = numbers.Count;

            for (int i = 0; i<lenght; i++)
            {
                int first = numbers[i][0];
                int second = numbers[i][1];
                int result = numbers[i][2];

                renderOneNumber(first, second, result);
                renderOneLine(true);


            }
        }
    }


    class Counter
    {
        public List<int[]> getMethValues(int number)
        {
            List<int[]> result = new List<int[]>();
            
            for (int i = 1; i<11; i++)
            {
                int[] values = {number, i, number*i};

                result.Add(values);
            }

            return result;
        }
    }


    class Program
    {

        

        static void Main(string[] args)
        {  
            Counter counter = new Counter();

            while (true)
            {
                Console.WriteLine("Введите число, таблицу умножения которого вы хотите увидеть: ");
            
                string value = Console.ReadLine();
                int number = Convert.ToInt32(value);


                List<int[]> values = counter.getMethValues(number);

                Render render = new Render(values);

                render.render();

            }

            
        }
    }
}
