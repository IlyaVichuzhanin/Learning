using HarfBuzzSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace yield;


public static class MovingMaxTask
{
    public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
    {
        if (windowWidth <= 0)
            throw new System.ArgumentOutOfRangeException();
        int i = 1;
        LinkedList<double> maxPotentials = new LinkedList<double>();
        Queue<double> windowNumbers = new Queue<double>();
        foreach (DataPoint dataPoint in data)
        {
            if (i <= windowWidth)
                i++;
            else if (maxPotentials.First.Value == windowNumbers.Dequeue())
                maxPotentials.RemoveFirst();

            windowNumbers.Enqueue(dataPoint.OriginalY);

            while (maxPotentials.Count > 0 && maxPotentials.Last.Value <= dataPoint.OriginalY)
                maxPotentials.RemoveLast();

            maxPotentials.AddLast(dataPoint.OriginalY);

            var newDataPoint = dataPoint.WithMaxY(maxPotentials.First.Value);

            yield return newDataPoint;
        }
    }
}

//public static class MovingMaxTask
//{
//    public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
//    {

//        var windowQueue = new Queue<double>();
//        var maxQueue = new LinkedList<double>();

//        foreach (DataPoint point in data)
//        {


//            if (windowQueue.Count >= windowWidth)
//                windowQueue.Dequeue();


//            if (maxQueue.Count > 0 && maxQueue.First.Value == windowQueue.First())
//                maxQueue.RemoveFirst();

//            windowQueue.Enqueue(point.OriginalY);

//            while (maxQueue.Count > 0 && maxQueue.Last.Value <= point.OriginalY)
//            {
//                maxQueue.RemoveLast();
//            }
//            maxQueue.AddLast(point.OriginalY);



//            yield return point.WithMaxY(maxQueue.First.Value);
//        }

//        return data;
//    }
//}

//public class DoublyNode<T>
//{
//    public DoublyNode(T data)
//    {
//        Data = data;
//    }
//    public T Data { get; set; }
//    public DoublyNode<T> Previous { get; set; }
//    public DoublyNode<T> Next { get; set; }
//}

//public class Deque<T> : IEnumerable<T>  // двусвязный список
//{
//    DoublyNode<T> head; // головной/первый элемент
//    DoublyNode<T> tail; // последний/хвостовой элемент
//    int count;  // количество элементов в списке

//    // добавление элемента
//    public void AddLast(T data)
//    {
//        DoublyNode<T> node = new DoublyNode<T>(data);

//        if (head == null)
//            head = node;
//        else
//        {
//            tail.Next = node;
//            node.Previous = tail;
//        }
//        tail = node;
//        count++;
//    }
//    public void AddFirst(T data)
//    {
//        DoublyNode<T> node = new DoublyNode<T>(data);
//        DoublyNode<T> temp = head;
//        node.Next = temp;
//        head = node;
//        if (count == 0)
//            tail = head;
//        else
//            temp.Previous = node;
//        count++;
//    }
//    public T RemoveFirst()
//    {
//        if (count == 0)
//            throw new InvalidOperationException();
//        T output = head.Data;
//        if (count == 1)
//        {
//            head = tail = null;
//        }
//        else
//        {
//            head = head.Next;
//            head.Previous = null;
//        }
//        count--;
//        return output;
//    }
//    public T RemoveLast()
//    {
//        if (count == 0)
//            throw new InvalidOperationException();
//        T output = tail.Data;
//        if (count == 1)
//        {
//            head = tail = null;
//        }
//        else
//        {
//            tail = tail.Previous;
//            tail.Next = null;
//        }
//        count--;
//        return output;
//    }
//    public T First
//    {
//        get
//        {
//            if (IsEmpty)
//                throw new InvalidOperationException();
//            return head.Data;
//        }
//    }
//    public T Last
//    {
//        get
//        {
//            if (IsEmpty)
//                throw new InvalidOperationException();
//            return tail.Data;
//        }
//    }

//    public int Count { get { return count; } }
//    public bool IsEmpty { get { return count == 0; } }

//    public void Clear()
//    {
//        head = null;
//        tail = null;
//        count = 0;
//    }

//    public bool Contains(T data)
//    {
//        DoublyNode<T> current = head;
//        while (current != null)
//        {
//            if (current.Data.Equals(data))
//                return true;
//            current = current.Next;
//        }
//        return false;
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return ((IEnumerable)this).GetEnumerator();
//    }

//    IEnumerator<T> IEnumerable<T>.GetEnumerator()
//    {
//        DoublyNode<T> current = head;
//        while (current != null)
//        {
//            yield return current.Data;
//            current = current.Next;
//        }
//    }
//}