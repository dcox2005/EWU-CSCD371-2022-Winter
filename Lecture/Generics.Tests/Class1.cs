using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generics.Tests;
public class Container<T>
   where T : notnull
{
    public T Value
    {
        get
        {
            return Value;
        }
        set
        {
            // Check for null
            if (Value.Equals(value))
            {
                Value = value;
            }
        }

    }
    private Container<T>? Root { get; set; }

    Container(T value)
    {
        Value = value;
    }
    public class NodeCollectionFactory<TValue> where TValue : notnull
    {
        public Container<TValue> CreateNewNodeCollection(TValue item)
        {
            return new Container<TValue>(item);
        }
    }
}

[TestClass]
public class MoreGenericStuff
{

    [TestMethod]
    public void MyTestMethod()
    {
        Container<int>? container = null;
        if(container is null)
        {

        }
    }
}
