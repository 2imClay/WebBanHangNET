

using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace WebBanHang.Models
{
    public class UserConnector
    {
        string connectionString = "Server=localhost;Database=shop_quan_ao_db;Uid=root;Pwd=;";

        // Get all users
        public List<User> FindAll()
        {
            var users = new List<User>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM users";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new User
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Email = reader.GetString("Email"),
                                    Password = reader.GetString("Password"),
                                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                    RoleId = reader.GetInt32("RoleId")
                                };

                                // For Role, you could use another query to fetch the role name or handle it based on RoleId
                                // user.Role = GetRoleById(user.RoleId);  // Uncomment if you have a method to retrieve Role by Id

                                users.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to the database: {ex.Message}");
                }
            }

            return users;
        }

        // Insert a new user
        public bool Save(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO users (Name, Email, Password, Phone, RoleId)
                                     VALUES (@Name, @Email, @Password, @Phone, @RoleId)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Password", user.Password); // Store hashed password
                        command.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@RoleId", user.RoleId);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting user: {ex.Message}");
                    return false;
                }
            }
        }

        // Update a user
        public bool Update(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"UPDATE users 
                                     SET Name = @Name, Email = @Email, Password = @Password, 
                                         Phone = @Phone, RoleId = @RoleId
                                     WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Password", user.Password); // Store hashed password
                        command.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@RoleId", user.RoleId);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating user: {ex.Message}");
                    return false;
                }
            }
        }


        // Delete a user
        public bool Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM users WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting user: {ex.Message}");
                    return false;
                }
            }
        }

        // Get user by ID
        public User FindById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM users WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new User
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Email = reader.GetString("Email"),
                                    Password = reader.GetString("Password"),
                                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                    RoleId = reader.GetInt32("RoleId")
                                };

                                // For Role, you could use another query to fetch the role name or handle it based on RoleId
                                // user.Role = GetRoleById(user.RoleId);  // Uncomment if you have a method to retrieve Role by Id

                                return user;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching user by ID: {ex.Message}");
                }
            }

            return null;
        }

        // Get user by email
        public User FindByEmail(string email)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM users WHERE Email = @Email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new User
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Email = reader.GetString("Email"),
                                    Password = reader.GetString("Password"),
                                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                    RoleId = reader.GetInt32("RoleId")
                                };

                                return user;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching user by email: {ex.Message}");
                }
            }

            return null;
        }

    }

}