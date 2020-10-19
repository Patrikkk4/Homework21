using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersApi.Model
{
    public class Character : IPers
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
