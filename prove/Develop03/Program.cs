using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWords();
            if (scripture.AllWordsHidden())
                break;
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference);
        foreach (var word in words)
        {
            Console.Write(word + " ");
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); // Hide 1 to 3 words at a time
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public bool IsHidden => hidden;

    public override string ToString()
    {
        return hidden ? "_" : text;
    }
}
