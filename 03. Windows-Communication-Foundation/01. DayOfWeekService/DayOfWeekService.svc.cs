namespace _01.DayOfWeekService
{
    using System;

    public class DayOfWeekService : IDayOfWeekService
    {       
        public string GetDayOfWeek(DateTime date)
        {
            var dayOfWeek = (int)date.DayOfWeek;

            switch (dayOfWeek)
            {
                case 0:
                    return "Неделя";
                case 1:
                    return "Понеделник";
                case 2:
                    return "Вторник";
                case 3:
                    return "Сряда";
                case 4:
                    return "Четвъртък";
                case 5:
                    return "Петък";
                case 6:
                    return "Събота";
                default:
                    return null;
            }
        }
    }
}
