using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static List<Member> MemberList = new List<Member>();//list of members
    static List<Membership> MembershipList = new List<Membership>();//list of memberships
    static Membership Standard = new Membership("Standard", 30);
    static Membership Premium = new Membership("Premium", 45);
    static Membership Student = new Membership("Student", 20);
    static void Main(string[] args)
    {
        MembershipList.Add(Standard);  
        MembershipList.Add(Premium);
        MembershipList.Add(Student);
        Menu();




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
    static Membership MembershipSearch(string SearchMembership)//returns membership
    {

        foreach (Membership membership in MembershipList)
        {
            if (membership.MembershipType == SearchMembership)
            {
                return membership;
            }
            
                
            
        }
        Console.WriteLine("Membership not found");
        return null;
    }


    static void CreateMember()
    {
        Console.WriteLine("Enter MemberID");
        string MemberID = Console.ReadLine();
        bool IDExists = false; //checking if the Member ID already exists
        foreach (Member member in MemberList)
        {
            if (member.MemberID == MemberID)
            {
                IDExists = true;
                Console.WriteLine("Cannot create multiple members with the same ID");
                return;

            }

        }
        if (IDExists) { return; }
        if (MemberID = "") { 
            Console.WriteLine("Cannot have empty MemberID");
            return;
        }
        Console.WriteLine("Enter First Name");
        string FName_ = Console.ReadLine();
        if (FName_ = "")
        {
            Console.WriteLine("Cannot have empty First Name");
            return;
        }
        Console.WriteLine("Enter Surname");
        string SName_ = Console.ReadLine();
        if (SName_ = "")
        {
            Console.WriteLine("Cannot have empty Surname");
            return;
        }
        Console.WriteLine("Enter Age");
        if (!int.TryParse(Console.ReadLine(), out int Age_))
        {
            Console.WriteLine("Please enter a valid age");
            return;
        }
        if (Age_ <= 18)
        {
            Console.WriteLine("Age Must be over 18 to proceed");
            return;
        }

        Console.WriteLine("Enter Email");
        string Email_ = Console.ReadLine();
        if (!Email_.Contains("@") || !Email_.Contains("."))
        {
            Console.WriteLine("Enter a valid email address");
            return;
        }
        Console.WriteLine("Enter membership type:\r\n Standard: £30\r\nPremium: £45, 1 free fitness class per month\r\nStudent £20, 10% student discount\r\nEnter 1 for standard, 2 for premium, 3 for student");

        int MembershipMenuChoice = int.Parse(Console.ReadLine());
        string MembershipChoice;
        switch (MembershipMenuChoice)
        {
            case 1:
                MembershipChoice = "Standard";
                break;
            case 2:
                MembershipChoice = "Premium";
                break;
            case 3:
                MembershipChoice = "Student";
                break;
            default:
                Console.WriteLine("Invalid Choice entered");
                return;
                break;
        }
        Membership MemberMembership_ = MembershipSearch(MembershipChoice);
        Member member1 = new Member(MemberID, FName_, SName_, Age_, Email_, MemberMembership_);
        MemberList.Add(member1);
    }
    static void ListMembers()
    {
        Console.WriteLine("list members");
        foreach (Member member in MemberList)
        {
            Console.WriteLine("____________________");
            Console.WriteLine($"{member.MemberID} {member.FName} {member.Sname} {member.Age} {member.Email} {member.MemberMembership}");


        }
    }
    static void SearchMember()
    {
        Member SearchMember = MemberSearch();
        if (SearchMember != null)
        {
            Console.WriteLine($"{SearchMember.MemberID} {SearchMember.FName} {SearchMember.Sname} {SearchMember.Age} {SearchMember.Email} {SearchMember.MemberMembership}");
        }
    }
    static void UpdateMember()
    {
        bool UpdateComplete=false
        Member UpdateMember = MemberSearch();
        if (UpdateMember != null)
        {

            Console.WriteLine("--CHOOSE A FIELD TO UPDATE--\r\n1. First Name\r\n2. Surname\r\n3. Age\r\n4. Email\r\n5. Membership Type\r\nPlease select an option:");
            int UpdateChoice = int.Parse(Console.ReadLine());
            switch (UpdateChoice)
            {

                case 1:
                    Console.WriteLine("Enter new First Name");
                    UpdateMember.FName = Console.ReadLine();
                    UpdateComplete = true;
                    break;

                case 2:
                    Console.WriteLine("Enter new Surname");
                    UpdateMember.Sname = Console.ReadLine();
                    UpdateComplete = true;
                    break;
                case 3:
                    Console.WriteLine("Enter new Age");
                    if (!int.TryParse(Console.ReadLine(), out int UpdateAge))//if it is a valid numnber it is allowed to be stored in update age
                    {
                        Console.WriteLine("Please enter a valid age");
                        break;
                    }
                    UpdateMember.Age = UpdateAge;
                    UpdateComplete = true;
                    break;
                case 4:
                    Console.WriteLine("Enter new Email");
                    UpdateMember.Email = Console.ReadLine();
                    UpdateComplete = true;
                    break;
                case 5:
                    Console.WriteLine("enter New Membership type");
                    string UpdateMembershipType = Console.ReadLine();
                    Membership UpdateMembership = MembershipSearch(UpdateMembershipType);
                    if (UpdateMembership = null) ;
                    { 
                        UpdateMember.MemberMembership = UpdateMembership;
                        UpdateComplete = true;
                    }
                    else { 
                    Console.WriteLine("Membership Not Updated")
                    }


                        break;
                default:
                    Console.WriteLine("Not an option");
                    break;
            }
            
        }
        if (UpdateComplete = true) { Console.WriteLine("Update Completed Sucessfully")}
    }
    static void RemoveMember()
    {
        Member DeleteMember = MemberSearch();
        if (DeleteMember != null)
        {
            MemberList.Remove(DeleteMember);
        }
    }
    static void MemberSummary()
    {
        int StandardCount = 0;
        int PremiumCount = 0;
        int StudentCount = 0;
        foreach (Member member in MemberList)
        {
            if (member.MemberMembership.MembershipType == "Standard")
            {
                StandardCount++;
            }
            else if (member.MemberMembership.MembershipType == "Premium")
            {
                PremiumCount++;
            }
            else if (member.MemberMembership.MembershipType == "Student")
            {
                StudentCount++;
            }
        }
        int TotalMembers = MemberList.Count;
        decimal MonthIncome = 0;
        foreach (Member member in MemberList)
        {
            MonthIncome += member.MemberMembership.MembershipPrice;
        }
        decimal AnnualIncome = MonthIncome * 12;
        Console.WriteLine($"Total number of members: {TotalMembers}, Standard: {StandardCount}, Premium: {PremiumCount}, Student: {StudentCount}");
        Console.WriteLine($"Monthly Membership Income: £{MonthIncome}");
        Console.WriteLine($"Annual Income: £{AnnualIncome}");
    }
    static void Menu()
    {
        
        int MenuChoice = -1;
        
        do//loop waiting for user to inout a menu choice
        { 
            Console.WriteLine("========================================\r\nGYM MEMBERSHIP SYSTEM\r\n========================================\r\n1. Create Member\r\n2. List Members\r\n3. Search for Member\r\n4. Update Member\r\n5. Remove Member\r\n6. Membership Summary\r\n0. Exit\r\nPlease select an option:");
            
            if ((int.TryParse(Console.ReadLine(), out MenuChoice)==false))
            {
                Console.WriteLine("Please enter a valid number listed");
                continue;
            }

            switch (MenuChoice)
            {
                case 0:
                    Console.WriteLine("Are you sure you want to exit (Y/N)");
                    string ExitConfirm = Console.ReadLine();

                    if (ExitConfirm == "Y")
                    {
                        return;
                    }
                    else
                    {
                        MenuChoice = -1;
                    }
                    break;
                case 1://Create a member
                    CreateMember();
                    break;
                case 2://List members
                    ListMembers();
                        

                        break;
                case 3://Member Search

                    SearchMember();
                    break;
                case 4://Update member
                    UpdateMember();
                    break;
                        

            
                case 5://Remove meber
                    RemoveMember();
                    break;

                case 6://Member summary
                    MemberSummary();
                    break;
                    
                
                default:
                    Console.WriteLine("Invalid input, enter a number 0-6");
                    break;
            }
        }
        while (MenuChoice!=0);
    }
}
    class Member
    {
        public string MemberID { get; set; }
    public string FName{ get; set; }
    public string Sname{ get; set; }
    public int Age{ get; set; }
    public string Email{ get; set; }

    public Membership MemberMembership;
        public Member(string MemberID_, string FName_, string Sname_, int Age_, string Email_,Membership MemberMembership_)
        {
            MemberID = MemberID_; FName = FName_; Sname = Sname_; Age = Age_; Email = Email_;MemberMembership = MemberMembership_;
        Console.WriteLine("sucess");
        }
    
}
class Membership
{
    public string MembershipType { get; set; }
    public decimal MembershipPrice { get; set; }
    public Membership(string MembershipType_, decimal MembershipPrice_)
    {
        MembershipType=MembershipType_;MembershipPrice=MembershipPrice_;
    }
    
}
