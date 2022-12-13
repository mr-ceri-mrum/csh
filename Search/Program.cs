// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Search
{
    static class Program
    {
       
        static void Main(string[] agrs)
        {
            UserSearch("Almaty", "",null,null);
        }

        public static void UserSearch(string? city = "", string? gender = "", int? before = null, int? after = null, string? time = null)
        {
            var users = new List<User>()
            {
                new User(1, 10, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "m","12/06/2022"),
                new User(2, 11, "UserName2", "zhu@mail.com", "8777777778", "Ilya Zhunusov", "Astana", "m", "12/06/2022"),
                new User(3, 12, "user3", "zhunusss@mail.com", "8777777777", "Ilya Zhunusov", "Shimkent", "w", "12/06/2022"),
                new User(4, 13, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Astana", "m", "12/06/2022"),
                new User(5, 13, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "w", "12/07/2022"),
                new User(6, 13, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "w", "11/05/2022"),
                new User(7, 13, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "m", "09/05/2023"),
                new User(8, 13, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "w", "12/05/2022"),
                new User(9, 11, "UserName", "zh@mail.com", "8777777777", "Ilyas Zhunusov", "Almaty", "w", "12/06/2022"),

            };

            int searchResults = 0;
            IEnumerable<User> where;
            //только город
            if (city != "" & gender == "" & before == null & after == null && time == null)
            {
                where = users.Where(x => x.City == city);
                
                foreach (var item in where)
                {
                    Console.WriteLine("только город");
                    searchResults += 1;
                    CW(item);
                }
            }

            //пол и город
            if (city != "" & gender != "" & before == null & after == null & time == null)
            {
                where = users.Where(x => x.City == city & x.Gender == gender);
                foreach (var item in where)
                {
                    Console.WriteLine("пол и город");
                    searchResults += 1;
                    CW(item);
                }
            }

            //пол город и возраст от 
            if (city != "" & gender != "" & before != null & after == null && time == null)
            {
                where = users.Where(x => x.City == city && x.Gender == gender && x.Age >= before);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //пол город и возраст до 
            if (city != "" & gender != "" & before == null & after != null  && time == null)
            {
                where = users.Where(x => x.City == city && x.Gender == gender && x.Age <= after);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Всё
            if (city != "" & gender != "" & before != null & after != null & time != null)
            {
                where = users.Where(
                    x => x.City == city && x.Gender == gender && (x.Age >= before && x.Age <= after) && x.Date == time);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            
            //Всё кроме время
            if (city != "" & gender != "" & before != null & after != null & time == null)
            {
                where = users.Where(
                    x => x.City == city && x.Gender == gender && (x.Age >= before && x.Age <= after) );
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            
            //Только гендр
            if (gender != "" && (city == "" & before == null & after == null) && time == null)
            {
                where = users.Where(x => x.Gender == gender);

                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            
            //Только время
            if (city == "" & gender == "" & before == null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            // Город и время
            if (city != "" & gender == "" & before == null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city);
                foreach (var item in where)
                {
                    Console.WriteLine("Город и время");
                    searchResults += 1;
                    CW(item);
                }
            }
            // Город и время и гендер
            if (city != "" & gender != "" & before == null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city && x.Gender == gender);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            // Город и время и гендер и время от
            if (city != "" & gender != "" & before != null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city && x.Gender == gender && x.Age >= before);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            // Город и время и гендер и время до
            if (city != "" & gender != "" & before == null & after != null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city && x.Gender == gender && x.Age <= after);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Город и время,  возраст от
            if (city != "" & gender == "" & before != null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city && x.Age >= before);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Город и время,  возраст до
            if (city != "" & gender == "" & before == null & after != null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.City == city && x.Age <= after);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Время и ОТ
            if (city == "" & gender == "" & before != null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time &&  x.Age >= before);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Время и ДО
            if (city == "" & gender == "" & before == null & after != null & time != null)
            {
                where = users.Where(
                    x => x.Date == time &&  x.Age <= after);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //Гендр и время
            if (city == "" & gender != "" & before == null & after == null & time != null)
            {
                where = users.Where(
                    x => x.Date == time && x.Gender == gender);
                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }
            //гендр и возраст от
            if (gender != "" && city == "" & before != null & after == null && time == null)
            {
                var Users = users.Where(x => x.Gender == gender && x.Age >= before);

                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //Гендр и возраст только до
            if (gender != "" && city == "" && before == null && after != null && time == null)
            {
                where = users.Where(x => x.Gender == gender && x.Age <= after);

                foreach (var item in where)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //гендр и возраст от до
            if (gender != "" && city == "" & before != null & after != null && time == null)
            {
                var Users = users.Where(x => x.Gender == gender && (x.Age >= before && x.Age <= after));

                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //Город и возраст от
            if (gender == "" && city != "" & before != null & after == null && time == null)
            {
                var Users = users.Where(x => x.City == city && x.Age >= before);
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //Город и возраст от до
            if (gender == "" && city != "" & before != null & after != null && time == null)
            {
                var Users = users.Where(x => x.City == city && (x.Age >= before && x.Age <= after));
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }

            }

            //возраст от
            if (gender == "" && city == "" & before != null & after == null && time == null)
            {
                var Users = users.Where(x => (x.Age >= before));
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //вораста до
            if (gender == "" && city == "" & before == null & after != null && time == null)
            {
                var Users = users.Where(x => (x.Age <= after));
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //возраст от до
            if (gender == "" && city == "" & before != null & after != null && time == null)
            {
                var Users = users.Where(x => (x.Age >= before && x.Age <= after));
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                }
            }

            //если всё пусто возращает всех юзеров
            if (gender == "" && city == "" && before == null && after == null && time == null)
            {
                Console.WriteLine("если всё пусто возращает всех юзеров");
                var Users = users;
                foreach (var item in Users)
                {
                    searchResults += 1;
                    CW(item);
                    
                }
            }
            
            if (searchResults == 0) Console.WriteLine("Пользователь не найден");
            
            else Console.WriteLine("Найдено :" + searchResults);
        }


        public static void CW(User item)
        {
            Console.WriteLine("ID: :" + item.Id);
            Console.WriteLine("AGE :" + item.Age);
            Console.WriteLine("UserName :" + item.UserName);
            Console.WriteLine("FullName :" + item.FullName);
            Console.WriteLine("City :" + item.City);
            Console.WriteLine("Gender:" + item.Gender);
            Console.WriteLine("Time:" + item.Date);
            Console.WriteLine("-------------------");
        }
    }
    
    
    public  class User : DbContext
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public string City {get; set; }
        public string Gender { get; }
        public string Date { get; } = DateTime.Now.ToString("MM/dd/yyyy");


        public User(
            int id,
            int age, 
            string userName, 
            string email, 
            string phone, 
            string fullName,
            string city, 
            string gender,
            string date)
        {
            Id = id;
            Age = age;
            UserName = userName;
            Email = email;
            Phone = phone;
            FullName = fullName;
            City = city;
            Gender = gender;
            Date = date;
        }
    }
}