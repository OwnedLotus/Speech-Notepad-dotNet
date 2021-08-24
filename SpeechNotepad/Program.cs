using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows10.0.17763.0")]

string[] userInput = null;

string word = null;

Choices choices = new Choices(new string[] { "Start", "Testing", "Save", "Quit", "Read" , "Repeat" });
SpeechRecognitionEngine engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
Grammar grammar = new Grammar(new GrammarBuilder (choices));

engine.LoadGrammarAsync(grammar);

engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Engine_SpeechRecognized);

engine.SetInputToDefaultAudioDevice();

engine.RecognizeAsync(RecognizeMode.Multiple);


while (true)
{
    Console.ReadLine();
}





static void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
{
    Console.WriteLine($"Recognized text: {e.Result.Text}");

    switch (e.Result.Text)
    {
        case "Start":
            Console.WriteLine("Turning on Notepad Speech Recognition....");
            StartNotepad();
            break;
        case "Testing":
            Console.WriteLine($"Testing Successfull!");
            break;
        case "Quit":
            Console.WriteLine("Quitting....");
            Thread.Sleep(1000);
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine(e.Result.Text);
            break;
    }
}


static void StartNotepad()
{
    using (SpeechRecognitionEngine recognizer =
        new SpeechRecognitionEngine(
            new System.Globalization.CultureInfo("en-US")))
    {
        recognizer.LoadGrammar(new DictationGrammar());

        recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);

        recognizer.SetInputToDefaultAudioDevice();

        recognizer.RecognizeAsync(RecognizeMode.Multiple);

        while (true)
        {
            Console.ReadLine();
        }
    }
}

static void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
{ 

}