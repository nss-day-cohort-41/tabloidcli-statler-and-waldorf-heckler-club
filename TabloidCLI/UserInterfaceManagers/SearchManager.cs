using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class SearchManager : IUserInterfaceManager
    {
        private TagRepository _tagRepository;
        private IUserInterfaceManager _parentUI;
        private SearchRepository _searchRepository;

        public SearchManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
            _searchRepository = new SearchRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Search Menu");
            Console.WriteLine(" 1) Search Blogs");
            Console.WriteLine(" 2) Search Authors");
            Console.WriteLine(" 3) Search Posts");
            Console.WriteLine(" 4) Search All");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchBlogs();
                    return this;
                case "2":
                    SearchAuthors();
                    return this;
                case "3":
                    SearchPosts();
                    return this;
                case "4":
                    SearchAll();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void SearchBlogs()
        {
            string tagName;
            Console.Clear();
            Console.WriteLine("(Hit enter to see a list of know tags)");

            do
            {
                Console.WriteLine("Search Blogs by ");
                Console.Write("Tag> ");
                tagName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tagName))
                {
                    List<Tag> tags = _tagRepository.GetAll();
                    foreach (Tag tag in tags)
                    {
                        Console.WriteLine(tag);
                    }
                }
            } while (tagName.Length < 1);

            SearchResults<Blog> results = _searchRepository.SearchBlogs(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchAuthors()
        {
            string tagName;
            Console.Clear();
            Console.WriteLine("(Hit enter to see a list of know tags)");

            do {
                Console.WriteLine("Search Authors by ");
                Console.Write("Tag> ");
                tagName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tagName))
                {
                    List<Tag> tags = _tagRepository.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("---------");
                    Console.WriteLine("Known tags:");
                    foreach (Tag tag in tags)
                    {
                        Console.WriteLine(" " + tag);
                    }
                    Console.WriteLine("---------");
                    Console.WriteLine();
                } 
            } while (tagName.Length < 1);

                SearchResults < Author > results = _searchRepository.SearchAuthors(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchPosts()
        {
            string tagName;
            Console.Clear();
            Console.WriteLine("(Hit enter to see a list of know tags)");

            do
            {
                Console.WriteLine("Search Posts by ");
                Console.Write("Tag> ");
                tagName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tagName))
                {
                    List<Tag> tags = _tagRepository.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("---------");
                    Console.WriteLine("Known tags:");
                    foreach (Tag tag in tags)
                    {
                        Console.WriteLine(" " + tag);
                    }
                    Console.WriteLine("---------");
                    Console.WriteLine();
                }
            } while (tagName.Length < 1);

            SearchResults<Post> results = _searchRepository.SearchPosts(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchAll()
        {
            string tagName;
            Console.Clear();
            Console.WriteLine("(Hit enter to see a list of know tags)");

            do
            {
                Console.WriteLine("Search Blogs, Authors, and Posts by ");
                Console.Write("Tag> ");
                tagName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tagName))
                {
                    List<Tag> tags = _tagRepository.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("---------");
                    Console.WriteLine("Known tags:");
                    foreach (Tag tag in tags)
                    {
                        Console.WriteLine(" " + tag);
                    }
                    Console.WriteLine("---------");
                    Console.WriteLine();
                }
            } while (tagName.Length < 1);

            Console.WriteLine();
            SearchResults<Blog> blogResults = _searchRepository.SearchBlogs(tagName);

            if (blogResults.NoResultsFound)
            {
                Console.WriteLine($"No results for '{tagName}' found in blogs");
            }
            else
            {
                Console.WriteLine("Search results found in blogs:");
                blogResults.Display();
            }

                Console.WriteLine();

            SearchResults<Author> authorResults = _searchRepository.SearchAuthors(tagName);

            if (authorResults.NoResultsFound)
            {
                Console.WriteLine($"No results for '{tagName}' found in authors");
            }
            else
            {
                authorResults.Display();
            }

            Console.WriteLine();
            SearchResults<Post> postResults = _searchRepository.SearchPosts(tagName);

            if (postResults.NoResultsFound)
            {
                Console.WriteLine($"No results for '{tagName}' found in posts");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Search results found in posts:");
                postResults.Display();
            }
        }

    }
}