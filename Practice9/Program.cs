using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    class Point
    {
        public int data;
        public Point next, pred;
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
    class Program
    {
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }
        static Point MakeList(int size, Point l, int c)
        {
            int count = c;
            Point beg = MakePoint(size-count);
            if (count < size)
            { 
                l.next = beg;
                beg.pred = l;
                l = beg;
                count++;
                MakeList(size, l, count);
            }
            return beg;
        }
        static void PrintList( Point beg)
        {
            Point p = beg;
            while (p != null)
            {
                Console.Write(p + "\t");
                p = p.next;
            }
            Console.WriteLine();
        }
        static int EnterSize()
        {
            bool ok;
            int s = 0;
            do
            {
                Console.WriteLine("Enter size of this list.");
                ok = Int32.TryParse(Console.ReadLine(), out s);
                if (!ok)
                    Console.WriteLine("Invalid data type.");
                else if (s <= 0)
                {
                    Console.WriteLine("Inappropriate array size.");
                }
            } while (!ok || s <= 0);
            return s;
        }
        static Point DeleteEl(Point e,Point beg,int sure,Point first)
        {
            if (first == null)
            {
                Console.WriteLine("This list is empty.");
                return first;
            }
            else if (beg.next == null && beg.data != e.data && sure == 0)
            {
                Console.WriteLine("There is no such element.");
                    return first;
            }
             if(first.data == e.data)
            {
                sure++;
                beg = beg.next;
                first = beg;
            }
            else if (beg.data != e.data)
            {
                beg = beg.next;
                DeleteEl(e, beg,sure,first);
            }
            else if(beg.data==e.data)
            {
                sure++;
                    beg.pred.next = beg.next;
            }
             else if(beg.data == e.data && beg.next == null)
            {
                beg = null;
            }
            return first;
        }
        static void Search(Point beg,int e,int count)
        {
            if (beg.data != e)
            {
                beg = beg.next;
                count++;
                Search(beg, e,count);
            }
            else if (beg.data == e)
            {
                Console.WriteLine("This element has an index of {0}", count);
            }
        }
        static int ChooseAction()
        {
            bool ok;
            int c;
            do
            {
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1. Delete an element form the list.");
                Console.WriteLine("2. Search for an element in the list.");
                ok = Int32.TryParse(Console.ReadLine(), out c);
                if (!ok)
                    Console.WriteLine("Invalid data type.");
                else if (c != 1 && c != 2)
                {
                    Console.WriteLine("There is no such option.");
                }
            } while (!ok || (c != 1 && c != 2));
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome.");
            int end = 0;
            int size = EnterSize();
            Point begining = new Point(1);
            Point thislist = MakeList(size, begining, 0);
            PrintList(thislist);
            do
            {
                int num = ChooseAction();
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Which element to delete?");
                        Point that = new Point(Int32.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        thislist = DeleteEl(that, thislist,0,thislist);
                        PrintList(thislist);
                        break;
                    case 2:
                        Console.WriteLine("The index of which element you want to see?");
                        int index = Int32.Parse(Console.ReadLine());
                        Search(thislist, index, 0);
                        break;
                }
                Console.WriteLine("If you wish to end current session enter the word (exit).");
                string answer = Console.ReadLine();
                if (answer == "exit"||answer=="учше")
                    end++;
            } while (end == 0);
        }
    }
}
