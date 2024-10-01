// From more research with W3Schools and C# learning apps I added Additional Improved CSV handling, Additional Entry information for mood and tags for better categorization
using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleJournalApp
{
    // Entry class to represent a journal entry
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Mood { get; set; }
        public List<string> Tags { get; set; }

        public Entry(string date, string prompt, string response, string mood, List<string> tags)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
            Mood = mood;
            Tags = tags;
        }

        // Display entry in a readable format
        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\nTags: {string.Join(", ", Tags)}";
        }

        // Format entry to be saved as a CSV line
        public string ToCsv()
        {
            string escapedResponse = Response.Replace("\"", "\"\""); // Escape double quotes
            string escapedPrompt = Prompt.Replace("\"", "\"\"");
            string tagsString = string.Join(";", Tags); // Use ";" to separate tags
            return $"\"{Date}\",\"{escapedPrompt}\",\"{escapedResponse}\",\"{Mood}\",\"{tagsString}\"";
        }

        // Create an entry from a CSV line
        public static Entry FromCsv(string csvLine)
        {
            // Split the line using commas but consider text within quotes
            string[] parts = csvLine.Split(new[] { "\",\"" }, StringSplitOptions.None);
            string date = parts[0].Trim('"');
            string prompt = parts[1];
            string response = parts[2];
            string mood = parts[3].Trim('"');
            List<string> tags = new List<string>(parts[4].Trim('"').Split(';'));

            return new Entry(date, prompt, response, mood, tags);
        }
    }

    // Journal class to manage multiple entries
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Add a new entry to the journal
        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        // Display all entries in the journal
        public void DisplayJournal()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(new string('-', 50));
            }
        }

        // Save the journal to a CSV file
        public void SaveToCsv(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Prompt,Response,Mood,Tags");
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToCsv());
                }
            }
        }

        // Load the journal from a CSV file
        public void LoadFromCsv(string filename)
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                reader.ReadLine(); // Skip the header
                while ((line = reader.ReadLine()) != null)
                {
                    _entries.Add(Entry.FromCsv(line));
                }
            }
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
                Console.WriteLine("5. Exit");
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
            "What did you learn today?", 
            "Who inspired you today?", 
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
    }
}