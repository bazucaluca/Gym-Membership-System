


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


    static Member MemberSearch()//returns member of memberID user inputs
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






    // ==CREATE MEMBERS TEST PLAN==
    //
    // Create a standard member
    // Inputs: 001, Luca, Newman, 25, abcd@msn.com, 1
    // Expected: Member is added to MemberList with correct membership type, Console displays "Success"
    //
    // Create a premium member
    // Inputs: 002, john, doe, 50, johndoe@gmail.com, 2
    // Expected: Member is added to MemberList with correct membership type, Console displays "Success"
    //
    // Create a student member
    // Inputs: 003, george, clarke, 30, george@gmail.com, 3
    // Expected: Member is added to MemberList with correct membership type, Console displays "Success"
    //
    // entering a duplicate MemberID
    // Inputs: Entering MemberID 001 when 001 already exists
    // Expected: "Cannot create multiple members with the same ID", the member is not created
    //
    // entering an empty MemberID.
    // Inputs: Leave MemberID blank.
    // Expected: "Cannot have empty MemberID", the member is not created
    //
    // entering an empty firstname
    // Inputs: 004, dont enter anything for firstname and just press enter
    // Expected: "Cannot have empty First Name"
    //
    // entering an empty surname
    // Inputs: 005, dont enter anything for surname and just press enter
    // Expected: "Cannot have empty  Surname"
    //
    // entering a non-integer age
    // Inputs: enter "abc" for age
    // Expected: "Please enter a valid age"
    //
    // enter age=18 exactly
    // Inputs: enter 18 for age
    // Expected: "Age Must be over 18 to proceed"
    //
    // enter an age below 18
    // Inputs: entering 6 for age variable
    // Expected: "Age Must be over 18 to proceed"
    //
    // enter an email with an incorrect structure
    // Inputs: enter "johngmailcom"
    // Expected: "Enter a valid email address"
    //
  
    // Enter an invalid membership menu choice (not 1 2 or 3).
    // Inputs: enter 779.
    // Expected: "Invalid Choice entered"
    //
    // Enter a non-integer membership choice
    // Inputs: enter "abcdefg"
    // Expected: "Invalid choice entered"

    static void CreateMember()//Lets the user create a new member with attrinutes and add it to the list of members 
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
        if (MemberID == "")
        {
            Console.WriteLine("Cannot have empty MemberID");
            return;
        }
        Console.WriteLine("Enter First Name");
        string FName_ = Console.ReadLine();
        if (FName_ == "")
        {
            Console.WriteLine("Cannot have empty First Name");
            return;
        }
        Console.WriteLine("Enter Surname");
        string SName_ = Console.ReadLine();
        if (SName_ == "")
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

        if (!int.TryParse(Console.ReadLine(), out int MembershipMenuChoice))
        {
            Console.WriteLine("Invalid choice entered");
            return;
        }
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





    //==List Members Test plan==
    // 
    // Tests for this section can be seen during sests for other Functions e.g. create,update, and delete members
    //
    static void ListMembers()//outpusts the attributes of all of the members that currently exist
    {
        Console.WriteLine("list members");
        foreach (Member member in MemberList)
        {
            Console.WriteLine("____________________");
            Console.WriteLine($"{member.MemberID} {member.FName} {member.Sname} {member.Age} {member.Email} {member.MemberMembership}");


        }
    }
    static void SearchMember()//outputs attributes of the member which was searched by MemberSearch()
    {
        Member SearchMember = MemberSearch();
        if (SearchMember != null)
        {
            Console.WriteLine($"{SearchMember.MemberID} {SearchMember.FName} {SearchMember.Sname} {SearchMember.Age} {SearchMember.Email} {SearchMember.MemberMembership}");
        }
    }

    static void UpdateMember()//allows the user to change attributes of members which already exist
    {
        bool UpdateComplete = false;
        Member UpdateMember = MemberSearch();

        if (UpdateMember != null)
        {
            Console.WriteLine("--CHOOSE A FIELD TO UPDATE--\r\n1. First Name\r\n2. Surname\r\n3. Age\r\n4. Email\r\n5. Membership Type\r\nPlease select an option:");

            if (!int.TryParse(Console.ReadLine(), out int UpdateChoice))
            {
                Console.WriteLine("Please enter a valid number");
                return;
            }

            switch (UpdateChoice)
            {
                case 1:
                    Console.WriteLine("Enter new First Name");
                    string UpdateFName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(UpdateFName))//check for empty
                    {
                        Console.WriteLine("Cannot have empty First Name");
                        break;
                    }

                    UpdateMember.FName = UpdateFName;
                    UpdateComplete = true;
                    break;

                case 2:
                    Console.WriteLine("Enter new Surname");
                    string UpdateSName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(UpdateSName))//check for empty
                    {
                        Console.WriteLine("Cannot have empty Surname");
                        break;
                    }

                    UpdateMember.Sname = UpdateSName;
                    UpdateComplete = true;
                    break;

                case 3:
                    Console.WriteLine("Enter new Age");

                    if (!int.TryParse(Console.ReadLine(), out int UpdateAge))
                    {
                        Console.WriteLine("Please enter a valid age");
                        break;
                    }

                    if (UpdateAge <= 18)
                    {
                        Console.WriteLine("Age Must be over 18 to proceed");
                        break;
                    }

                    UpdateMember.Age = UpdateAge;
                    UpdateComplete = true;
                    break;

                case 4:
                    Console.WriteLine("Enter new Email");
                    string UpdateEmail = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(UpdateEmail) || !UpdateEmail.Contains("@") || !UpdateEmail.Contains("."))//checks is the email feild is empty or is an incirrect structuire
                    {
                        Console.WriteLine("Enter a valid email address");
                        break;
                    }

                    UpdateMember.Email = UpdateEmail;
                    UpdateComplete = true;
                    break;

                case 5:
                    Console.WriteLine("Enter New Membership type");
                    string UpdateMembershipType = Console.ReadLine();

                    Membership UpdateMembership = MembershipSearch(UpdateMembershipType);

                    if (UpdateMembership != null)
                    {
                        UpdateMember.MemberMembership = UpdateMembership;
                        UpdateComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("Membership Not Updated");
                    }

                    break;

                default:
                    Console.WriteLine("Not an option");
                    break;
            }
        }

        if (UpdateComplete == true)
        {
            Console.WriteLine("Update Completed");
        }
    }

    static void RemoveMember()//removes a member from the memberlist
    {
        Member DeleteMember = MemberSearch();
        if (DeleteMember != null)
        {
            MemberList.Remove(DeleteMember);
        }
    }
    static void MemberSummary()//outputs the montly and annual income from memberships and the total umber of memberships
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

            if ((int.TryParse(Console.ReadLine(), out MenuChoice) == false))
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
        while (MenuChoice != 0);
    }
}
class Member
{
    public string MemberID { get; set; }
    public string FName { get; set; }
    public string Sname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public Membership MemberMembership;
    public Member(string MemberID_, string FName_, string Sname_, int Age_, string Email_, Membership MemberMembership_)
    {
        MemberID = MemberID_; FName = FName_; Sname = Sname_; Age = Age_; Email = Email_; MemberMembership = MemberMembership_;
        Console.WriteLine("sucess");
    }

}
class Membership
{
    public string MembershipType { get; set; }
    public decimal MembershipPrice { get; set; }
    public Membership(string MembershipType_, decimal MembershipPrice_)
    {
        MembershipType = MembershipType_; MembershipPrice = MembershipPrice_;
    }

}