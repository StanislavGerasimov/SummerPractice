using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace NewPractick;
 
public class TwoList<T> : IEnumerable<T> where  T : Student
{
   public TwoList(){}
    ListNode<T> head;
    ListNode<T> tail;
    int count;
    public void Add(T data)
    {
        ListNode<T> node = new ListNode<T>(data);

        if (head == null)
            head = node;
        else
        {
            tail.Next = node;
            node.Previous = tail;
        }
        tail = node;
        count++;
    }

    public void addbyindex(int index, T data)
    {
        ListNode<T> newnode = new ListNode<T>(data);
        if ((index < 0) || (index >= GetLength()))
        {
            throw new Exception("Inavlid index");
        }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {


                ListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                if (current != null)
                {
                    newnode.Next = current;
                    newnode.Previous = current.Previous;
                    current.Previous.Next = newnode;
                    current.Previous = newnode;
                }
                else
                {
                    AddToTail(data);
                }
            }
        
    }
    public void AddToTail(T data)
    {
        ListNode<T> newNode = new ListNode<T>(data);

        // якщо список порожній, новий вузол стає першим елементом
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        // якщо список не порожній, додаємо новий вузол в кінець списку
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
    }
    public void AddFirst(T data)
    {
        ListNode<T> node = new ListNode<T>(data);
        ListNode<T> temp = head;
        node.Next = temp;
        head = node;
        if (count == 0)
            tail = head;
        else
            temp.Previous = node;
        count++;
    }

    public void deletebyindex(int index)
    {
        if (index < 0 || index > GetLength())
        {
            throw new IndexOutOfRangeException("Виняток: індекс поза діапазоном!");
        }
        else
        {
            if (index == 0)
            {

                ListNode<T> nodetoremove = head;
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                    nodetoremove.Next = null;
                }
            }
            // якщо вузол для видалення це останній елемент списку
            else if (index == GetLength() - 1)
            {
                ListNode<T> NodeToRemove = tail;
                tail = tail.Previous;
                if (tail != null)
                    tail.Next = null;

                NodeToRemove.Previous = null;
            }
            // якщо вузол для видалення знаходиться в середині списку
            else
            {
                ListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                ListNode<T> nodeToRemove = current;
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                nodeToRemove.Next = null;
                nodeToRemove.Previous = null;
            }
        }
    }
   
    public ListNode<T> this[int index] 
    {
        get
        {
            if (index < 0 || index > GetLength()) { throw new IndexOutOfRangeException("invalid index"); }
            ListNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                if (current.Next == null) { throw new ArgumentNullException("Вийняток: немає посилання на наступний елемент!"); }
                current = current.Next;
            }
            return current;
            
        }
        set
        {
            if (index < 0 || index >= GetLength())
                throw new ArgumentOutOfRangeException("Вийняток: індекс поза діапазону");

            ListNode<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
        }
    }
    public int Length { get { return GetLength(); } }
    private int GetLength()
    {
        int length = 0;
        ListNode<T> current = head;
        while (current != null)
        {
            length++;
            current = current.Next;
        }
        return length;
    }
    public void IterateForward()
    {
        ListNode<T> currentNode = head;

        while (currentNode != null)
        {
            Console.Write(currentNode.Data + " ");
            currentNode = currentNode.Next;
        }

        Console.WriteLine();
    }
    public void SplitList(int n)
    {

        ListNode<T> currentNode = head;
        while (currentNode != null && n>1) {
            currentNode = currentNode.Next;
            n--;
        }
        if (currentNode != null) { ListNode<T> secondlistHead = currentNode.Next;
            currentNode.Next = null;
            TwoList<T> secondlist = new TwoList<T>();
            secondlist.head = secondlistHead;
            secondlist.tail = tail;
            tail = currentNode;
            
        }
    }

    public IEnumerable<T> GetReversedEnumerator()
    {
        ListNode<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> current = tail;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
    public TwoList<T> summerborn()
    {
         TwoList<T> result = new TwoList<T>();
        var temp = head; 
        for (int i = 0; i<GetLength(); i++)
        {
            if ((temp.Data.BMonth == 6) || (temp.Data.BMonth == 7) || (temp.Data.BMonth == 8))
            {                 
                if (result.head == null)
                {
                   result.AddFirst(temp.Data);
                }
                else
                {
                    result.Add(temp.Data);
                }
                if (temp.Data == null)
                {
                    try
                    {
                        throw new Exception("Такого елементу немає");
                    }
                    catch { Console.WriteLine("Такого елементу немає"); }
                }
            }
            temp = temp.Next;
        }
        
       for (int i = 0; i < result.Length; i++)
        {
            ListNode<T> node = result[i];
            Console.WriteLine($"{node.Data.Name}, {node.Data.BDay}, {node.Data.BMonth}");
        }
        return result; 
        
    }
}


