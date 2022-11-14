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

            //Start Menu
            menu();
        }


        //**************************************************
        // Main Menu Welcome Page
        //**************************************************
        static void menu()
        {


            Console.WriteLine("     <<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("     Telefon nr   :");
            Console.WriteLine("     Navn         :");
            Console.WriteLine("     Efternavn    :");
            Console.WriteLine("     Adresse      :");
            Console.WriteLine("     Postnr       :");
            Console.WriteLine("     By           :");
            Console.WriteLine("     Email        :");

            Console.WriteLine("\n\n\n\n\n\n\n");
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

            do
	        {

                Console.Clear();
                Console.WriteLine("     <<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>");
                Console.WriteLine("\n\n");
                Console.WriteLine("     Indtast og tryk enter\n");

                
                Console.WriteLine("     Telefon nr   : ");
                Console.WriteLine("     Navn         : ");
                Console.WriteLine("     Efternavn    :");
                Console.WriteLine("     Adresse      : ");
                Console.WriteLine("     Postnr       : ");
                Console.WriteLine("     By           : ");
                Console.WriteLine("     Email        : ");

                Console.SetCursorPosition(0, 15);
                Console.WriteLine(msg);
                
                


                
                // get input from user
                Console.SetCursorPosition(20, 6);
                string phoneNumb = Console.ReadLine();   
               
               
                // Check if input is a Int and Check if the phone number is 8 length
                int value;
                if (int.TryParse(phoneNumb, out value) == true && phoneNumb.Length == 8)
                {
                    
                        // check if input phone number is in database.txt

                        string getPath = @"C:\cmis_data\checkUser.txt";
                        //string getPath = @"C:\Users\Rising\Desktop\CMIS_CODE\data\checkUser.txt";      // <---------------------------- change to your own diretory
                        string[] data = File.ReadAllLines(getPath);

                        if(data.Contains(phoneNumb))
                        {
                            // If in database.txt display message and start all over
                            msg = "     ***Telefonnummeret er allerede i brug. Vælg et nyt nummer***";
                        }
                        else
                        {
                            // else save the phone number in our telefon variable and stop the loop
                            Console.SetCursorPosition(20, 6);
                            Console.WriteLine("\r     Telefon nr   : "+ value + "    OK! Kan oprettes");
                            telefon = phoneNumb;

                            endPhone = false;
                        }



                }
                else
                {
                    // display message and start all over
                    msg = "     ***Telefonnummeret skal være 8 cifre langt og må ikke indholde bogstaver***";

                }



	        } while (endPhone);



    

            // remove the msg text if there was any misstake
            removeErrorMsg();


            // set CursorPosition and get input from user and save it to navn variable 
            navn = checkIfEmpty(7);

            // set CursorPosition and get input from user and save it to navn variable 
            efternavn = checkIfEmpty(8);

            // set CursorPosition and get input from user and save it to address variable
            adresse = checkIfEmpty(9);
          



            //**************************************************
            // Validate of post number
            //**************************************************
            string msg_post = "";
            bool endPost = true;

            do
	        {

                Console.Clear();
                Console.WriteLine("     <<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>");
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("     Telefon nr   : "+ telefon);
                Console.WriteLine("     Navn         : "+ navn);
                Console.WriteLine("     Efternavn    : "+ efternavn);
                Console.WriteLine("     Adresse      : "+ adresse);
                Console.WriteLine("     Postnr       : ");
                Console.WriteLine("     By           : ");
                Console.WriteLine("     Email        : ");
                
                
                Console.SetCursorPosition(0, 15);
                Console.WriteLine(msg_post);

                // get input from user
                Console.SetCursorPosition(20, 10);
                string postNumb = Console.ReadLine();   

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
                    msg_post = "     ******Post nr skal være 4 karakterer langt og må ikke indholde bogstaver***";
                }


	        } while (endPost);




            // remove the msg if there was any misstake
            removeErrorMsg(); 

            // set CursorPosition and get input from user and save it to by variable
            by = checkIfEmpty(11);
     


          
            //**************************************************
            // Validate of Email
            //**************************************************
      
            string msg_email = "";
            bool endEmail = true;
  
            do
	        {

                Console.Clear();
                Console.WriteLine("     <<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>");
                Console.WriteLine("\n\n\n\n");
                
                Console.WriteLine("     Telefon nr   : "+ telefon);
                Console.WriteLine("     Navn         : "+ navn);
                Console.WriteLine("     Efternavn    : "+ efternavn);
                Console.WriteLine("     Adresse      : "+ adresse);
                Console.WriteLine("     Postnr       : "+ postnr);
                Console.WriteLine("     By           : "+ by);
                Console.WriteLine("     Email        : ");
               
                
                Console.SetCursorPosition(0, 15);
                Console.WriteLine(msg_email);


                // get input from user
                Console.SetCursorPosition(20, 12);
                string emailName = Console.ReadLine();
                
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
                    msg_email = "     ***Du har ikke @ i din email***";
                }

	        } while (endEmail);                  
              


            // remove the msg if there was any misstake
            removeErrorMsg();


            // Set Cursor Position and display message
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("     Oplysninger gemmes .....");

           
            //C:\cmis_data
            // save all info in database.txt
            string pathDatabase = @"C:\cmis_data\database.txt";  // <---------------------------- change to your own diretory
            string createDatabase = telefon+", "+ navn+" "+efternavn+", "+ adresse+", "+ postnr+", "+ by+", "+ email+"\n";
            File.AppendAllText(pathDatabase, createDatabase);

            // save only phone number in checkUser.txt
            string pathCheckUser = @"C:\cmis_data\checkUser.txt"; // <---------------------------- change to your own diretory
            string createCheckUser = telefon+"\n";
            File.AppendAllText(pathCheckUser, createCheckUser);
            

            


            // display menu 
            Console.WriteLine("\n\n\n");
            displaySwitch();

       

        }
        //**************************************************
        // Find a user
        //**************************************************
        static void findUser()
        {
            
            Console.WriteLine("     <<<  Carsten Mørch Information System - Gæste-registrering v 1.0  >>>");
            Console.WriteLine("\n\n");
            Console.WriteLine("     Indstast et telefonnummer for at finde en bruger.");
            Console.SetCursorPosition(5, 5);

            bool fundUser = false;

            // Get user by number
            string getInput = Console.ReadLine();
            
            
            // get all user from database.txt
            string getPath = @"C:\cmis_data\database.txt";    // <---------------------------- change to your own diretory
            string[] data = File.ReadAllLines(getPath);
           

            // loop it 
            foreach (var item in data)
	        {
                // if we have a match 
                if (getInput == item.Substring(0, 8))
	            {
                    // display massage and stop the loop
                    Console.WriteLine("\n\n     Resultat: " + item);
                    fundUser = true;
                }
	        }


           
            // display massage if we did not find the user
            if (fundUser == false)
	        {
                Console.WriteLine("\n\n     Brugeren findes ikke");
	        }

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            displaySwitch();
          


        }


        //**************************************************
        //Show all User
        //**************************************************
        static void showAllUser()
        {

            
            string password = Console.ReadLine();

          

            if (password == "admin")
	        {

                // get all user from database.txt
                string getPath = @"C:\cmis_data\database.txt";    // <---------------------------- change to your own diretory
                string[] data = File.ReadAllLines(getPath);

                Console.WriteLine("     Der er i alt "+ data.Length +" linier i datafilen");
                Console.WriteLine("     Vise mere - Tryk en tast !");

                // loop it
                for(int i = 0; i < data.Length; i++)
                {
                    //display only 15 at a time
                    if ((i % 15) == 0)
                    {

                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("     Der er i alt "+(data.Length-i) +" linier i datafilen\n\n");
                        Console.WriteLine("     Indhold af databasen");
                        Console.WriteLine("     "+data[i]);

                    }
                    else
                    {
                     
                        Console.WriteLine("     "+data[i]);
                    }
                }


                // Set Cursor Position and display message and exit app
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("     Ikke mere at vise - Tryk en tast for at gå tilbage til menu!");
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
            
            Console.WriteLine("     [O] Opret    [F] Find    [Q] Afslut :");
            Console.WriteLine("\n");
            Console.Write("     Vælg function : ");

       
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


         public static string checkIfEmpty(int x)
        {

            bool notEmpty = true;
            string txtValue = "";

            do
	        {

                Console.SetCursorPosition(20, x);
                string inputTxt = Console.ReadLine();


                if (!String.IsNullOrEmpty(inputTxt))
	            {

                    removeErrorMsg();
                    txtValue = inputTxt;
                    notEmpty = false;
                }
                else
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("     ***Tekstfelt kan ikke være tom***");
                }


	        } while (notEmpty);


            return txtValue;

        }








        static void removeErrorMsg()
        {
            // remove error massage
            Console.SetCursorPosition(0, 15);
            Console.Write(new string(' ', Console.WindowWidth)); 
        }

        static void err()
        {
            // if you pick a worng letter at the menu reset the menu by calling the function again
            menu();

        }



      
        static void exitApp()
        {
            // exit App
        }






    }
}



