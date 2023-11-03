using CsvHelper.Configuration.Attributes;

namespace EmployeeLinkedList_Ellis
{
    internal class Node
    {
        public Employees e;
        public Node Next;
        public Node Previous;
                
        public Node (Employees data)
        {
            e = data;
            Next = null;
            Previous = null;
        }
    }
}
