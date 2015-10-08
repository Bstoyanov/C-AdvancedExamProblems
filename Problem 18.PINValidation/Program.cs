using System;

namespace Problem_18.PINValidation
{    
    class PinValidation
    {
        
        static void Main(string[] args)
        {
            
           
           string [] names = Console.ReadLine().Split();
            string name = "";
            if (names.Length == 1)
            {
                name = names[0];
            }
            else
            {
                name = names[0] + " " + names[1];
            }
              bool   genderCheck = false;
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();
            int maleOrFemale = int.Parse(pin[9].ToString());
            if (maleOrFemale % 2 == 0 && gender =="male" ||
                maleOrFemale % 2 !=0&&
                gender =="female")
            {
                genderCheck = true;
            }

            
                Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, pin);
            
             //   Console.WriteLine("<h2>Incorrect data</h2>");
              
            
          
            

        }
    }
}
