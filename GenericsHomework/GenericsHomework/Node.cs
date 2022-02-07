
using System;

namespace GenericsHomework;

public class Node<TValue>
{
    private TValue? _Value;
    public Node<TValue> Next
    {
        get;
        private set;
    }

    public Node(TValue value)
    {
        Next = this;
        _Value = value;
    }

    public override string? ToString()
    {
        if (_Value is null)
        {
            return null;
        }
        else
        {
            return _Value.ToString();
        }
    }

    public void Append(TValue newValue)
    {
        if (this.Exists(newValue))
        {
            throw new InvalidOperationException($"The {nameof(newValue)} already exists in the list.");
        }
        Node<TValue> newNode = new(newValue);
        newNode.Next = this.Next;
        this.Next = newNode;
    }

    public Node<TValue> Clear()
    {
        /*
         *  Simply having this node loop back on itself will not work.
         *  GC might still see that there are references to the objects from another object
         *  and it may delay collection.
         *  Set each object to reference itself and GC knows to clean that up.
         */

        Node<TValue> currentNode = this.Next;
        Node<TValue> previous;
        while (currentNode != this)
        {
            previous = currentNode;
            currentNode = currentNode.Next;
            previous.Next = previous;
        }
        this.Next = currentNode;
        return this;
    }

    public bool Exists(TValue valueToFind)
    {
        Node<TValue> currentNode = this;
        do
        {
            if (currentNode._Value is null)
            {
                if (valueToFind is null)
                {
                    return true;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            else if (currentNode._Value.Equals(valueToFind))
            {
                return true;
            }
            else
            {
                currentNode = currentNode.Next;
            }

        } while (currentNode != this);
        
        return false;
    }
}
