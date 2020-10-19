using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Homework20.Context;
using Homework20.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Homework20.Controllers
{
    public class PersController : Controller
    {
        IWebHostEnvironment webHost;
        private readonly DataContext dcontext;

        /// <summary>
        /// Конструктор получения контекста данных
        /// </summary>
        /// <param name="webHost"></param>
        /// <param name="dataContext"></param>
        public PersController(IWebHostEnvironment webHost, DataContext dataContext)
        {
            this.webHost = webHost;
            dcontext = dataContext;
        }

        /// <summary>
        /// Метод отображения страницы персонажей
        /// </summary>
        /// <returns></returns>
        public IActionResult Pers()
        {
            return View(dcontext);
        }

        /// <summary>
        /// Метод добавления персонажей
        /// </summary>
        /// <param name="uploadImage"></param>
        /// <param name="name"></param>
        /// <param name="bio"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPers(IFormFile uploadImage, string name, string bio)
        {
            // Путь сохранения загруженного изображения
            string img = $@"/Images/{uploadImage.FileName}";

            // Вызов метода загрузки изображения
            UploadFile(img, uploadImage);

            // Добавление нового персонажа в объект БД
            dcontext.Add(new Character()
            {
                Image = img,
                Name = name,
                Bio = bio
            });

            // Сохранение данных в БД
            dcontext.SaveChanges();

            // Перенос на страницу персонажей
            return Redirect("~/Pers/Pers");
        }

        /// <summary>
        /// Метод загрузки изображения на сервер
        /// </summary>
        /// <param name="path"></param>
        /// <param name="uploadImage"></param>
        private async void UploadFile(string path, IFormFile uploadImage)
        {
            // Поток загрузки изображения
            using (var FileStream = new FileStream($@"{webHost.WebRootPath}/{path}", FileMode.Create))
            {
                await uploadImage.CopyToAsync(FileStream);
            }
        }
    }
}
