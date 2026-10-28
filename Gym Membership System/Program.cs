using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static List<Member> MemberList = new List<Member>();
    static void Main(string[] args)
    {
        
        Program.Menu();




    }

    static Member MemberSearch()//returns member
    {
        Console.WriteLine("Enter MemberID of desired member");
        string SearchID = Console.ReadLine();
        foreach (Member member in MemberList)
            if (member.MemberID == SearchID)
            {
                return member;
            }
        Console.WriteLine("Member not found");
                return null;
            
    }
    static void Menu()
    {
        
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
                    Environment.Exit(0);
                    break;
                case 1://Create a member
                    Console.WriteLine("Enter MemberID");
                    string MemberID = Console.ReadLine();
                    bool IDExists = false; //checking if the Member ID already exists
                    foreach (Member member in MemberList)
                    {
                        if (member.MemberID == MemberID)
                        {
                            IDExists = true;
                            Console.WriteLine("Cannot create multiple members with the same ID");
                            break;

                        }
                        if (IDExists) { break; }
                    }
                    Console.WriteLine("Enter First Name");
                    string FName_ = Console.ReadLine();
                    Console.WriteLine("Enter Surname");
                    string SName_ = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    int Age_ = int.Parse(Console.ReadLine());
                    if (Age_ < 18)
                    {
                        Console.WriteLine("Age Must be over 18 to proceed");
                        break;
                    }

                    Console.WriteLine("Enter Email");
                    string Email_ = Console.ReadLine();
                    Member member1 = new Member(MemberID, FName_, SName_, Age_, Email_);
                    MemberList.Add(member1);
                    break;
                case 2://List members
                    Console.WriteLine("list members");
                    foreach (Member member in MemberList)
                    {
                        Console.WriteLine("____________________");
                        Console.WriteLine($"{member.MemberID} {member.FName} {member.Sname} {member.Age} {member.Email}");


                    }

                        break;
                case 3://Member Search
                    
                   Member SearchMember = MemberSearch();
                    if (SearchMember != null){
                        Console.WriteLine($"{SearchMember.MemberID} {SearchMember.FName} {SearchMember.Sname} {SearchMember.Age} {SearchMember.Email}");
                    }
                    break;
                case 4://Update member
                    Member UpdateMember = MemberSearch();
                    if (UpdateMember != null)
                    {

                        Console.WriteLine("--CHOOSE A FIELD TO UPDATE--\r\n1. First Name\r\n2. Surname\r\n3. Age\r\n4. Email\r\nPlease select an option:");
                        int UpdateChoice = int.Parse(Console.ReadLine());
                        switch (UpdateChoice)
                        {

                            case 1:
                                Console.WriteLine("Enter new First Name");
                                UpdateMember.FName = Console.ReadLine();
                                break;

                            case 2:
                                Console.WriteLine("Enter new Surname");
                                UpdateMember.Sname = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter new Age");
                                int UpdateAge = int.Parse(Console.ReadLine());
                                if (UpdateAge <= 18) {
                                    Console.WriteLine("Age Must be Over 18");
                                    break;
                                        }
                                UpdateMember.Age = UpdateAge;
                                break; 
                            case 4:
                                Console.WriteLine("Enter new Email");
                                UpdateMember.Email = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Not an option");
                                break;
                        }
                        Console.WriteLine("Update Complete");
                    }
                    break;
                        

            
                case 5://Remove meber
                    Member DeleteMember = MemberSearch();
                    if (DeleteMember != null)
                    {
                        MemberList.Remove(DeleteMember);
                    }
                    break;

                case 6://Member summary

                    int TotalMembers = MemberList.Count;
                    int MonthIncome = TotalMembers * 30;
                    int AnnualIncome = MonthIncome * 12;
                    Console.WriteLine($"Total number of members: {TotalMembers}");
                    Console.WriteLine($"Monthly Membership Income: £{MonthIncome}");
                    Console.WriteLine($"Annual Income: £{AnnualIncome}");
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
        public string MemberID { get; set; }
    public string FName{ get; set; }
    public string Sname{ get; set; }
    public int Age{ get; set; }
    public string Email{ get; set; }
    public decimal fee=30;
        public Member(string MemberID_, string FName_, string Sname_, int Age_, string Email_)
        {
            MemberID = MemberID_; FName = FName_; Sname = Sname_; Age = Age_; Email = Email_;
        Console.WriteLine("success");
        }
    public decimal CalcAnnualCost()
    {
        return fee * 12;
    }
}
class membership
{
    string MembershipType { get; set; }
    int MembershipPrice { get; set; }
}
