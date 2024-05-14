using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractick;

public class ListNode<T>
{
    public ListNode(T data) 
    {
        Data = data;
        
    }
    public T Data { get; set; }
    public ListNode<T> Next { get; set; }
    public ListNode<T> Previous { get; set; }

}
