using CsvHelper;
using System.Globalization;
using EmployeeLinkedList_Ellis;
using System.Security.Cryptography.X509Certificates;


namespace EmployeeLinkedList_Ellis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employees> employees = new List<Employees>();

            string inputFile = @"C:\Users\Trevor\source\repos\IT-415\EmployeeLinkedList_Ellis\EmployeeLinkedList_Ellis\employees-1.csv"; // Change this depending on user's file locaiton

            using (var reader = new StreamReader(inputFile))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        string fn;
                        string ln;
                        string name = csv.GetField<string>(0);
                        SplitString(name, out fn, out ln);

                        decimal num = 0;
                        string salary = csv.GetField<string>(2);
                        if (salary != "Salary")
                        {
                            num = StupidDollarSign(salary);
                        }                        

                        if (!string.IsNullOrEmpty(fn) && !string.IsNullOrEmpty(ln))
                        {
                            Company.Add(new Employees(
                                lastname: ln,
                                firstname: fn,
                                gender: csv.GetField(1),
                                salary: num,
                                department: csv.GetField(3)
                                ));
                        }
                    }
                }
            }

            Menu.MainMenu();
        }

        public static void SplitString(string input, out string firstName, out string lastName)
        {
            int pos = FindWordStart(input, input.Length - 1);

            firstName = input.Substring(0, pos).Trim();
            lastName = input.Substring(pos).Trim();
        }

        public static int FindWordStart(string s, int startIndex)
        {
            while (startIndex > 0 && Char.IsWhiteSpace(s[startIndex]))
                startIndex--;
            while (startIndex > 0 && !Char.IsWhiteSpace(s[startIndex]))
                startIndex--;
            return startIndex;
        }

        public static decimal StupidDollarSign(string salaryString)
        {
            char[] chars = {'$',',','"',' '};
            string salary = salaryString.Trim(chars);
            return decimal.Parse(salary);
        }
    }
}