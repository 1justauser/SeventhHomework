using System.Text;

namespace Tumakov
{
    class SeventhHomework
    {
        static void Unicode_Utf8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        static void FirstExersice()
        {
            //Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1 - 7.3 добавить
            //метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
            //на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
            Console.WriteLine("Упражнение 8.1");
            BankAccount.SolveTask();
            return;
        }
        static void SecondExersice()
        {
            //Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает
            //строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            //Протестировать метод.
            Console.WriteLine("Упражнение 8.2");
            Console.WriteLine("Укажите строчку");
            Console.WriteLine($"Её версия в обратном порядке {StringReverse(Console.ReadLine()!)}");
        }
        static void ThirdExersice()
        {
            //Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла.Если
            //такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            //работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            //буквами.
            Console.WriteLine("Введите название файла");
            string fileName = Console.ReadLine()!;
            if (File.Exists(fileName))
            {
                List<string> inputLines = new List<string>();
                IEnumerable<string> fileContents = File.ReadLines(fileName);
                foreach (string line in fileContents)
                {
                    inputLines.Add(StringUp(line));
                }
                using (StreamWriter outputFile = new StreamWriter("output.txt"))
                {
                    foreach (string line in inputLines)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Этого файла не существует");
            }
        }
        static void FourthExersice()
        {
            //Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
            //метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
            //IFormattable обеспечивает функциональные возможности форматирования значения объекта
            //в строковое представление.)
            int intVariable = 1234;
            ResultIFormattableOutput(intVariable, nameof(intVariable));
            DateTime dateTime = DateTime.Now;
            ResultIFormattableOutput(dateTime, nameof(dateTime));
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            ResultIFormattableOutput(dictionary, nameof(dictionary));
        }
        static void FirstHomework()
        {
            //Домашнее задание 8.1 Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail
            //адрес.Разделителем между ФИО и адресом электронной почты является символ #:
            //Иванов Иван Иванович # iviviv@mail.ru
            //Петров Петр Петрович # petr@mail.ru
            //Сформировать новый файл, содержащий список адресов электронной почты.
            //Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            //качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            //public void SearchMail(ref string s).
            Console.WriteLine("Введите название файла");
            string fileName = Console.ReadLine()!;
            if (File.Exists(fileName)) 
            {
                List<string> inputLines = new List<string>();
                IEnumerable<string> fileContents = File.ReadLines(fileName);
                foreach (string line in fileContents)
                {
                    string inputLine = line;
                    SearchMail(ref inputLine);
                    inputLines.Add(inputLine);
                }
                using (StreamWriter outputFile = new StreamWriter("output.txt"))
                {
                    foreach (string line in inputLines)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Этого файла не существует");
            }
        }
        static void SecondHomework()
        {
            //Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. В
            //цикле вывести информацию о каждой песне.Сравнить между собой первую и вторую
            //песню в списке.Песня представляет собой класс с методами для заполнения каждого из
            //полей, методом вывода данных о песне на печать, методом, который сравнивает между
            //собой два объекта:
            //class Song
            //{
            //string name; //название песни
            //string author; //автор песни
            //Song prev; //связь с предыдущей песней в списке
            //           //метод для заполнения поля name

            ////метод для заполнения поля author
            ////метод для заполнения поля prev
            ////метод для печати названия песни и ее исполнителя
            //public string Title() { ... /*возвращ название+исполнитель*/ ...}
            ////метод, который сравнивает между собой два объекта-песни:
            //public bool override Equals(object d) { ...}
            //}

        }
        static void SearchMail(ref string s)
        {
            s = s.Split(" # ")[1];
        }
        static bool IsIFormattable(object objectVariable)
        {
            if (objectVariable is IFormattable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void ResultIFormattableOutput(object objectVariable, string Name)
        {
            if (IsIFormattable(objectVariable))
            {
                Console.WriteLine($"переменная {Name} с типом {objectVariable.GetType().Name} работает с System.IFormattable");
            }
            else
            {
                Console.WriteLine($"переменная {Name} с типом {objectVariable.GetType().Name} не работает с System.IFormattable");
            }
        }
        static string StringReverse(string stringVariable)
        {
            string reversedStringVariable = "";
            for (int i = 0; i < stringVariable.Length; i++)
            {
                reversedStringVariable = stringVariable[i] + reversedStringVariable;
            }
            return reversedStringVariable;
        }
        static string StringUp(string stringVariable)
        {
            string newString = "";
            for(int i = 0; i < stringVariable.Length; i++)
            {
                if (char.IsLetter(stringVariable[i]))
                {
                    newString += char.ToUpper(stringVariable[i]);
                }
                else
                {
                    newString += stringVariable[i];
                }
            }
            return newString;
        }
        static void Main()
        {
            Unicode_Utf8();
            //FirstExersice();
            //SecondExersice();
            //ThirdExersice();
            //FourthExersice();
            FirstHomework();
        }
    }
}