namespace EmployeeLinkedList_Ellis
{
    internal static class Company
    {
        private static Node _head;

        public static Node Add(Employees data)
        {            
            Node current = _head;

            if (_head == null)
            {
                _head = new Node(data);
                return _head;
            }

            while (current != null)
            {
                if (_head.e.LastName.CompareTo(data.LastName) > 0)
                {
                    _head = new Node(data);
                    _head.Next = current;
                    return _head;
                }

                if (current.e.LastName.CompareTo(data.LastName) < 0)
                {
                    if (current.Next == null)
                    {
                        current.Next = new Node(data);
                        return _head;
                    }

                    if (current.Next.e.LastName.CompareTo(data.LastName) > 0 && current.Next.Next != null)
                    {
                        Node temp = current.Next;
                        current.Next = new Node(data);
                        current.Next.Next = temp;
                    }
                }

                if (current.e.LastName.CompareTo(data.LastName) > 0)
                {
                    Node temp = current;
                    current = new(data);
                    current.Next = temp;
                    return _head;
                }

                current = current.Next;
            }

            return _head;
        }

        public static void Print()
        {
            if (_head != null)
            {
                Node current = _head;
            
                while (current != null)
                {
                    Console.WriteLine(current.e.LastName + ", " + current.e.FirstName + " | " + current.e.Gender + " | " + current.e.Salary.ToString("C") + " | " + current.e.Department);
                    current = current.Next;
                }

                Console.WriteLine();  
            }
            else
            {
                Console.WriteLine("Empty List!");
                Console.WriteLine();
            }
        }
        public static Node Find(Employees data) // Search by LastName
        {
            Node current = _head;
            
            while (current != null && !current.e.LastName.Equals(data))
            {
                current = current.Next;
            }
            return current;
        }

        public static Node FindLastName(string data) // Search by LastName
        {
            Node current = _head;
            while (current != null && !current.e.LastName.Equals(data))
            {
                current = current.Next;
            }
            if (_head != null)
            {
                Console.WriteLine();
                Console.WriteLine(current.e.LastName + ", " + current.e.FirstName + " | " + current.e.Gender + " | " + current.e.Salary.ToString("C") + " | " + current.e.Department);
                Console.WriteLine();
            }
            else // This does not work
            {
                Console.WriteLine("Employee not found!");
                Console.WriteLine();
            }
            return current;
        }

        public static Node FindFirstName(string data) // Search by FirstName
        {
            Node current = _head;
            while (current != null && !current.e.FirstName.Equals(data))
            {
                current = current.Next;
            }
            if (_head != null)
            {
                Console.WriteLine();
                Console.WriteLine(current.e.LastName + ", " + current.e.FirstName + " | " + current.e.Gender + " | " + current.e.Salary.ToString("C") + " | " + current.e.Department);
                Console.WriteLine();
            }
            else // This does not work
            {
                Console.WriteLine("Employee not found!");
                Console.WriteLine();
            }
            return current;
        }

        public static Node FindDepartment(string data) // Search by department
        {
            Node current = _head;
            while (current != null && !current.e.Department.Equals(data))
            {
                current = current.Next;
            }
            if (_head != null)
            {
                Console.WriteLine();
                Console.WriteLine(current.e.LastName + ", " + current.e.FirstName + " | " + current.e.Gender + " | " + current.e.Salary.ToString("C") + " | " + current.e.Department);
                Console.WriteLine();
            }
            else // This does not work
            {
                Console.WriteLine("Employee not found!");
                Console.WriteLine();
            }
            return current;
        }

        public static void Remove(Employees data)
        {
            if (_head == null)
            {
                return;
            }

            Node found = Find(data);
            found.Previous.Next = found.Next;
        }

        public static void Edit(Employees data)
        {
            if (_head == null)
            {
                return;
            }
        }

        public static void AddEmployee(Employees data)
        {

        }

        public static decimal AvgSalary()
        {
            if (_head == null)
            {
                return -1;
            }

            int count = 0;
            decimal sum = 0;
            decimal avg;

            Node current = _head;
            while (current != null)
            {
                count++;
                sum += current.e.Salary;
                current = current.Next;
            }

            avg = sum / count;

            return avg;
        }
    }
}
