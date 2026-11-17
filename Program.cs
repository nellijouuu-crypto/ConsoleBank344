/*блочный
Клиент вносит на банковский счет некоторую сумму и указывает срок вклада (дни).
Счет замораживается на указанных срок. 
Банк назначает годовой банковский процент как случайное число от 5.25% до 15.86%. 
Рассчитать сумму на счету клиента в конце срока вклада с учетом надбавки банковского %.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в проект
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        static void Main(string[] args)
        {
            //Описание локальных величин
            double summa, bankPercent, bonusInDay, bonusTotal;
            int countDays;
            string temp;

            //Ввод исходных данных с клавиатуры
            Console.Write("Введите сумму вклада: ");    //Вывод на экран
            temp = Console.ReadLine();     //Получение данных с клавитуры с нажатием Enter
            try       //Поймать сбой
            {
                //Описные команды
                summa = Convert.ToDouble(temp);
            }
            catch (FormatException) //Обработка сбоя
            {
                //Сообщения об ошибке
                Console.WriteLine("Вы ошиблись при вводе суммы.");
                Console.WriteLine("Приложение будет закрыто.");
                Console.ReadKey();  //Остановить окно консоли
                return;
            }

            Console.Write("Введите срок вклада: ");    //Вывод на экран
            temp = Console.ReadLine();     //Получение данных с клавитуры с нажатием Enter
            try       //Поймать сбой
            {
                //Описные команды
                countDays = Convert.ToInt32(temp);
            }
            catch (FormatException) //Обработка сбоя
            {
                //Сообщения об ошибке
                Console.WriteLine("Вы ошиблись при вводе срока вклада.");
                Console.WriteLine("Приложение будет закрыто.");
                Console.ReadKey();  //Остановить окно консоли
                return;
            }
            //Успешный ввод
            Console.WriteLine("Ваши данные приняты.");

            //ДСЧ
            Random random = new Random();       //1. Создать объект (экземпляр) класса
            bankPercent = 5.25 + random.NextDouble() * 11.61;  //2. Используем возможности класса через объект
            //число =𝑎+Датчик(b −a + 1)  [a=5.25  b=15.86]
            Console.WriteLine("Вам начислен банковский % = {0:N2}", bankPercent);

            //Банковские расчеты
            bonusInDay = (bankPercent / (100 * 365)) * summa;
            Console.WriteLine("Ваша надбавка за один день = " + bonusInDay.ToString("N2") + " рублей");    //Слияние строк
            bonusTotal = bonusInDay * countDays;
            Console.WriteLine("Ваша надбавка за весь период = " + bonusTotal.ToString("N2") + " рублей");
            summa += bonusTotal;
            Console.WriteLine("Ваша сумма на счету в конце строка = " + summa.ToString("N2") + " рублей");

            //доход одного дня = (Годовой банковский %)/ (100∗365)∗сумма вклада

            //Вывод результатов

            Console.ReadKey();  //Остановить окно консоли
        }
    }
}