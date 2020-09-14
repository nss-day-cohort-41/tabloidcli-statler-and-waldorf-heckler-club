# Tabloid CLI

## The Story

"Hey, let's start a company," you say.

"Ok. Let's do it. What should our company do?"

"Well..." you begin, "what do people need? What will they find valuable?"

"I know I always need help keeping things organized."

"Yeah," you say, pondering the idea. "Organization. That's good. What should we organize? ...I know: Blog Posts!"

"Great idea!"

"We'll make millions!"

---

## The Tabloid Proof of Concept

Our new business will create a software product to allow people save info about favorite blog posts, authors and blogs.

In order to test the new business idea, we'll create a [Proof of Concept (POC)](https://en.wikipedia.org/wiki/Proof_of_concept#Software_development). This POC will be a simplified implementation of the idea that will be used to test the business idea to ensure that customers would find it valuable, and also to allow the team to get a handle on the concept. After we complete the POC we will use it to evaluate our business idea and determine if we need to pivot (change direction) toward another idea.

For our POC, we will build a command line app in C# and save our data in SQL Server.


## Instructions for use

1. CD into the main folder of the application and type DOTNET run.
2. The main menu will be shown which shows Journal, Blog, Author, Post, and Tag Management. Also there is the ability to search content by tags and to change the color scheme of the application.
3. Going into each of the managers allows for viewing their respective content in a list, add new content, edit old content, and deleting content one no longer wants.
4. Some allow for the user to go into further detail.
5. The user can select details which will then list all available content and the user chooses which they wish to view.
6. Once selected the user will be shown a menu to view all details of the content, add tags for searching, delete tags.
7. On the post details manager you can also access the notes manager which allows you to add and delete notes associated with the selected blog post.
8. Once done just hit 0 to go back until you get back to the main menu and type 0 one more time to exit the program.


## Goals of the Project

To create a Proof of Concept console application that allows users an easy to use way to manage blog posts that they have come accross and enjoyed. Through use of easy to read menus and prompts, the application should be easy to use and allow for minimal user error. Deleted content should continue to be stored but hidden from user access once the delete function has been excecuted by the user. This allows for the other sections of the app the data was tied to to function as intended.

