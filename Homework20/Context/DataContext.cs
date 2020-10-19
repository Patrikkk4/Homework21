using Homework20.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Homework20.Context
{
    public class DataContext : DbContext
    {
        // Свойство Dbset таблицы персонажей
        public DbSet<Character> Characters { get; set; }

        public DataContext()
        {
            try
            {
                if (Database.EnsureCreated())
                {
                    List<Character> tempList = JsonConvert.DeserializeObject<List<Character>>(File.ReadAllText("pers.json"));
                    Characters.AddRange(tempList);
                    this.SaveChanges();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Конфигурационный метод подключения к БД
        /// </summary>
        /// <param name="optBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(
               @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=PersDB;
                  Trusted_Connection=True;");
        }
    }
}
