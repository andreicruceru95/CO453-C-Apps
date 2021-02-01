namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application will read integer type values from the user
    /// and convert it to a chosen unit value.
    /// </summary>
    /// <author>
    /// Andrei Cruceru version 0.1
    /// </author>
    public class DistanceConverter
    {
        /*f
                Print a heading.
        */
        public void PrintHeading()
        {
            System.Console.WriteLine ("\tDistance Converter\n\tAuthor: Andrei Cruceru\n");
        }
        /*
        Print a message that asks the user for input
        */
        public int SelectMainUnit()
        {
            System.Console.WriteLine("\tPlease enter your choice: \n"); 

            PrintUnitList();   

            return int.Parse(System.Console.ReadLine());  
        }        

        /*
        Print a message that asks the user for a conversion unit.
        */
        public int SelectConversionUnit()
        {
            System.Console.WriteLine("\tPlease chose distance unit to convert to: \n");

            PrintUnitList();

            return int.Parse(System.Console.ReadLine());
            
        }

        /*
        Print a list of distance unit options.
        */
        public void PrintUnitList()
        {
            System.Console.WriteLine("\t1: " + DistanceUnits.Feet +
                        "\n\t2: " + DistanceUnits.Metres + "\n\t3: " + DistanceUnits.Kilometres + 
                        "\n\t4: " + DistanceUnits.Miles + "\n" + "\n\t5" + DistanceUnits.NoUnit);
        }

        /*
        Recieve the conversion amount from the user.
        */
        public int ReadAmount()
        {
            System.Console.WriteLine("\n\tPlease select amount!");
            
            return int.Parse(System.Console.ReadLine()); 

        }

        /*
        Convert units.
        */
        public double ConvertUnits(int choice)
        {
            switch(choice)
            {
                case 1: 
                     return 0.000189394;
                case 2:
                     return 0.000621371;
                case 3:
                    return 0.621371;
                case 4:
                    return 1;
                default:
                    return 1; 
            }
        }

        
   }
}
