using System;
using StaffLibrary;
using OperationLibrary;
using System.Collections.Generic;
namespace Show
{
    
    class Program
    {
        
        public void Teaching()
        {
            int menuOpt;
            do{
                
            Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Exit");
            menuOpt = Convert.ToInt32(Console.ReadLine());
             TeachingStaffOperation teachingStaffOperation = new TeachingStaffOperation();
            
                            switch(menuOpt)
                            {
                                case 1: 
                                        teachingStaffOperation.AddStaff();
                                        break;
                                case 2: 
                                       teachingStaffOperation.RetrieveAllStaff();
                                        break;
                                case 3 :Console.Clear();

                                        return ;                                         
                                default : Console.Write("Invalid Option !!");
                                          break;
                            }
            }
            while(menuOpt!=3);
        }
        public void Administration()
        {
            
            int menuOpt;
            do{
            Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Exit");
            menuOpt = Convert.ToInt32(Console.ReadLine());
            AdministrativeStaffOperation administrativeStaffOperation = new AdministrativeStaffOperation();
                            switch(menuOpt)
                            {
                                case 1: administrativeStaffOperation.AddStaff();
                                        break;
                                case 2: administrativeStaffOperation.RetrieveAllStaff();
                                        break;
                                case 3 : Console.Clear();
                                        return;
                                         
                                default : Console.Write("Invalid Option !!");
                                          break;
                            }
            }
            while(menuOpt!=3);
        }
        public void Support()
        {
            int menuOpt;
            do{
            
            Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Exit");
            menuOpt = Convert.ToInt32(Console.ReadLine());
            SupportStaffOperation supportStaffOperation = new SupportStaffOperation();
                            switch(menuOpt)
                            {
                                case 1: supportStaffOperation.AddStaff();
                                         break;
                                case 2:  supportStaffOperation.RetrieveAllStaff();
                                         break;
                                case 3 : Console.Clear();
                                         return;          
                                default : Console.Write("Invalid Option !!");
                                          break;
                            }
            }
            while(menuOpt!=3);
        }
        static void Main(string[] args)
        {
            //  List<TeachingStaff> teachingList = new List<TeachingStaff>();
            
           int opt;
            do{
                Console.Clear();
                Console.WriteLine("Select the Type of Staff (1 /2 /3 /4) :\n 1. Teaching Staff\n 2. Administrative Staff\n 3. Support Staff\n 4. Exit"); 
                opt = Convert.ToInt32(Console.ReadLine());
                 Program pgm = new Program();
                switch(opt)
                {
                    case 1:  
                            pgm.Teaching();
                             break;
                    case 2: 
                             pgm.Administration();
                           break;
                    case 3: 
                             pgm.Support();
                             break;
                    case 4: return;
                             break;
                    default : Console.WriteLine("Invalid Input !!");
                            break;
                }
                
            }
            while(opt!=4);   
        }
    }
}
