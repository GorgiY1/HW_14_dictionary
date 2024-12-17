using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14_dictionary
{
    class MyDictionary
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        public MyDictionary()
        {
            dic.Add("Украина", "Ukraine");
            dic.Add("Британия", "Britannia");
            dic.Add("Польша", "Poland");
            dic.Add("Америка", "America");
        }
        public void Print()
        {
            foreach (string item in dic.Keys)
            {
                Console.WriteLine($"Word: {item} - Translate{dic[item]}");
            }

            Console.WriteLine();

            foreach (string item in dic.Keys)
            {
                Console.WriteLine($"Word: {dic[item]} - Translate{item}");
            }
        }
        public void Print(bool direction, string word)
        {
            if (direction)
            {
                foreach (string item in dic.Keys)
                {
                    if (item == word)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Direction: RU - EN");
                        Console.WriteLine($"{item} - {dic[item]}");
                        Console.WriteLine();

                    }
                    if (!dic.ContainsKey(word))
                    {
                        throw new Exception($"The word not found!\nThere is no such word {word} in the dictionary!");
                    } 
                }
            }
            else
            {
                foreach (string item in dic.Keys)
                {
                    if (dic[item] == word)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Direction: EN - RU");
                        Console.WriteLine($"{dic[item]} - {item}");
                        Console.WriteLine();
                    }
                    if (!dic.ContainsValue(word))
                    {
                        throw new Exception($"The word not found!\nThere is no such word {word} in the dictionary!");
                    }
                }
            }
        }
    }
    class Point2D<T> where T: struct
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point2D()
        {

        }
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X:{X}\nY:{Y}";
        }
    }

    class Point3D : Point2D<int>
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z):base(x,y)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"X:{X}\nY:{Y}\nZ:{Z}";
        }
    }

    class Straight
    {
        public Point2D<int> Point1 { get; set; }
        public Point2D<int> Point2 { get; set; }
        public Straight(Point2D<int> p1, Point2D<int> p2)
        {
            Point1 = new Point2D<int>();
            Point2 = new Point2D<int>();

            Point1 = p1;
            Point1 = p2;
        }

        public Straight(int x1, int y1, int x2, int y2)
        {
            Point1 = new Point2D<int>();
            Point2 = new Point2D<int>();

            Point1.X = x1;
            Point1.Y = y1;

            Point2.X = x2;
            Point2.Y = y2;
        }

        public override string ToString()
        {
            return $"\nPoint1:\n{Point1}\n=========\nPoint2:\n{Point2}\n";
        }
    }
    class Program
    {
        private static string ReadTxt()
        {
            using (FileStream stream = new FileStream("text.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(stream, Encoding.Unicode))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static void Main(string[] args)
        {
            /*
             1.Создать примитивный англо-русский и русско-английский словарь, 
             содержащий пары слов – названий стран на русском и английском языках. 
             Пользователь должен иметь возможность выбирать направление перевода и запрашивать перевод.
             
             2.Создать необобщенный класс точки в трехмерном пространстве с целочисленными координатами (Point3D), 
             который наследуется от generic-класса Point2D<T>, рассмотренного в уроке. Реализовать в классе:
               
               a.	конструктор с параметрами, который принимает начальные значения для координат точки
               b.	метод ToString()
               
             3.Создать обобщенный класс прямой на плоскости. 
             В классе предусмотреть 2 поля типа обобщенной точки – точки, через которые проходит прямая. 
             Реализовать в классе:
             
               a.	конструктор, который принимает 2 точки
               b.	конструктор, которые принимает 4 координаты (x и у координаты для первой и второй точки)
               c.	метод ToString()
               
             4.Подсчитать, сколько раз каждое слово встречается в заданном тексте. 
             Результат записать в коллекцию Dictionary<TKey, TValue>
            */

            string menu;

            do
            {
                Console.WriteLine("Input task number (1 - 4):  ");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        
                        try
                        {
                            Console.WriteLine("Input translate direction: true(RU - EN) or false(EN - RU) ");
                            string tmp = Console.ReadLine();
                            if (tmp != "true" && tmp != "false")
                            {
                                throw new InvalidOperationException("Invalid operation! Input: true(RU - EN) or false(EN - RU)");
                            }
                            MyDictionary myDic = new MyDictionary();

                            Console.WriteLine("This available words: \n");
                            myDic.Print();

                            Console.WriteLine();

                            Console.WriteLine("Input a word for translate: ");
                            myDic.Print(bool.Parse(tmp),Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":

                        do
                        {
                            Random r = new Random();
                            Point3D point = new Point3D(r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10));

                            Console.WriteLine($"{point}");

                            Console.WriteLine("\nGo To continue generating points, press the Enter key, in the Go menu, input something");
                        } while (Console.ReadLine() == "");
                        break;

                    case "3":

                        do
                        {
                            Random r = new Random();
                            Straight straight = new Straight(r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10));

                            Console.WriteLine($"{straight}");

                            Console.WriteLine("\nGo To continue generating points, press the Enter key, in the Go menu, input something");
                        } while (Console.ReadLine() == "");
                        break;

                    case "4":

                        string text = ReadTxt();
                        int words_amount = 0;
                        Dictionary <string,int> textInfo = new Dictionary<string, int>();

                        Console.WriteLine(text);

                        int i = text.Length / 2 - 1;
                        for (; i > 0; i--)
                        {
                            string word = text.Substring(0, text.IndexOf(' '));
                            string text2 = ReadTxt();
                            int j = text2.Length /2 - 1;
                            for (; j > 0; j--)
                            {
                                string word2 = text2.Substring(0, text2.IndexOf(' '));

                                if (word == word2)
                                {
                                    words_amount++;
                                }
                                text2 = text2.Remove(0, text2.IndexOf(' ') + 1);

                                if (word2 == "данных.")
                                {
                                    break;
                                }
                            }
                            if (textInfo.ContainsKey(word) != true)
                            {
                                textInfo.Add(word, words_amount);
                            }
                            else
                            {
                                textInfo.Remove(word);
                                textInfo.Add(word, words_amount);
                            }
                            words_amount = 0;
                            text = text.Remove(0, text.IndexOf(' ') + 1);

                            if (word == "данных.")
                            {
                                break;
                            }
                        }

                        foreach (string key in textInfo.Keys)
                        {
                            Console.WriteLine($"{key} = {textInfo[key]}");
                        }

                        break;
                    default:
                        Console.WriteLine("Task is not exist! Input number (1 - 4)");
                        break;
                }
            } while (menu != "0");

            Console.ReadKey();
        }
    }
}
