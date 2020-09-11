using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    public class NoteRepository : DatabaseConnector
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"SELECT n.Id,
                                               n.Title,
                                               n.Content,
                                               n.CreateDateTime,
                                               n.PostId
                                               
                                          FROM Note n
                                           JOIN Post p on p.Id = n.PostId
                                            WHERE p.id = {id}";

                    List<Note> notes = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                          

                        };
                        notes.Add(note);
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

      



        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content, CreateDateTime, PostId )
                                                     VALUES (@title, @content, @createDateTime, @postId)";
                    cmd.Parameters.AddWithValue("@title", note.Title);
                    cmd.Parameters.AddWithValue("@content", note.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", note.CreateDateTime);
                    cmd.Parameters.AddWithValue("@postId", note.PostId);
           

                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Note 
                                         WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@Id", id);


                    cmd.ExecuteNonQuery();
                }
            }
        }
      


       
    }
}
