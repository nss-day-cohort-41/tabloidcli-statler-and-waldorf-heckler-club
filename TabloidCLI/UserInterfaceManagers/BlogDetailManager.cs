using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    class BlogDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private BlogRepository _blogRepository;
        private PostRepository _postRepository;
        private TagRepository _tagRepository;
        private int _blogId;

        public BlogDetailManager(IUserInterfaceManager parentUI, string connectionString, int blogId)
        {
            _parentUI = parentUI;
            _blogRepository = new BlogRepository(connectionString);
            _postRepository = new PostRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _blogId = blogId;
        }

        public IUserInterfaceManager Execute()
        {
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"{blog.Title} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) Add Tag (coming soon)");
            Console.WriteLine(" 3) Remove Tag (coming a little later)");
            Console.WriteLine(" 4) View Posts (coming a little later still)");
            Console.WriteLine(" 0) Go Back");

            Console.WriteLine("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "2":
                    Console.WriteLine("Coming soon!");
                    return null;
                case "3":
                    Console.WriteLine("Coming soon!");
                    return null;
                case "4":
                    Console.WriteLine("Coming soon!");
                    return null;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"Title: {blog.Title}");
            Console.WriteLine($"Url: {blog.Url}");
            /*Console.WriteLine("Tags:");
            foreach (Tag tag in blog.Tags)
            {
                Console.WriteLine(" " + tag);
            }
            Console.WriteLine();*/
        }
    }
}
