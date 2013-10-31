﻿namespace ProjectEuler
{
    public class Problem19
    {
        public ulong Solve()
        {
            ulong count = 0;
            int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int weekday = 1;
            for (int year = 1900; year <= 2000; year++)
                for (int month = 1; month <= 12; month++)
                {
                    int daysCount = monthDays[month - 1];
                    if (month == 2 && IsLeapYear(year))
                        daysCount++;
                    if (year >= 1901 && weekday == 7)
                        count++;
                    weekday = 1 + ((weekday + daysCount) % 7);
                }
            return count;
            //ulong count = 0;
            //DateTime date = new DateTime(1901, 1, 1);
            //while (date.Year != 2000 || date.Month != 12 || date.Day != 1) {
            //    if (date.DayOfWeek == DayOfWeek.Sunday && date.Day == 1)
            //        count++;
            //    date = date.AddDays(1);
            //}
            //return count;
        }

        private bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
                return true;
            else if (year % 100 == 0)
                return false;
            else if (year % 4 == 0)
                return true;
            else
                return false;
        }
    }
}
