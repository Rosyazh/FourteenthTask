using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

/*
Practice: Develop console application to store a list of workers. Develop a custom exception class which will throw when user tries to add a worker with incorrect personal info.
*/

namespace FourteenthTask
{
    [Serializable]
    class PersonalInfoException : Exception, ISerializable
    {
        public PersonalInfoException()
        {

        }
        public PersonalInfoException(string message) : base(message)
        {

        }
        public PersonalInfoException(string message, Exception innerException) : base(message, innerException)
        {

        }
        protected PersonalInfoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }

    class Worker
    {
        private string name;
        private string surname;
        private string workPosition;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    name = value;
                else
                    throw new PersonalInfoException("Incorrect name.");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    surname = value;
                else
                    throw new PersonalInfoException("Incorrect surname.");
            }
        }

        public string WorkPosition
        {
            get
            {
                return workPosition;
            }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    workPosition = value;
                else
                    throw new PersonalInfoException("Incorrect working position.");
            }
        }

        public Worker()
        {
            Console.WriteLine("Enter a name:");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter a surname:");
            Surname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter a working position:");
            WorkPosition = Convert.ToString(Console.ReadLine());
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name.PadRight(15), Surname.PadRight(15), WorkPosition.PadRight(15));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();           
            int choice = 0;

            while (choice != 3)
            {
                Console.WriteLine("Menu: \n1. Input worker's personal info. \n2. Show worker's personal info. \n3. Exit.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) { }
                switch (choice)
                {
                    case 1:
                        try
                        {
                            workers.Add(new Worker());
                        }
                        catch (PersonalInfoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Input personal info completed.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Name".PadRight(15) + "Surname".PadRight(15) + "Working position".PadRight(15));
                        foreach (Worker worker in workers)
                            Console.WriteLine(worker.ToString());
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("The menu doesn't have this item");
                        break;
                }
            }
        }
    }
}
