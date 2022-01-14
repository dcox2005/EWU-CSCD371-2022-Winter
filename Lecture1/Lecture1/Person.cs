namespace Lecture1
{
    public class Person
    {
        //this is a tuple with string and string as their elements
        //you can use as many elements as you want, 3,4, 100
        //this [] is a tuple array
        (string UserName, string Password)[] Credentials = new[] { 
            ("Inigo Montoya", "YouKilledMyF@ther!"),
            ("null", "null"),
        }; 

        public bool Login(string userName, string password)
        {
            return (userName, password) == Credentials[0];
        }
    }
}


