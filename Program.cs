/* 1) Створіть чотири лямбда оператора для виконання арифметичних дій: (Add – додавання, Sub – віднімання, Mul – множення, Div – поділ). 
    Кожен лямбда оператор повинен приймати два аргументи та повертати результат обчислення. Лямбда оператор поділу повинен перевірити поділ на нуль. 
    Написати програму, яка виконуватиме арифметичні дії, вказані користувачем.
2) Створіть анонімний метод, який приймає як аргумент масив делегатів і повертає середнє арифметичне значення значень методів, повідомлених з делегатами в масиві. 
    Методи, повідомлені з делегатами із масиву, повертають випадкове значення типу int.
3) Створіть анонімний метод, який приймає як параметри три цілих аргументи і повертає середнє арифметичне цих аргументів. */

namespace Program
{
    class Program
    {
        delegate int IntMember();
        delegate int AverageMembers(IntMember[] valueMember);
        delegate int Average(int a, int b, int c);

        public static void Main()
        {
            var Add = (int a, int b) => a + b;
            var Sub = (int a, int b) => a - b;
            var Mul = (int a, int b) => a * b;
            var Div = (int a, int b) => a / b;

            Console.WriteLine("1)\n");
            Console.WriteLine(Add(4, 5));
            Console.WriteLine(Sub(8, 3));
            Console.WriteLine(Mul(2, 2));
            Console.WriteLine(Div(18, 3));

            IntMember member = () => Random.Shared.Next(50);

            AverageMembers averageMembers = (items) =>
            {
                var sum = 0;

                foreach (var member in items)
                {
                    sum += member();
                }

                return sum / items.Length;
            };

            Average average = (a, b, c) => (a + b + c) / 3;

            IntMember[] members = { member, member, member };

            Console.WriteLine("\n2) " + averageMembers(members));
            Console.WriteLine("\n3) " + average(10, 20, 30));
        }
    }
}