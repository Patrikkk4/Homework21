using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersApi.Model
{
    public interface IPers
    {
        /// <summary>
        /// ID персонажа в БД
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Путь к изображению
        /// </summary>
        string Image { get; set; }

        /// <summary>
        /// Имя персонажа
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Описание персонажа
        /// </summary>
        string Bio { get; set; }
    }
}
