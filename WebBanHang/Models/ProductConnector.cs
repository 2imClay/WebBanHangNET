using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebBanHang.Models
{
    public class ProductConnector
    {
        string connectionString = "Server=localhost;Database=shop_quan_ao_db;Uid=root;Pwd=;";

        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM products";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Price = reader.GetDecimal("Price"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                    Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? null : reader.GetString("Color"),
                                    Quantity = reader.GetInt32("Quantity"),
                                    Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? null : reader.GetString("Size"),
                                    Category = reader.GetString("Category"),
                                    Sex = reader.IsDBNull(reader.GetOrdinal("Sex")) ? null : reader.GetString("Sex"),
                                    imageURL = reader.IsDBNull(reader.GetOrdinal("imageURL")) ? null : reader.GetString("imageURL")
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                }
            }

            return products;
        }

        // Thêm sản phẩm mới
        public bool Insert(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO products (Name, Price, Description, Color, Quantity, Size, Category, Sex, imageURL)
                                     VALUES (@Name, @Price, @Description, @Color, @Quantity, @Size, @Category, @Sex, @imageURL)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Color", product.Color ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@Size", product.Size ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Category", product.Category);
                        command.Parameters.AddWithValue("@Sex", product.Sex ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@imageURL", product.imageURL ?? (object)DBNull.Value);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                    return false;
                }
            }
        }

        // Cập nhật sản phẩm
        public bool Update(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"UPDATE products 
                                     SET Name = @Name, Price = @Price, Description = @Description, Color = @Color, 
                                         Quantity = @Quantity, Size = @Size, Category = @Category, Sex = @Sex, imageURL = @imageURL
                                     WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", product.Id);
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Color", product.Color ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@Size", product.Size ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Category", product.Category);
                        command.Parameters.AddWithValue("@Sex", product.Sex ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@imageURL", product.imageURL ?? (object)DBNull.Value);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                    return false;
                }
            }
        }

        // Xóa sản phẩm
        public bool Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM products WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa sản phẩm: {ex.Message}");
                    return false;
                }
            }
        }

        public Product GetById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM products WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Price = reader.GetDecimal("Price"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                    Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? null : reader.GetString("Color"),
                                    Quantity = reader.GetInt32("Quantity"),
                                    Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? null : reader.GetString("Size"),
                                    Category = reader.GetString("Category"),
                                    Sex = reader.IsDBNull(reader.GetOrdinal("Sex")) ? null : reader.GetString("Sex"),
                                    imageURL = reader.IsDBNull(reader.GetOrdinal("imageURL")) ? null : reader.GetString("imageURL")
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy sản phẩm theo ID: {ex.Message}");
                }
            }

            return null; // Trả về null nếu không tìm thấy sản phẩm
        }

    }
}
