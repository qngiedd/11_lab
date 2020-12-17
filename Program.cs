using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Faculty
    {
        public string Name { get; set; }
        public string University { get; set; }
    }
    class Student
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int Group { get; set; }
        public string Speciality { get; set; }
        public int Age { get; set; }
        public void GetInfo()
        {
            Console.WriteLine($"Faculty: {Faculty} \n Name: {Name} \n Student is {Age} years old \n Scpeciality {Speciality} \n Group: {Group} \n\n");
        }
    }
    
        class Program
    {
        static void Main(string[] args)
        {
            string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novenber", "December" };
            Console.WriteLine("Наш массив месяцев:");
            foreach (string str in Months)
                Console.Write(str + "; ");
            //вывод по количеству введенных символов
            Console.Write("\nВведите количество букв в слове, которое вы хотите найти: ");
            int length = Convert.ToInt32(Console.ReadLine());
            var SelectedMonth = from m in Months
                                where m.Length == length
                                select m;
            foreach (string str in SelectedMonth)
                Console.Write(str + "; ");
            Console.WriteLine();
            //вывод летних и зимних месяцев
            var SummerWinter = from m in Months
                               where m.StartsWith("D") || m.StartsWith("J") || m.StartsWith("F") || m.StartsWith("Au")
                               select m;
            foreach (string str in SummerWinter)
                Console.WriteLine(str);
            //по алфавиту
            var OrderedByAlphabeth = from m in Months
                                     orderby m
                                     select m;
            Console.WriteLine("\nВывод месяцев в алфавитном порядке: ");
            foreach (string str in OrderedByAlphabeth)
                Console.Write(str + "; ");
            Console.WriteLine("\n");
            //содержащие букву u и с длиной имени не меньше 4
            var LetterU = from m in Months
                          where m.Length >= 4 & m.Contains("u")
                          select m;
            int Count = LetterU.Count();
            Console.WriteLine("Элементы, содержащие букву u и обладающие длиной не менее 4 букв: ");
            foreach (string str in LetterU)
                Console.Write(str + "; ");
            Console.WriteLine("\n");
            Console.WriteLine("Количество элементов, содержащих букву u и обладающих длиной не менее 4 букв: " + Count);

            List<Student> student = new List<Student>()
            {
                new Student {Name = "Vera Cherentsova", Faculty = "IR", Group = 2, Speciality = "International relations", Age = 18},
                new Student {Name = "Angelina Draguts", Faculty = "FIT", Group = 11, Speciality = "Design", Age = 21},
                new Student {Name="Valentina Ivantsova", Faculty="FIT", Group=11, Speciality="Design", Age=19},
                new Student {Name="Nadezhda (Hope) Kireenko", Faculty="FIT", Group=11, Speciality="Design", Age=19},
                new Student {Name="Lera Shpakova", Faculty="EL", Group=4, Speciality="Teacher", Age=21},
                new Student {Name="Ian Spolan", Faculty="FL", Group=5, Speciality="Teacher", Age=21},
                new Student {Name = "Vera Sobakina", Faculty = "IR", Group = 2, Speciality = "International economy", Age = 23},
            };
            List<Faculty> faculty = new List<Faculty>()
            {
                    new Faculty { Name = "FIT", University = "BSTU" },
                    new Faculty { Name = "FIR", University = "BSU" },
            };
            //список студентов заданной специальности
            var ChosenSpeciality = from st in student
                                   where st.Speciality == "Teacher"
                                   select st;
            Console.WriteLine("Студенты, обучающиеся для того, чтобы стать преподавателями: ");
            foreach (var spec in ChosenSpeciality)
                Console.WriteLine($"{spec.Name}");
            Console.WriteLine();
            //заданной группы
            Console.Write("Введите номер группы, список которой вы хотите увидеть в консольном окне: ");
            int number = Convert.ToInt32(Console.ReadLine());
            var SelectedGroup = from st in student
                                where st.Group == number
                                select st;
            foreach (var gr in SelectedGroup)
                Console.WriteLine($"{gr.Name} : {gr.Faculty}, {gr.Speciality}, {gr.Group}");
            Console.WriteLine();
            //самого молодого студента
            int min = student.Min(n => n.Age);
            Console.WriteLine($"Возраст самого молодого студента: " + min);

            //количество студентов в заданной группе, упорядоченных по фамилиям
            Console.Write("Введите номер группы, в которой вы хотите узнать количество студентов: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            var SelectedGroup1 = from element in student
                                 where element.Group == number1
                                 orderby element.Name
                                 select element;
            foreach (var item in SelectedGroup1)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(SelectedGroup1.Count());


            //первого студента с соответствующим именем
            var FirstStudentWithChosenName = from stud in student
                                             where stud.Name.Contains("Vera")
                                             select stud;
            Console.WriteLine(FirstStudentWithChosenName.First().Name);

            //запрос с оператором Join
            var Join = from st in student
                       join f in faculty on st.Faculty equals f.Name
                       select new { Name = st.Name, Faculty = st.Faculty, University = f.University };
            foreach (var item in Join)
                Console.WriteLine($"{item.Name} : {item.Faculty}, ({item.University})");

            //мой собственный запрос 
            var myOwnRequest = from st in student
                               where st.Faculty.Contains("EL") //contains - кванторы
                               orderby st.Name //упорядочивания
                               select st;
            foreach (var own in myOwnRequest)
            { 
                Console.WriteLine(own.Name);
            }
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
