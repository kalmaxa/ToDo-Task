using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class DatabaseOperations
    {
        //private static SQLiteConnection _connection = new SQLiteConnection("Data Source=database.db; Version=3;New=True;Compress=True;");
        private static string _connectionString = "Data Source=database.db; Version=3;New=True;Compress=True;";
        public DatabaseOperations()
        {
            try
            {
                using (var db = new SQLiteConnection(_connectionString))
                {

                    db.Open();
                    var command = db.CreateCommand();
                    command.CommandText = @"CREATE TABLE [task]([id]INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR, [importance] VARCHAR, [status] VARCHAR, [created_at] DATETIME, [updated_at] DATETIME);";
                    command.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        public void InsertData(string name, string importance)
        {
            using (var db = new SQLiteConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    var command = db.CreateCommand();
                    command.CommandText = $"INSERT INTO [task]([name], [importance], [updated_at], [created_at]) VALUES ('{name}', '{importance}', datetime('now', 'localtime'), datetime('now', 'localtime'))";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void UpdateData(int id, string name, string importance, int status)
        {
            using (var db = new SQLiteConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    var command = db.CreateCommand();
                    command.CommandText = $"UPDATE [task] SET [name]='{name}', [importance]='{importance}', [status]={status}, [updated_at]=datetime('now', 'localtime') WHERE [id]={id}";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void UpdateData(int id, string name, string importance)
        {
            using (var db = new SQLiteConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    var command = db.CreateCommand();
                    command.CommandText = $"UPDATE [task] SET [name]='{name}', [importance]='{importance}', [updated_at]=datetime('now', 'localtime') WHERE [id]={id}";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void DeleteData(int id)
        {
            using (var db = new SQLiteConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    var command = db.CreateCommand();
                    //command.CommandText = $"DELETE FROM [task] WHERE [id]={id}";
                    command.CommandText = $"UPDATE [task] SET [status] = 'Deleted' WHERE [id]={id}";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        private Importance parseImportance(string importance)
        {
            switch (importance)
            {
                case "High":
                    return Importance.High;
                case "Medium":
                    return Importance.Medium;
                case "Low":
                    return Importance.Low;
            }
            return Importance.Low;
        }
        private Status parseStatus(string status)
        {
            switch (status)
            {
                case "Done":
                    return Status.Done;
                case "ToDo":
                    return Status.ToDo;
                case "Deleted":
                    return Status.Deleted;
            }
            return Status.ToDo;
        }
        public List<Task> GetTasks(int? status = null)
        {
            /*   statuses:
             * =============
             * deleted: -1
             * pending: 0
             * done: 1
             */
            List<Task> tasks = new List<Task>();
            using (SQLiteConnection db = new SQLiteConnection(_connectionString))
            {
                db.Open();
                var command = db.CreateCommand();
                if (status != null)
                    command.CommandText = $@"SELECT [id], [name], [importance], [status], [updated_at], [created_at] FROM [task] WHERE [status] ='{status}'";
                else
                    command.CommandText = $@"SELECT [id], [name], [importance], [status], [updated_at], [created_at] FROM [task];";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["id"]);
                    var name = reader["name"].ToString();
                    var importance = reader["importance"].ToString();
                    var createdAt = Convert.ToDateTime(reader["created_at"]);
                    var updatedAt = Convert.ToDateTime(reader["updated_at"]);
                    var st = reader["status"].ToString();
                    //var st = Convert.ToInt32(reader["status"]);
                    tasks.Add(new Task { Id = id, Name = name, Importance = parseImportance(importance), Status = parseStatus(st), CreatedAt = createdAt, UpdatedAt = updatedAt });
                }
            }
            return tasks;
            //}
            //else if (status == "ToDo")
            //{
            //    List<Task> tasks = new List<Task>();
            //    using (SQLiteConnection db = new SQLiteConnection(_connectionString))
            //    {
            //        db.Open();
            //        var command = db.CreateCommand();
            //        command.CommandText = $@"SELECT [id], [name], [status], [updated_at], [created_at] FROM [task] WHERE [status] ='{status}'";
            //        var reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            var id = Convert.ToInt32(reader["id"]);
            //            var name = reader["name"].ToString();
            //            var createdAt = Convert.ToDateTime(reader["created_at"]);
            //            var updatedAt = Convert.ToDateTime(reader["updated_at"]);
            //            var st = reader["status"].ToString();
            //            //var st = Convert.ToInt32(reader["status"]);
            //            tasks.Add(new Task { Id = id, Name = name, Status = status, CreatedAt = createdAt, UpdatedAt = updatedAt });
            //        }
            //    }
            //    return tasks;
            //}
            //else //if (status == "All")
            //{
            //    List<Task> tasks = new List<Task>();
            //    using (SQLiteConnection db = new SQLiteConnection(_connectionString))
            //    {
            //        db.Open();
            //        var command = db.CreateCommand();
            //        command.CommandText = $@"SELECT [id], [name], [status], [updated_at], [created_at] FROM [task] WHERE [status] ='{status}'";
            //        var reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            var id = Convert.ToInt32(reader["id"]);
            //            var name = reader["name"].ToString();
            //            var createdAt = Convert.ToDateTime(reader["created_at"]);
            //            var updatedAt = Convert.ToDateTime(reader["updated_at"]);
            //            var st = reader["status"].ToString();
            //            //var st = Convert.ToInt32(reader["status"]);
            //            tasks.Add(new Task { Id = id, Name = name, Status = status, CreatedAt = createdAt, UpdatedAt = updatedAt });
            //        }
            //    }
            //    return tasks;
            //}
        }
        //public List<Task> GetTasksDone(int status = 1)
        //{
        //    List<Task> tasks = new List<Task>();
        //    using (SQLiteConnection db = new SQLiteConnection(_connectionString))
        //    {
        //        db.Open();
        //        var command = db.CreateCommand();
        //        command.CommandText = $@"SELECT [id], [name], [status], [updated_at], [created_at] FROM [task] WHERE [status] ={status}";
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var id = Convert.ToInt32(reader["id"]);
        //            var name = reader["name"].ToString();
        //            var createdAt = Convert.ToDateTime(reader["created_at"]);
        //            var updatedAt = Convert.ToDateTime(reader["updated_at"]);
        //            var st = Convert.ToInt32(reader["status"]);

        //            tasks.Add(new Task { Id = id, Name = name, Status = status, CreatedAt = createdAt, UpdatedAt = updatedAt });
        //        }
        //    }
        //    return tasks;
        //}
    }
}
