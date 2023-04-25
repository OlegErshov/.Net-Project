using OOP.Authorization;
using OOP.NewFormOfQuestions;
using OOP.VoiceService;
using SpeechLib;
using System.Collections;

string email = "okezdfs@mail.ru";
string login = "ewrwer";
string password = "12312.../__Olreg";


List<string> question = new List<string> { "asdd", "asdfd" };


SpeachRecognition recognition = new SpeachRecognition();

User user = new User(email,login,password);
Console.WriteLine(user.EmailValidation(user.Email));


/*Dictionary<string,string> result = new Dictionary<string, string>();
result.Add("name","имя");
result.Add("money", "sosi");
result.Add("money", "деньги");
result.Add("tree", "дерево");
result.Add("window", "окно");
*/
/*foreach (var item in result)
{
    Console.WriteLine(item);
}*/



Console.WriteLine("Welcome. That's our english learning simulator. Enjoy and accept my lab");
Console.WriteLine("***********************************************************************");
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
Console.WriteLine("Enter 5, if you want add Question");
Console.WriteLine("Enter 6, if you want cheak Question");

TranslateQuestion tq = new TranslateQuestion();

while (true) {
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

        case 5:
            
            Console.WriteLine("Введите текст, которой вы бы хотели проверить на перевод, по окончанию введите 0");

            string s = Console.ReadLine();
            tq.AddQuestion(tq.stringDivisionOnwords(s));

            Console.WriteLine("Введите перевод текста");

            string str = Console.ReadLine();
            tq.AddAnswer(tq.stringDivisionOnwords(str));

            Console.WriteLine("Введите cлова");

            string ans = Console.ReadLine();
            tq.AddWordsVarients(tq.stringDivisionOnwords(ans));

            break;

        case 6:
            Console.WriteLine("введите перевод");

            Console.WriteLine(tq.CheakQuestion(tq.stringDivisionOnwords(Console.ReadLine())));
            break;
    }

}