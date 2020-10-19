using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework20.Models
{
    public class Character
    {
        /// <summary>
        /// ID персонажа в БД
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Путь к изображению
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Имя персонажа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание персонажа
        /// </summary>
        public string Bio { get; set; }
    }
}
