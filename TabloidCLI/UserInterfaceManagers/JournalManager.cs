﻿using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    class JournalManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalRepository _journalRepository;
        private string _connectionString;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.Clear();
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" 1) List Journal Entries");
            Console.WriteLine(" 2) Add New Journal Entry");
            Console.WriteLine(" 3) Edit Existing Journal Entry");
            Console.WriteLine(" 4) Remove Journal Entry");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    Edit();
                    return this;
                case "4":
                    Remove();
                    return this;
                case "0":
                    Console.Clear();
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            List<Journal> allJournalEntries = _journalRepository.GetAll();
            Console.Clear();
            foreach (Journal entry in allJournalEntries)
            {
                string tab = "\t\t\t";
                if (entry.Title.Length > 16 && entry.Title.Length < 24)
                {
                    tab = "\t\t";
                }
                else if (entry.Title.Length > 24)
                {
                    tab = "\t";
                }
                    Console.WriteLine($"{entry.Title}{tab}{entry.CreateDateTime}");
                Console.WriteLine();
                Console.WriteLine(entry.Content); 
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void Add()
        {
            Console.WriteLine("New Journal Entry");
            Journal journal = new Journal();

            Console.Write("Title: ");
            journal.Title = Console.ReadLine();

            Console.Write("Content: ");
            journal.Content = Console.ReadLine();

            journal.CreateDateTime = DateTime.Now;

            _journalRepository.Insert(journal);
        }

        private void Edit()
        {
            Journal journalToEdit = Choose("Which journal would you like to edit?");
            if (journalToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("Title (blank to leave unchanged: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                journalToEdit.Title = title;
            }
            Console.Write("Enter new content (blank to leave unchanged: ");
            string content = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(content))
            {
                journalToEdit.Content = content;
            }
            

            _journalRepository.Update(journalToEdit);
        }

        private void Remove()
        {
            Journal journalToDelete = Choose("Which journal would you like to remove?");
            if (journalToDelete != null)
            {
                _journalRepository.Delete(journalToDelete.Id);
            }
        }

        private Journal Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a journal entry:";
            }

            Console.WriteLine(prompt);

            List<Journal> allJournalEntries = _journalRepository.GetAll();

            for (int i = 0; i < allJournalEntries.Count; i++)
            {
                Journal entry = allJournalEntries[i];
                Console.WriteLine($" {i + 1}) {entry.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return allJournalEntries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }
    }
}
