﻿#nullable enable
namespace TheOne.Extensions
{
    using System;
    using System.Globalization;

    public static class DateTimeExtensions
    {
        public static DateTime GetFirstDayOfWeek(this DateTime dateTime, DayOfWeek firstDayOfWeek)
        {
            var diff           = dateTime.DayOfWeek - firstDayOfWeek;
            if (diff < 0) diff += 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime, DateTimeFormatInfo dateTimeFormatInfo)
        {
            return GetFirstDayOfWeek(dateTime, dateTimeFormatInfo.FirstDayOfWeek);
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime, CultureInfo cultureInfo)
        {
            return GetFirstDayOfWeek(dateTime, cultureInfo.DateTimeFormat);
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
        {
            return GetFirstDayOfWeek(dateTime, CultureInfo.InvariantCulture);
        }

        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime GetFirstDayOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1);
        }
    }
}