using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Linked_List
{
    class node
    {
        /*node class represents the node of doubly linked list.
         * it consists of the information part and linked to.
         * its succeeding and preceeding.
         * it terms of next and proveious*/
        public int noMhs;
        public string name;
        //point to the succeding node
        public node next;
        //point to the precceeding node
        public node prev;

    }

    class doublelinkedlist
    {
        node START;

        //Construktor
        public doublelinkedlist()
        {
            START = null;
        }

        public void addnode()
        {
            int nim;
            string nm;
            Console.WriteLine("\n Enter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Enter the name of the student : ");
            nm = Console.ReadLine();
            node NewNode = new node();
            NewNode.noMhs = nim;
            NewNode.name = nm;

            //cheack if the list empty
            if ((START != null) && (nim == START.noMhs))
            {
                Console.WriteLine("\nDuplicate number not allowed");
                return;
            }
            /*if the node is to inserted at between two node
             */
            node previous, current;
            for (current = previous = START;
                current != null && nim == current.noMhs;
                previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }

            }
            /*
             * on the exucition of the above for loop,prev and
             * current will point to those nodes
             * between wich the node is to be inserted
             */

            NewNode.next = current;
            NewNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                NewNode.next = null;
                NewNode.next = NewNode;
                return;
            }
            current.prev = NewNode;
            previous.next = NewNode;
        }
        public bool Search(int rollno, ref node previous, ref node current)
        {
            for (previous = current = START; current != null && rollno != current.noMhs; previous = current, current = current.next) { }
            return (current != null);
        }

        public bool dellnode(int rollno)
        {
            node previous, current;
            previous = current = null;
            if (Search(rollno, ref previous, ref current) == false)
                return false;
            //the beginning of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            /* The is deleted is in between the list the following lines of is executed
             */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listempty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listempty())
                Console.WriteLine("\nList Is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are : \n");
                node currentnode;
                for (currentnode = START; currentnode != null; currentnode = currentnode.next)
                    Console.Write(currentnode.noMhs + "" + currentnode.name + "\n");
            }
        }
        public void descending()
        {
            if (listempty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nRecord in the Descending order of" + "roll number are:\n");
            node currentNode;
            for (currentNode = START; currentNode != null; currentNode = currentNode.next)
            { }
            while (currentNode != null)
            {
                Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
                currentNode = currentNode.prev;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            doublelinkedlist obj = new doublelinkedlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. Viiew all records in the ascending order of roll numbers");
                    Console.WriteLine("4. View all records in the descending order of roll  numbers");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listempty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellnode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted \n");

                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listempty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.noMhs);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                                break;
                            }
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}