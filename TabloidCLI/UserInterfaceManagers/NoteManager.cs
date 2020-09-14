using System;
using System.Collections.Generic;
using System.Xml.Schema;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class NoteManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private string _connectionString;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private NoteRepository _noteRepository;
        private int _postId;

        public NoteManager(IUserInterfaceManager parentUI, string connectionString, int postid)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _connectionString = connectionString;
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
            _noteRepository = new NoteRepository(connectionString);
            _postId = postid;
        }

        public IUserInterfaceManager Execute()
        {
         
            Console.WriteLine("Notes Menu");
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Note");
            Console.WriteLine(" 3) Remove Note");
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
            List<Note> notes = _noteRepository.GetAll(_postId);
            Console.WriteLine("");
            foreach (Note note in notes)
            {
                Console.WriteLine($"Title: {note.Title}");
                Console.WriteLine($"Content: {note.Content} ");
                Console.WriteLine($"Created at: {note.CreateDateTime}");
                Console.WriteLine("");
            }
        }

        private Note Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Note:";
            }

            Console.WriteLine(prompt);

            List<Note> notes = _noteRepository.GetAll(_postId);

            for (int i = 0; i < notes.Count; i++)
            {
                Note note = notes[i];
                Console.WriteLine($" {i + 1}) {note.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return notes[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Note");
            Note note = new Note();

            Console.WriteLine("Title: ");
            Console.Write("> ");
            note.Title = Console.ReadLine();

            Console.WriteLine("Content: ");
            Console.Write("> ");
            note.Content = Console.ReadLine();


            note.CreateDateTime = DateTime.Now;




            note.PostId = _postId;

            _noteRepository.Insert(note);


        }

        private void Remove()
        {


            Note noteToDelete = Choose("Which note would you like to remove?");
            if (noteToDelete != null)
            {
                _noteRepository.Delete(noteToDelete.Id);
            }
        }
    }
}