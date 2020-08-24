using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSampleConsoleApp
{
    public class LNode
    {
        public int data;
        public LNode next;
        public LNode(int d)
        {
            data = d;
            next = null;
        }

    }
    public class LinkList
    {
        public  LNode removeDuplicates(LNode head)
        {
            //Write your code here
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            List<int> NodeValues = new List<int>();
            LNode Cur = head;
            LNode prev = null;

            while (Cur != null)
            {
                if (!NodeValues.Contains(Cur.data))
                {
                    NodeValues.Add(Cur.data);
                }
                else
                {
                    prev.next = Cur.next;
                    Cur = null;
                    Cur = prev;
                }
                prev = Cur;
                Cur = Cur.next;
            }
            return head;

        }

        public  LNode insert(LNode head, int data)
        {
            LNode p = new LNode(data);


            if (head == null)
                head = p;
            else if (head.next == null)
                head.next = p;
            else
            {
                LNode start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }
        public void display(LNode head)
        {
            LNode start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
    }
}
