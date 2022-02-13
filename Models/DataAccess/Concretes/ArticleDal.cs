using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.DataAccess.Concretes
{
    public class ArticleDal :IArticleDal
    {
        DbConnection connection = new DbConnection();
        public Article GetArticleNameById(int id) //article id
        {
            connection.ConnectDb();
            string command = "Select * From articles where article_id=@id";
            var cmd = new NpgsqlCommand(command, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
            cmd.Parameters["@id"].Value = id;
            var reader = cmd.ExecuteReader();
            Article article;
            while (reader.Read())
            {
                article = new Article(
                     
                    reader.GetInt32(0),reader.GetInt32(1),reader.GetString(2),reader.GetString(3),
                    reader.GetDateTime(4),reader.GetDateTime(5),reader.GetString(6)

                    );
                connection.CloseConnection();
                return article; 
                
            }
            return null;
        }

        public List<Article> GetAllArticles()
        {
            connection.ConnectDb();
            string command = "Select * From articles where article_id=@id";
            var cmd = new NpgsqlCommand(command, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
            cmd.Parameters["@id"].Value = SessionSingleton.GetInstance()._session.GetInt32("userId");
            var reader = cmd.ExecuteReader();
            List<Article> articles =new List<Article>();
            Article a;
            while (reader.Read())
            {
                articles.Add(
                 a = new Article(
                    int.Parse(reader["article_id"].ToString()),
                    int.Parse(reader["user_id"].ToString()),
                    reader["article_name"].ToString(),
                    reader["article_author"].ToString(),
                    DateTime.Parse(reader["published_date"].ToString()),
                    DateTime.Parse(reader["updated_date"].ToString()),
                    reader["article_content"].ToString()
                    ));   
                }             
                connection.CloseConnection();
                return articles;
            }

        public void CreateArticle(Article article)
        {
            connection.ConnectDb();
            string query = "insert into articles (user_id,article_name,article_author,published_date,updated_date,article_content) " +
                "values(@p2,@p3,@p4,@p5,@p6,@p7)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.connection);
            cmd.Parameters.AddWithValue("@p2",SessionSingleton.GetInstance()._session.GetInt32("userId"));
            cmd.Parameters.AddWithValue("@p3", article.ArticleName);
            cmd.Parameters.AddWithValue("@p4", SessionSingleton.GetInstance()._session.GetString("author"));
            cmd.Parameters.AddWithValue("@p5", DateTime.Now);
            cmd.Parameters.AddWithValue("@p6", DateTime.Now);
            cmd.Parameters.AddWithValue("@p7",article.ArticleContent);
            cmd.ExecuteNonQuery();
            connection.CloseConnection();
        }

        public Article FindArticleByName(string name)
        {
            connection.ConnectDb();
            string command = "Select * From articles where article_name=@name";
            var cmd = new NpgsqlCommand(command, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@name", NpgsqlDbType.Text));
            cmd.Parameters["@name"].Value = name;
            var reader = cmd.ExecuteReader();
            Article article;
            while (reader.Read())
            {
                article = new Article(

                    reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3),
                    reader.GetDateTime(4), reader.GetDateTime(5), reader.GetString(6)

                    );
                connection.CloseConnection();
                return article;

            }
            return null;
        }

        public void DeleteArticleById(int id)
        {
            connection.ConnectDb();
            string query = "delete from articles where article_id=@id";
            var cmd = new NpgsqlCommand(query,connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
            cmd.Parameters["@id"].Value = id;
            cmd.ExecuteNonQuery();
            connection.CloseConnection();
        }

        public void UpdateArticle(Article article)
        {
            connection.ConnectDb();
            string query = "update articles set article_name=@p1, updated_date=@p2, article_content=@p3  where article_id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
            cmd.Parameters["@id"].Value = article.ArticleId;
            cmd.Parameters.AddWithValue("@p1",article.ArticleName);
            cmd.Parameters.AddWithValue("@p2", DateTime.Now);
            cmd.Parameters.AddWithValue("@p3", article.ArticleContent);
            cmd.ExecuteNonQuery();
            connection.CloseConnection();   
        }

        public List<Article> GetAllArticlesByUser()
        {
            connection.ConnectDb();
            int id = (int)SessionSingleton.GetInstance()._session.GetInt32("userId");
            string command = "Select * From articles where user_id=@user_id ";
            var cmd = new NpgsqlCommand(command, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@user_id", NpgsqlDbType.Integer));
            cmd.Parameters["@user_id"].Value =id;
            var reader = cmd.ExecuteReader();
            List<Article> articles = new List<Article>();
            Article a;
            while (reader.Read())
            {
                articles.Add(
                 a = new Article(
                    int.Parse(reader["article_id"].ToString()),
                    int.Parse(reader["user_id"].ToString()),
                    reader["article_name"].ToString(),
                    reader["article_author"].ToString(),
                    DateTime.Parse(reader["published_date"].ToString()),
                    DateTime.Parse(reader["updated_date"].ToString()),
                    reader["article_content"].ToString()
                    ));
            }
            connection.CloseConnection();
            return articles;
        }
    }
    }
