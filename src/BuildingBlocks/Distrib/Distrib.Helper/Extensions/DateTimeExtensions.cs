﻿using System;

namespace Distrib.Helper.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixEpochDate(this DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
