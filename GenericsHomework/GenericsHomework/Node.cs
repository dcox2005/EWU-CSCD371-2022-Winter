
using System;

namespace GenericsHomework;

public class Node<TType>
{
    private readonly TType? _Value;
    public Node<TType> Next
    {
        get;
        private set;
    }

    public Node(TType value)
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

    public void Append(TType newValue)
    {
        if (this.Exists(newValue))
        {
            throw new InvalidOperationException($"The {nameof(newValue)} already exists in the list.");
        }
        Node<TType> newNode = new(newValue);
        newNode.Next = this.Next;
        this.Next = newNode;
    }

    public Node<TType> Clear()
    {
        /*
         *  Simply having this node loop back on itself will not work.
         *  GC might still see that there are references to the objects from another object
         *  and it may delay collection.
         *  Set each object to reference itself and GC knows to clean that up.
         */

        Node<TType> currentNode = this.Next;
        Node<TType> previous;
        while (currentNode != this)
        {
            previous = currentNode;
            currentNode = currentNode.Next;
            previous.Next = previous;
        }
        this.Next = currentNode;
        return this;
    }

    public bool Exists(TType valueToFind)
    {
        Node<TType> currentNode = this;
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
