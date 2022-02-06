using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework;

public class Node<TValue>
{
    private TValue? Value;
    public Node<TValue> Next
    {
        get;
        private set;
    }

    public Node(TValue value)
    {
        Next = this;
        Value = value;
    }

    public override string? ToString()
    {
        if (Value is null)
        {
            return null;
        }
        else
        {
            return Value.ToString();
        }
    }

}
