using OOP;
using OOP.VoiceService;

string email = "okezdfs@mail.ru";
string login = "ewrwer";
string password = "12312.../__Olreg";

SpeachRecognition recognition = new SpeachRecognition();

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
Console.WriteLine("Enter 0, if you want ended app");
Console.WriteLine("Enter 1, if you want enter your email");
Console.WriteLine("Enter 2, if you want enter your password");
Console.WriteLine("Enter 3, if you want add question");
Console.WriteLine("Enter 4, if you want recognize your speech");



while(true) {
    a = Int32.Parse(Console.ReadLine());
    switch (a)
    {
        case 0:
            break;
        case 1:
            string? email1 = Console.ReadLine();
            Console.WriteLine(user.EmailValidation(email1));
            break;
        case 2:
            string? password1 = Console.ReadLine();
            Console.WriteLine(user.PasswordValidation(password1));
            break;

        case 3:

            break;

        case 4:
            recognition.Recognize();
            break;
    }

}