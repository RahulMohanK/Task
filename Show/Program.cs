using System;
using StaffLibrary;
using OperationLibrary;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Show
{

    class Program
    {
        public int menuOpt;
        public void Teaching()
        {

            do
            {

                Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Retrieve Single Staff\n4.Delete Staff\n5.Edit Staff \n6.Exit");
                menuOpt = Convert.ToInt32(Console.ReadLine());
                TeachingStaffOperation teachingStaffOperation = new TeachingStaffOperation();

                switch (menuOpt)
                {
                    case 1:
                        teachingStaffOperation.AddStaff();
                        break;
                    case 2:
                        teachingStaffOperation.RetrieveAllStaff();
                        break;
                    case 3:
                        teachingStaffOperation.RetrieveSingleStaff();
                        break;
                    case 4:
                        teachingStaffOperation.DeleteStaff();
                        break;
                    case 5:
                        teachingStaffOperation.EditStaff();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.Write("Invalid Option !!");
                        break;
                }
            }
            while (menuOpt != 6);
        }
        public void Administration()
        {


            do
            {
                Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Retrieve Single Staff\n4.Delete Staff\n5.Edit Staff \n6.Exit");
                menuOpt = Convert.ToInt32(Console.ReadLine());
                AdministrativeStaffOperation administrativeStaffOperation = new AdministrativeStaffOperation();
                switch (menuOpt)
                {
                    case 1:
                        administrativeStaffOperation.AddStaff();
                        break;
                    case 2:
                        administrativeStaffOperation.RetrieveAllStaff();
                        break;
                    case 3:
                        administrativeStaffOperation.RetrieveSingleStaff();
                        break;
                    case 4:
                        administrativeStaffOperation.DeleteStaff();
                        break;
                    case 5:
                        administrativeStaffOperation.EditStaff();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.Write("Invalid Option !!");
                        break;
                }
            }
            while (menuOpt != 6);
        }
        public void Support()
        {

            do
            {

                Console.WriteLine("\n1.Add Staff \n2.Retrieve All Staff \n3.Retrieve Single Staff\n4.Delete Staff\n5.Edit Staff \n6.Exit");
                menuOpt = Convert.ToInt32(Console.ReadLine());
                SupportStaffOperation supportStaffOperation = new SupportStaffOperation();
                switch (menuOpt)
                {
                    case 1:
                        supportStaffOperation.AddStaff();
                        break;
                    case 2:
                        supportStaffOperation.RetrieveAllStaff();
                        break;
                    case 3:
                        supportStaffOperation.RetrieveSingleStaff();
                        break;
                    case 4:
                        supportStaffOperation.DeleteStaff();
                        break;
                    case 5:
                        supportStaffOperation.EditStaff();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.Write("Invalid Option !!");
                        break;
                }
            }
            while (menuOpt != 6);
        }
        static void Main(string[] args)
        {
            //  List<TeachingStaff> teachingList = new List<TeachingStaff>();

            //    int opt;
            //     do{
            //         Console.Clear();
            //         Console.WriteLine("Select the Type of Staff (1 /2 /3 /4) :\n 1. Teaching Staff\n 2. Administrative Staff\n 3. Support Staff\n 4. Exit"); 
            //         opt = Convert.ToInt32(Console.ReadLine());
            //          Program pgm = new Program();
            //         switch(opt)
            //         {
            //             case 1:  
            //                     pgm.Teaching();
            //                      break;
            //             case 2: 
            //                      pgm.Administration();
            //                      break;
            //             case 3: 
            //                      pgm.Support();
            //                      break;
            //             case 4: return;

            //             default : Console.WriteLine("Invalid Input !!");
            //                     break;
            //         }

            //     }
            //    while(opt!=4);  

            StaffOperation s = new StaffOperation();
            s.Print();
            // string[] list = s.configList("Subject");
            // foreach (var val in list)
            //     Console.WriteLine("this is value:" + val);
            // var a = ConfigurationManager.AppSettings["a"];
            // Console.WriteLine("This is value:" + a);



        }
    }
}
