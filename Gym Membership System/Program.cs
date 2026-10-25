using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        
        Program.Menu();




    }
    static void Menu()
    {
        List<Member> MemberList = new List<Member>();
        int MenuChoice = -1;
        //Prints the menu choices
        
        do
        { 
            Console.WriteLine("========================================\r\nGYM MEMBERSHIP SYSTEM\r\n========================================\r\n1. Create Member\r\n2. List Members\r\n3. Search for Member\r\n4. Update Member\r\n5. Remove Member\r\n6. Membership Summary\r\n0. Exit\r\nPlease select an option:");
            MenuChoice = int.Parse(Console.ReadLine());

            switch (MenuChoice)
            {
                case 0://Exit

                    Console.WriteLine("exit");
                    break;
                case 1://Create a member
                    Console.WriteLine("Enter MemberID");
                    string MemberID = Console.ReadLine();
                    Console.WriteLine("Enter First Name");
                    string FName_ = Console.ReadLine();
                    Console.WriteLine("Enter Surname");
                    string SName_ = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    int Age_ = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Email");
                    string Email_ = Console.ReadLine();
                    Member member1 = new Member(MemberID, FName_, SName_, Age_, Email_);
                    MemberList.Add(member1);
                    break;
                case 2://List members
                    Console.WriteLine("list members");
                    foreach (Member member in MemberList)
                    {
                        Console.WriteLine("_");
                        Console.WriteLine($"{member.MemberID} {member.FName} {member.Sname} {member.Age} {member.Email}");


                    }

                        break;
                case 3://Member Search
                    Console.WriteLine("");
                    break;
                case 4://Update member
                    Console.WriteLine();
                    break;
                case 5://Remove meber
                    Console.WriteLine();
                    break;

                case 6://Member summary
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Invalid input, enter a number 0-6");
                    break;
            }
        }
        while (0 <= MenuChoice && MenuChoice <= 6);
    }
}
    class Member
    {
        public string MemberID;
        public string FName;
        public string Sname;
        public int Age;
        public string Email;
        public Member(string MemberID_, string FName_, string Sname_, int Age_, string Email_)
        {
            MemberID = MemberID_; FName = FName_; Sname = Sname_; Age = Age_; Email = Email_;
        Console.WriteLine("success");
        }
    }
