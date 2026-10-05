using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_Жирнова_Е.А._Holiday.Models
{
    // Класс для сотрудников (Staff)
    public class Staff
    {
        public int ID_Employee { get; set; }
        public string Surname { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Passport { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Навигационное свойство для связанных мероприятий
        public ICollection<Event> Events { get; set; }

        // Свойство для полного имени
        public string FullName
        {
            get
            {
                return $"{Surname} {First_Name} {Last_Name ?? ""}".Trim();
            }
        }
    }

    // Класс для заказчиков (Customer)
    public class Customer
    {
        public int ID_Customer { get; set; }
        public string Surname { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }

        // Навигационное свойство для связанных мероприятий
        public ICollection<Event> Events { get; set; }

        // Свойство для полного имени
        public string FullName
        {
            get
            {
                return $"{Surname} {First_Name} {Last_Name ?? ""}".Trim();
            }
        }
    }

    // Класс для категорий мероприятий (Event_Category)
    public class EventCategory
    {
        public int ID_Event_Category { get; set; }
        public string Title { get; set; }

        // Навигационное свойство для связанных мероприятий
        public ICollection<Event> Events { get; set; }
    }

    // Класс для дополнительных услуг (Additional_Services)
    public class AdditionalService
    {
        public int ID_Additional_Services { get; set; }
        public string Name_Services { get; set; }
        public decimal Cost { get; set; }

        // Навигационное свойство для связанных мероприятий
        public ICollection<Event> Events { get; set; }
    }

    // Класс для мест проведения (Location)
    public class Location
    {
        public int ID_Location { get; set; }
        public string Name_Location { get; set; }
        public string Address_Location { get; set; }
        public decimal Rental_Price { get; set; }

        // Навигационное свойство для связанных мероприятий
        public ICollection<Event> Events { get; set; }
    }

    // Класс для мероприятий (Event)
    public class Event
    {
        public int ID_Event { get; set; }
        public int ID_Customer { get; set; }
        public int ID_Event_Category { get; set; }
        public int ID_Location { get; set; }
        public DateTime Order_Data { get; set; }
        public DateTime Data_Event { get; set; }
        public TimeSpan Beginning { get; set; }
        public int Duration { get; set; }
        public int Number_Participants { get; set; }
        public int ID_Employee { get; set; }
        public decimal Price { get; set; }
        public int ID_Additional_Services { get; set; }

        // Навигационные свойства для связей
        public Customer Customer { get; set; }
        public EventCategory EventCategory { get; set; }
        public Location Location { get; set; }
        public Staff Employee { get; set; }
        public AdditionalService AdditionalService { get; set; }

        // Вычисляемые свойства
        public bool IsUpcoming
        {
            get
            {
                return Data_Event > DateTime.Now;
            }
        }

        public string EventStatus
        {
            get
            {
                if (Data_Event > DateTime.Now)
                    return "Предстоит";
                else if (Data_Event.Date == DateTime.Now.Date)
                    return "Сегодня";
                else
                    return "Прошло";
            }
        }

        public decimal Profit
        {
            get
            {
                // Прибыль = общая стоимость - аренда - доп услуги
                // Значения могут быть null, поэтому используем null-conditional operator
                return Price - (Location?.Rental_Price ?? 0) - (AdditionalService?.Cost ?? 0);
            }
        }
    }

    // Дополнительный класс для авторизации
    public class UserAuth
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
    }

    // Класс для отображения данных в DataGridView (DTO)
    public class EventViewModel
    {
        public int Номер_мероприятия { get; set; }
        public string ФИО_заказчика { get; set; }
        public string Телефон_заказчика { get; set; }
        public string Категория { get; set; }
        public string Место_проведения { get; set; }
        public string Адрес { get; set; }
        public decimal Стоимость_аренды { get; set; }
        public string Дополнительная_услуга { get; set; }
        public decimal Стоимость_услуги { get; set; }
        public DateTime Дата_заказа { get; set; }
        public DateTime Дата_проведения { get; set; }
        public string Время_начала { get; set; }
        public int Длительность_часов { get; set; }
        public int Количество_участников { get; set; }
        public string Ответственный_сотрудник { get; set; }
        public string Телефон_сотрудника { get; set; }
        public decimal Общая_стоимость { get; set; }
        public decimal Прибыль { get; set; }
        public string Статус { get; set; }
    }
}
