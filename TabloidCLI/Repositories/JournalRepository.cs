﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
        public class JournalRepository : DatabaseConnector, IRepository<Journal>
        {
            public JournalRepository(string connectionString) : base(connectionString) { }

            public List<Journal> GetAll()
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                    cmd.CommandText = @"SELECT id, 
                                                Title, 
                                                Content, 
                                                CreateDateTime 
                                            FROM Journal";

                    List<Journal> allJournals = new List<Journal>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Journal journal = new Journal()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                        };
                        allJournals.Add(journal);
                    }
                    reader.Close();
                    return allJournals;
                    }
                }
            }

        public void Insert(Journal journal)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDateTime )
                                                     VALUES (@title, @content, @createdate)";
                    cmd.Parameters.AddWithValue("@title", journal.Title);
                    cmd.Parameters.AddWithValue("@content", journal.Content);
                    cmd.Parameters.AddWithValue("@createdate", journal.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Journal journal)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Journal
                                            SET Title = @title,
                                                Content = @content,
                                                CreateDateTime = @createdate
                                            WHERE id = @id";

                    cmd.Parameters.AddWithValue("@title", journal.Title);
                    cmd.Parameters.AddWithValue("@content", journal.Content);
                    cmd.Parameters.AddWithValue("@createdate", journal.CreateDateTime);
                    cmd.Parameters.AddWithValue("@id", journal.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Journal WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Journal Get(int id)
        {
            return null;
        }
    }
}
