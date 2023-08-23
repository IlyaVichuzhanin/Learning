using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clones;

public class CloneVersionSystem : ICloneVersionSystem
{
    
    public Dictionary<int,Clone> Clones = new Dictionary<int, Clone>();
	public string Execute(string query)
	{
        var qeeryCommand = query.Split(' ');
        var learningCommand = qeeryCommand[0];
        var cloneId = Int32.Parse(qeeryCommand[1]);
        if (!Clones.ContainsKey(cloneId))
        {
            Clones.Add(cloneId, new Clone(cloneId));
        }
        switch (learningCommand)
        {
            case "learn":
                Clones[cloneId].Learn(qeeryCommand[2]);
                return null;
            case "clone":
                var newClone = Clones[cloneId].CloneClone(Clones.Count+1);
                Clones.Add(newClone.CloneId, newClone);
                return null;
            case "rollback":
                Clones[cloneId].Rollback();
                return null;
            case "relearn":
                Clones[cloneId].ReLearn();
                return null;
            case "check":
                return Clones[cloneId].Check();
            default: return null;
        }
	}
}

public class Clone
{
    public Clone(int id)
    {
        CloneId = id;
        programStack = new NodeStack<string>();
        rollBackHistory = new NodeStack<string>();
    }
    public int CloneId { get; set; }
    public NodeStack<string> programStack { get; set; }
    public NodeStack<string> rollBackHistory { get; set; }

    
    public void Learn(string programm)
    {
        if(programStack.Count==0 || programStack.Peek()!=programm)
            programStack.Push(programm);
        rollBackHistory=new NodeStack<string>();
    }
    public void Rollback()
    {
        var deletedProgramm = programStack.Pop();
        rollBackHistory.Push(deletedProgramm);
    }
    public void ReLearn()
    {
        if (rollBackHistory.Count > 0)
        {
            var relearnedProgramm = rollBackHistory.Pop();
            programStack.Push(relearnedProgramm);
        }
    }
    public Clone CloneClone(int clodeID)
    {
        var newClone = new Clone(clodeID);
        newClone.programStack = new NodeStack<string> { head=this.programStack.head, count= this.programStack.count };
        newClone.rollBackHistory = new NodeStack<string> { head = this.rollBackHistory.head, count = this.rollBackHistory.count };
        return newClone;
    }
    public string Check()
    {
        if (programStack.Count > 0)
            return programStack.Peek();
        else
            return "basic";
    }
}


public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

public class NodeStack<T> 
{
    public Node<T> head;
    public int count;

    public bool IsEmpty
    {
        get { return count == 0; }
    }
    public int Count
    {
        get { return count; }
    }

    public void Push(T item)
    {
        // увеличиваем стек
        Node<T> node = new Node<T>(item);
        node.Next = head; // переустанавливаем верхушку стека на новый элемент
        head = node;
        count++;
    }
    public T Pop()
    {
        // если стек пуст, выбрасываем исключение
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст");
        Node<T> temp = head;
        head = head.Next; // переустанавливаем верхушку стека на следующий элемент
        count--;
        return temp.Data;
    }
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст");
        return head.Data;
    }
}


//public class Stack<T>
//{
//    public Stack()
//    {
//        stack = new LinkedList<T>();
//    }
//    public LinkedList<T> stack { get; set; }   /// where T : IList
//    public void Push(T item)
//    {
//        stack.AddLast(item);
//    }
//    public T Pop()
//    {
//        var value = stack.Last();
//        if(stack.Count >0)
//            stack.RemoveLast();
//        return value;
//    }
//    public int Count
//    {
//        get
//        {
//            return stack.Count;
//        }
//    }
//}