using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeLinkedList_Ellis;

// View Employee List
// Find: Return all data for given employee based on search criteria (Lastname, Firstname, or Department)
// Add employee
// Display average employee salary
// Edit Employee (All fields are editable)
// Delete Employee (Deletes Duplicates)

namespace EmployeeLinkedList_Ellis
{
    internal class Menu
    {                
        public static void MainMenu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.Write("[");
                Console.Write("1");
                Console.WriteLine("] View Employee List");
                Console.Write("[");
                Console.Write("2");
                Console.WriteLine("] Find Employee");
                Console.Write("[");
                Console.Write("3");
                Console.WriteLine("] Add Employee");
                Console.Write("[");
                Console.Write("4");
                Console.WriteLine("] Display Average Employee Salary");
                Console.Write("[");
                Console.Write("5");
                Console.WriteLine("] Edit Employee");
                Console.Write("[");
                Console.Write("6");
                Console.WriteLine("] Delete Employee");
                Console.Write("[");
                Console.Write("7");
                Console.WriteLine("] Exit Program");

                string option = Console.ReadLine();
                Console.Clear();

                if (option == "1") // View Employee List
                {
                    Company.Print();
                    PressKey();                    
                }
                else if (option == "2") // Find Employee: lastname, firstname, or department.
                {
                    Console.WriteLine("Which criteria would you like to search by?");
                    Console.Write("[");
                    Console.Write("1");
                    Console.WriteLine("] First Name");
                    Console.Write("[");
                    Console.Write("2");
                    Console.WriteLine("] Last Name");
                    Console.Write("[");
                    Console.Write("3");
                    Console.WriteLine("] Department");
                    option = Console.ReadLine();
                    if (option == "1")
                    {
                        Console.Write("First Name: ");
                        string input = Console.ReadLine().ToString();
                        Company.FindFirstName(input);
                        PressKey();
                    }
                    else if (option == "2")
                    {
                        Console.Write("Last Name: ");
                        string input = Console.ReadLine().ToString();
                        Company.FindLastName(input);
                        PressKey();
                    }
                    else if (option == "3")
                    {
                        Console.WriteLine("Department: ");
                        string input = Console.ReadLine().ToString();
                        Company.FindDepartment(input);
                        PressKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input...");
                        PressKey();
                    }
                }
                else if (option == "3") // Add Employee
                {
                    Console.WriteLine("Please complete the following fields:");
                    Console.Write("Last Name: " );
                    string lastName = Console.ReadLine().ToString();
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine().ToString();
                    Console.Write("Gender (M/F): ");
                    string gender = Console.ReadLine().ToString();
                    Console.Write("Salary (####.##): ");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Department (CEO; DEVELOPMENT; DISTRIBUTION; FINANCE; HR; IT; LEGAL; MGMT; SALES; SECURITY; UNASSIGNED): ");
                    string department = Console.ReadLine().ToString();
                    Company.Add(lastName, firstName, gender, salary, department);
                    Console.WriteLine();
                    Console.WriteLine("Employee added");
                    PressKey();
                }
                else if (option == "4") // Display Average Employee Salary
                {
                    Console.WriteLine("Average salary for all employees is: " + Company.AvgSalary().ToString("C"));
                    PressKey();
                }
                else if (option == "5") // Edit Employee
                {
                    Console.Write("Enter the last name of the employee you'd like to edit: ");
                    string input = Console.ReadLine().ToString();
                    Company.FindLastName(input);
                    PressKey();
                }
                else if (option == "6") // Delete Employee
                {
                    Console.Write("Enter the last name of the employee you'd like to delete: ");
                    string input = Console.ReadLine();
                    Company.FindLastName(input);
                    PressKey();
                }
                else if (option == "7") // Exit
                {
                    Console.WriteLine("Exiting...");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid input...");
                    PressKey();
                }
            }
        }

        public static void PressKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
