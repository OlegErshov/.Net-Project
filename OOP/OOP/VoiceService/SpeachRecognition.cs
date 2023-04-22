using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CognitiveServices.Speech;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;



namespace OOP.VoiceService
{
    internal class SpeachRecognition
    {
        public void Recognize()
        {
            using (
                  SpeechRecognitionEngine recognizer =
                    new SpeechRecognitionEngine(
                      new System.Globalization.CultureInfo("en-US")))
            {
                // Create and load a dictation grammar.  
               // recognizer.LoadGrammar(new Microsoft.Speech.Recognition.DictationGrammar());

                // Add a handler for the speech recognized event.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.  
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.  
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.  
                while (true)
                {
                    Console.ReadLine();
                }

            }
        }

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }
    } 
}
