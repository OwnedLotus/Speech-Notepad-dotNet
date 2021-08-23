using System;
using System.Speech.Recognition;
using System.Threading;

namespace SpeechNotepad
{
    class Program
    {
        static ManualResetEvent completed = null;

        static void Main(string[] args)
        {
            Choices choices = new Choices(new string[] { "Testing" });
            completed = new ManualResetEvent(false);    
            
            SpeechRecognitionEngine speechRecognitionEngine = new SpeechRecognitionEngine();
            speechRecognitionEngine.LoadGrammarAsync(new Grammar( new GrammarBuilder(choices) ) );
            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;

            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            completed.WaitOne();
            speechRecognitionEngine.Dispose();
                
            
        }

        private static void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Testing")
            {
                Console.WriteLine("Testing Successful");
            }
            else if(e.Result.Text == "Hello")
            {
                Console.WriteLine("Hello World");
            }
            else
            {
                Console.WriteLine("Speech Not Recognized");
            }
        }
    }
}
