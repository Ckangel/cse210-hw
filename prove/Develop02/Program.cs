using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;  // Install the Newtonsoft.Json NuGet package for JSON handling.

namespace JournalApp
// From more research with W3Schools I added Additional Library Newtonsoft.Json to handle JSON serialization/deserialization with Reminder System, Improved CSV handling, JSON support and Additional Entry information for mood and tags for better categorization
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Mood { get; set; }      // New: Mood tracking
        public List<string> Tags { get; set; } // New: Tagging system

        public Entry(string date, string prompt, string response, string mood, List<string> tags)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
            Mood = mood;
            Tags = tags;
        }

        // Improved CSV-friendly display format
        public string ToCsvFormat()
        {
            string escapedResponse = Response.Replace("\"", "\"\"");  // Escape quotes by doubling them
            string escapedPrompt = Prompt.Replace("\"", "\"\"");
            string tags = string.Join(",", Tags);

            return $"\"{Date}\",\"{escapedPrompt}\",\"{escapedResponse}\",\"{Mood}\",\"{tags}\"";
        }

        public override string ToString()
        {
            string tags = string.Join(", ", Tags);
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\nTags: {tags}";
        }
    }

    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        // Display all entries
        public void DisplayJournal()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(new string('-', 50));
            }
        }

        // Save journal to a CSV file
        public void SaveToCsv(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Prompt,Response,Mood,Tags"); // CSV header
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToCsvFormat());
                }
            }
        }

        // Load journal from a CSV file
        public void LoadFromCsv(string filename)
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                reader.ReadLine(); // Skip the header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = ParseCsvLine(line);
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    string mood = parts[3];
                    List<string> tags = new List<string>(parts[4].Split(','));
                    _entries.Add(new Entry(date, prompt, response, mood, tags));
                }
            }
        }

        // Helper method to handle CSV parsing
        private string[] ParseCsvLine(string line)
        {
            List<string> result = new List<string>();
            bool insideQuote = false;
            string currentField = "";

            foreach (char c in line)
            {
                if (c == '"')
                {
                    insideQuote = !insideQuote; // Toggle quote state
                }
                else if (c == ',' && !insideQuote)
                {
                    result.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += c;
                }
            }

            result.Add(currentField); // Add the last field
            return result.ToArray();
        }

        // Save journal to JSON
        public void SaveToJson(string filename)
        {
            string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        // Load journal from JSON
        public void LoadFromJson(string filename)
        {
            string json = File.ReadAllText(filename);
            _entries = JsonConvert.DeserializeObject<List<Entry>>(json);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to CSV");
                Console.WriteLine("4. Load journal from CSV");
                Console.WriteLine("5. Save journal to JSON");
                Console.WriteLine("6. Load journal from JSON");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal);
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        SaveToCsv(journal);
                        break;
                    case "4":
                        LoadFromCsv(journal);
                        break;
                    case "5":
                        SaveToJson(journal);
                        break;
                    case "6":
                        LoadFromJson(journal);
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void WriteNewEntry(Journal journal)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string[] prompts = new[] { "What made you happy today?", 
            "What did you learn today?", "Who inspired you today?", 
            "What are you grateful for?", 
            "What challenged you today?", 
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?" };
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Length)];

            Console.WriteLine(prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Console.Write("Your mood: ");
            string mood = Console.ReadLine();

            Console.Write("Tags (comma separated): ");
            List<string> tags = new List<string>(Console.ReadLine().Split(','));

            Entry entry = new Entry(date, prompt, response, mood, tags);
            journal.AddEntry(entry);
        }

        static void SaveToCsv(Journal journal)
        {
            Console.Write("Enter the filename to save as CSV: ");
            string filename = Console.ReadLine();
            journal.SaveToCsv(filename);
            Console.WriteLine("Journal saved to CSV.");
        }

        static void LoadFromCsv(Journal journal)
        {
            Console.Write("Enter the filename to load from CSV: ");
            string filename = Console.ReadLine();
            journal.LoadFromCsv(filename);
            Console.WriteLine("Journal loaded from CSV.");
        }

        static void SaveToJson(Journal journal)
        {
            Console.Write("Enter the filename to save as JSON: ");
            string filename = Console.ReadLine();
            journal.SaveToJson(filename);
            Console.WriteLine("Journal saved to JSON.");
        }

        static void LoadFromJson(Journal journal)
        {
            Console.Write("Enter the filename to load from JSON: ");
            string filename = Console.ReadLine();
            journal.LoadFromJson(filename);
            Console.WriteLine("Journal loaded from JSON.");
        }
    }
}