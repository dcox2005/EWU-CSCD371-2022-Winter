
class Program
{
    public static void main(string[] args)
    {   
        try
        {
            Console.WriteLine("Hello, World!");
            GetNumberFromConsole();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    private static void GetNumberFromConsole()
    {
        int? number = null;
        while (number is null)
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();
            if (input is not null)
            {
                if (input.ToLower() == "stop")
                {
                    throw new InvalidOperationException("User is quiting");
                }
                try
                {
                    number = EnterNumber(number, input);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Quit");
                    return;
                    // comment Why?
                }
                catch (ArgumentException) 
                {
                    Console.WriteLine($"Hey..... {input} is not a number (stupid!)");
                }
                catch(Exception exception)
                {
                    //Never have an empty Exception block
                }
            }
        }
    }

    private static int? EnterNumber(int? number, string? input)
    {
        try
        {
            
            number = int.Parse(input);
            Console.WriteLine($"The value is: {number}");
            

        }
        catch (FormatException exception)
        {
            throw new ArgumentException("Input is not a valid integer.", paramName:nameof(input), innerException:exception);   
        }
        
        return number;
    }
}




