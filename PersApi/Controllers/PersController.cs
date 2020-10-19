using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersApi.Context;
using PersApi.Model;

namespace PersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersController : Controller
    {
        IWebHostEnvironment webHost;
        private DataContext context;

        public PersController(DataContext dataContext)
        {
            context = dataContext;
        }

        // GET: PersController
        [HttpGet]
        public IEnumerable<IPers> Get()
        {
            return context.Characters;
        }

        // GET: PErsController/Details/5
        public IEnumerable<Character> Details(int id)
        {
            return context.Characters.Where(c => c.Id == id);
        }

        // GET: PErsController/Create
        public IEnumerable<Character> AddPers(IFormFile uploadImage, string name, string bio)
        {
            // Путь сохранения загруженного изображения
            string img = $@"/Images/{uploadImage.FileName}";

            // Вызов метода загрузки изображения
            UploadFile(img, uploadImage);

            // Добавление нового персонажа в объект БД
            context.Add(new Character()
            {
                Image = img,
                Name = name,
                Bio = bio
            });

            // Сохранение данных в БД
            context.SaveChanges();

            // Перенос на страницу персонажей
            return context.Characters;
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

        #region _
        //// POST: PErsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

        #region _
        //// GET: PErsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}
        #endregion

        #region _
        //// POST: PErsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

        // GET: PErsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PErsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
