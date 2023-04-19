using OOP;

string email = "okezdfs@mail.ru";
string login = "ewrwer";
string password = "12312.../__Olreg";

User user = new User(email,login,password);
Console.WriteLine(user.EmailValidation(user.Email));


Console.WriteLine("Welcome. That's our english learning simulator. Enjoy and accept my lab");
Console.WriteLine("***********************************************************************");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("You can chouse comand from next title, please enter index of command in Console");

int a = 0;
Console.WriteLine("Instruction");
Console.WriteLine();
Console.WriteLine("Enter 1, if you want enter your email");
Console.WriteLine("Enter 2, if you want enter your password");
Console.WriteLine("Enter 3, if you want add question");

switch(a)
{
    case 1:
        string? email1  = Console.ReadLine();
        Console.WriteLine(user.EmailValidation(email1));
        break;
    case 2:
        string? password1 = Console.ReadLine();
        Console.WriteLine(user.PasswordValidation(password1));
        break;

    case 3:

        break;
}