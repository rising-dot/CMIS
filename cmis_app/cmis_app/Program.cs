using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace cmis_app
{
class Program
{
    static void Main(string[] args)
    {
        //Color
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;


        // create folder if not exist --- C:\cmis_data\database.txt
        createFolder(); 

        //Start Menu
        menu();
    }


    //**************************************************
    // Main Menu Welcome Page
    //**************************************************
    static void menu()
    {


        writeMassage("  .oooooo.   ooo        ooooo  ooooo   .oooooo..o ", 0, 4);
        writeMassage(" d8P'  `Y8b  `88.       .888'  `888'  d8P'    `Y8 ", 0, 5);
        writeMassage("888           888b     d'888    888   Y88bo.      ", 0, 6);
        writeMassage("888           8 Y88. .P  888    888    `Y8888o.   ", 0, 7);
        writeMassage("888           8  `888'   888    888       `Y88b   ", 0, 8);
        writeMassage("`88b    ooo   8    Y     888    888   oo     .d8P ", 0, 9);
        writeMassage(" `Y8bood8P'  o8o        o888o  o888o  88888888P'  ", 0, 10);
        
        writeMassage("Nyhedsbrev", 0, 13);

        displaySwitch();
        

    }


    //**************************************************
    // Create new user - function
    //**************************************************
    static void createUser()
    {

        string telefon = "";
        string navn = "";
        string efternavn = "";
        string adresse = "";   
        string postnr = "";
        string by = "";
        string email = "";     

        

        //**************************************************
        // Validate of phone number
        //**************************************************
        string msg = "";
        bool endPhone = true;

        Console.Clear();
        writeMassage("<<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>", 0, 0);
        writeMassage("Indtast og tryk enter", 0, 3);
        writeMassage("Telefon nr   :", 0, 5);
        writeMassage("Navn         :", 0, 6);
        writeMassage("Efternavn    :", 0, 7);
        writeMassage("Adresse      :", 0, 8);
        writeMassage("Postnr       :", 0, 9);
        writeMassage("By           :", 0, 10);
        writeMassage("Email        :", 0, 11);
        writeMassage("[*] Tilbage til menu", 0, 21);


        do
        {

            writeMassage("Telefon nr   :", 0, 5);
            writeMassage(msg, 0, 15);
            
            // get input from user
            Console.SetCursorPosition(23, 5);
            string phoneNumb = Console.ReadLine();   

            //exit back to menu
            exitToMenu(phoneNumb);
        
            
            // Check if input is a Int and Check if the phone number is 8 length
            int value;
            if (int.TryParse(phoneNumb, out value) == true && phoneNumb.Length == 8)
            {
                
                // check if input phone number is in database.txt
                string getPath = @"C:\cmis_data\database.txt";
                string data = File.ReadAllText(getPath);
                    

                if(data.Contains(phoneNumb))
                {

                    // If in database.txt display message and start all over
                    msg = "***Telefonnummeret er allerede i brug. Vælg et nyt nummer***";
                    removeMsg(5);
                }
                else
                {

                    // else save the phone number in our telefon variable and stop the loop
                    writeMassage("Telefon nr   : "+ value + "    OK! Kan oprettes", 0, 5);
                    telefon = phoneNumb;

                    endPhone = false;
                }

            }
            else
            {
                // display message and start all over
                msg = "***Telefonnummeret skal være 8 cifre langt og må ikke indholde bogstaver***";
                removeMsg(5);
            }



        } while (endPhone);



        // remove the msg text if there was any misstake
        removeMsg(15);

        // set CursorPosition and get input from user and save it to navn variable 
        navn = checkIfEmpty(6);
        exitToMenu(navn);

        // set CursorPosition and get input from user and save it to navn variable 
        efternavn = checkIfEmpty(7);
        exitToMenu(efternavn);
        
        // set CursorPosition and get input from user and save it to address variable
        adresse = checkIfEmpty(8);
        exitToMenu(adresse);



        //**************************************************
        // Validate of post number
        //**************************************************
        string msg_post = "";
        bool endPost = true;

        do
        {

            writeMassage("Postnr       : ", 0, 9);
            writeMassage(msg_post, 0, 15);

            // get input from user1
            Console.SetCursorPosition(23, 9);
            string postNumb = Console.ReadLine();
            exitToMenu(postNumb);

            // Check if input is a Int and check if the post number is 4 length
            int value;
            if (int.TryParse(postNumb, out value) == true && postNumb.Length == 4)
            {

                // save the post number in our postnr variable and stop the loop
                postnr = postNumb;
                endPost = false;

            }
            else
            {
                // display message and start all over
                msg_post = "******Post nr skal være 4 karakterer langt og må ikke indholde bogstaver***";
                removeMsg(9);
            }


        } while (endPost);


        // remove the msg if there was any misstake
        removeMsg(15); 

        // set CursorPosition and get input from user and save it to by variable
        by = checkIfEmpty(10);
        exitToMenu(by);


        
        //**************************************************
        // Validate of Email
        //**************************************************
    
        string msg_email = "";
        bool endEmail = true;

        do
        {

            writeMassage("Email        :", 0, 11);
            writeMassage(msg_email, 0, 15);
            
            // get input from user
            Console.SetCursorPosition(23, 11);
            string emailName = Console.ReadLine();
            exitToMenu(emailName);
            
            // Check for @ in email
            if(emailName.Contains("@"))
            {
                // If @ is in email stop the loop and save the email in email variable
                email = emailName;
                endEmail = false;
            }
            else
            {
                // display message and start all over
                msg_email = "***Du har ikke @ i din email***";
                removeMsg(11);
            }

        } while (endEmail);                  
            

        // remove the msg if there was any misstake
        removeMsg(15);

        // Set Cursor Position and display message
        writeMassage("Oplysninger gemmes .....", 0, 16);

        
        // save all info in database.txt
        string pathDatabase = @"C:\cmis_data\database.txt";  
        string createDatabase = telefon+", "+ navn+" "+efternavn+", "+ adresse+", "+ postnr+", "+ by+", "+ email+"\n";
        File.AppendAllText(pathDatabase, createDatabase);


        // display mini menu 
        displaySwitch();

    }



    //**************************************************
    // Find a user
    //**************************************************
    static void findUser()
    {
        
        writeMassage("<<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>", 0, 0);
        writeMassage("Indstast et telefonnummer for at finde en bruger.", 0, 3);
        writeMassage("[*] Tilbage til menu", 0, 21);


        bool fundUser = false;

        // Get user by number
        Console.SetCursorPosition(8, 5);
        string getInput = Console.ReadLine();
        exitToMenu(getInput);
        
        
        // get all user from database.txt
        string getPath = @"C:\cmis_data\database.txt";    
        string[] data = File.ReadAllLines(getPath);
        

        if (data == null || data.Length == 0)
	    {
    
            Console.WriteLine("array is empty");

            // loop it
            /*
            foreach (var item in data)
            {
          
                // if we have a match 
                if (getInput == item.Substring(0, 8))
                {
                    // display massage and stop the loop
                    writeMassage("Resultat: " + item, 0, 7);
                    fundUser = true;
                }
            }
            */
	    }


      
        
        // display massage if we did not find the user
        if (fundUser == false)
        {
            
            writeMassage("Brugeren findes ikke", 0, 7);
        }

        displaySwitch();
        
    }



    //**************************************************
    //Show all User
    //**************************************************
    static void showAllUser()
    {

        Console.WriteLine("Password:");
        string password = Console.ReadLine();
        Console.Clear();
        

        if (password == "admin")
        {

            // get all user from database.txt
            string getPath = @"C:\cmis_data\database.txt";   
            string[] data = File.ReadAllLines(getPath);

            writeMassage("Der er i alt "+ data.Length +" linier i datafilen", 0, 0);
            writeMassage("Vise mere - Tryk en tast !", 0, 22);


            // loop it
            for(int i = 0; i < data.Length; i++)
            {
                
                //display only 15 at a time
                if ((i % 15) == 0)
                {

                    Console.ReadKey();
                    Console.Clear();
                    writeMassage("Der er i alt "+(data.Length-i) +" linier i datafilen", 0, 0);
                    writeMassage("Vise mere - Tryk en tast !", 0, 22);
                    writeMassage("Indhold af databasen", 0, 3);

                    Console.WriteLine("".PadLeft(8,' ') +data[i]);

                }
                else //display the rest
                {
                    
                    Console.WriteLine("".PadLeft(8,' ') +data[i]);
                }
            }


            // Set Cursor Position and display message and exit app
            writeMassage("Ikke mere at vise - Tryk en tast for at gå tilbage til menu!", 0, 22);
            Console.ReadKey();
            Console.Clear();
            menu();


        }
        else
        {

            menu();
        }


    }


    static void displaySwitch()
    {

        // display menu
        writeMassage("[O] Opret    [F] Find    [Q] Afslut", 0, 22);
        Console.WriteLine("\n");
        Console.Write("".PadLeft(8,' ') +"Vælg funktion : ");

    
        // get value of 1 char
        string tast = Console.ReadLine().ToLower();

        // input the 1 char into the switch
        switch (tast)
        {

            case "o":
                Console.Clear();
                createUser();
                break;
            case "f":
                Console.Clear();
                findUser();
                break;
            case "show all":
                Console.Clear();
                showAllUser();
                break;
            case "q":
                Console.Clear();
                exitApp();
                break;
            default:
                Console.Clear();
                err();
                break;
        }       

    }

    // check if input is empty
    public static string checkIfEmpty(int x)
    {

        bool notEmpty = true;
        string txtValue = "";

        do
        {
            // set position and get input from user
            Console.SetCursorPosition(23, x);
            string inputTxt = Console.ReadLine();

            // if not empty set text and stop loop
            if (!String.IsNullOrEmpty(inputTxt))
            {

                removeMsg(15);
                txtValue = inputTxt;
                notEmpty = false;
            }
            else
            {
                
                writeMassage("***Tekstfelt kan ikke være tom***", 0, 15);
            }


        } while (notEmpty);


        return txtValue;

    }



    // remove text to reset the text
    static void removeMsg(int pos)
    {
        // remove error massage
        Console.SetCursorPosition(0, pos);
        Console.Write(new string(' ', Console.WindowWidth)); 
    }

    // if user misstype input go back to menu
    static void err()
    {
        // if you pick a worng letter at the menu reset the menu by calling the function again
        menu();

    }

    // exit function to go back to the menu
    static void exitToMenu(string exit)
    {
        if (exit == "*")
        {
            Console.Clear();
            menu();
        }
    }

    // write function to set the position of the text
    static void writeMassage(string text, int xPos, int yPos)
    {
        Console.SetCursorPosition(xPos, yPos);
        Console.WriteLine("".PadLeft(8,' ') + text);
    }

    
    static void exitApp()
    {
        // exit App
    }


    static void createFolder()
    {
        
        string folderName = @"C:\cmis_data";

        // If directory does not exist, create it
        if (!Directory.Exists(folderName)) {
            
            // create folder
            Directory.CreateDirectory(folderName);

            // create file
            File.Create(@"C:\cmis_data\database.txt").Close();

        }
       
    }




       




}
}



