using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TEST.Models;

namespace TEST.Services
{
    public class DataService<T> where T : class
    {
        /// <summary>
        /// Получает все записи указанного типа из базы данных
        /// </summary>
        /// <returns>Список всех записей</returns>
        public List<T> GetAll()
        {
            try
            {
                // Создаем новый контекст для получения свежих данных из БД
                // Используем AsNoTracking() чтобы избежать кэширования
                using (var context = new TestContext())
                {
                    return context.Set<T>().AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetAll exception: {ex}"); // Писать не обязательно, но полезно для дебага :D Далее этот комментарий дублироваться не будет
                throw;
            }
        }


        /// <summary>
        /// Добавляет новую запись в базу данных
        /// </summary>
        /// <param name="item">Добавляемая сущность</param>
        public void Add(T item)
        {
            try
            {
                // Создаем новый контекст для добавления
                using (var context = new TestContext())
                {
                    context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Add exception: {ex}");
                MessageBox.Show("Ошибка при добавлении");
                throw;
            }
        }

        /// <summary>
        /// Обновляет существующую запись в базе данных
        /// </summary>
        /// <param name="item">Обновляемая сущность</param>
        public void Update(T item)
        {
            try
            {
                // Создаем новый контекст чтобы избежать конфликта отслеживания
                using (var newContext = new TestContext())
                {
                    newContext.Set<T>().Update(item);
                    newContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Update exception: {ex}");
                MessageBox.Show("Ошибка при обновлении");
                throw;
            }
        }

        /// <summary>
        /// Удаляет запись из базы данных
        /// </summary>
        /// <param name="item">Удаляемая сущность</param>
        public void Delete(T item)
        {
            try
            {
                // Создаем новый контекст для удаления
                using (var context = new TestContext())
                {
                    // Присоединяем сущность к контексту перед удалением
                    context.Set<T>().Attach(item);
                    context.Set<T>().Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Delete exception: {ex}");
                MessageBox.Show("Ошибка при удалении");
                throw;
            }
        }
    }
}