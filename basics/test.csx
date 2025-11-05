// using System;

// public class Program
// {
//     // Instance variable for the name
//     public string name;

//     // Main method should be static to act as the entry point
//     public static void Main()
//     {
//         // Create an instance of Program to access instance members
//         Program programInstance = new Program();
        
//         // Prompt for user input and get the name
//         Console.WriteLine("Enter your name:");
//         programInstance.name = Console.ReadLine();  // Read user input and assign it to the instance variable
        
//         // Display the inputted name
//         programInstance.getName();  // Call the instance method to display the name
//     }

//     // Instance method to display the name
//     public void getName()
//     {
//         Console.WriteLine("Your name is: " + name);  // Access and print the instance variable "name"
//     }
// }


// using System;

// public class Program
// {
//     public string name;

//     // This Main method is not needed with dotnet-script
//     // We will remove it and execute the code directly.
//     // Instead, we directly write code outside of a Main() method

//     // Prompt for user input and get the name
//     Console.WriteLine("Enter your name:");
//     Program programInstance = new Program();
//     programInstance.name = Console.ReadLine();  // Read user input and assign it to the instance variable

//     // Display the inputted name
//     programInstance.getName();  // Call the instance method to display the name

//     // Instance method to display the name
//     public void getName()
//     {
//         Console.WriteLine("Your name is: " + name);  // Access and print the instance variable "name"
//     }
// }



using System;

// No need to have a Program class or Main method
// Just write your code directly in the script.

Console.WriteLine("Enter your name:");

// Read user input
string name = Console.ReadLine();

// Output the name
Console.WriteLine("Your name is: " + name);



pstree .  -Exclude */front-end/node_modules, *blockchaine_simulator/bin, *blockchaine_simulator/obj  | 
    Out-String | 
    ForEach-Object { $_ -replace '\x1b\[([0-9;]*[A-Za-z])', '' } | 
    Set-Content -Path "general_file_tree.txt"    