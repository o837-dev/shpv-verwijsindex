using System;
using System.Diagnostics;

namespace ConsolApp
{
    class DateTimeDing
    {
        public DateTimeDing()
        {
            DateTime dt0 = new DateTime(2017, 1, 6, 15, 00, 00);

            Debug.WriteLine(MinDate2(null, null));
            Debug.WriteLine(MinDate2(null, DateTime.MinValue));
            Debug.WriteLine(MinDate2(null, dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(null, dt0));
            Debug.WriteLine(MinDate2(null, dt0.AddMinutes(1)));

            Debug.WriteLine("-");
            Debug.WriteLine(MinDate2(DateTime.MinValue, null));
            Debug.WriteLine(MinDate2(DateTime.MinValue, DateTime.MinValue));
            Debug.WriteLine(MinDate2(DateTime.MinValue, dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(DateTime.MinValue, dt0));
            Debug.WriteLine(MinDate2(DateTime.MinValue, dt0.AddMinutes(1)));

            Debug.WriteLine("-");
            Debug.WriteLine(MinDate2(dt0.AddMinutes(-1), null));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(-1), DateTime.MinValue));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(-1), dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(-1), dt0));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(-1), dt0.AddMinutes(1)));

            Debug.WriteLine("-");
            Debug.WriteLine(MinDate2(dt0, null));
            Debug.WriteLine(MinDate2(dt0, DateTime.MinValue));
            Debug.WriteLine(MinDate2(dt0, dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(dt0, dt0));
            Debug.WriteLine(MinDate2(dt0, dt0.AddMinutes(1)));

            Debug.WriteLine("-");
            Debug.WriteLine(MinDate2(dt0.AddMinutes(1), null));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(1), DateTime.MinValue));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(1), dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(1), dt0));
            Debug.WriteLine(MinDate2(dt0.AddMinutes(1), dt0.AddMinutes(1)));

            Debug.WriteLine("-");
            Debug.WriteLine(MinDate2(DateTime.MaxValue, null));
            Debug.WriteLine(MinDate2(DateTime.MaxValue, DateTime.MinValue));
            Debug.WriteLine(MinDate2(DateTime.MaxValue, dt0.AddMinutes(-1)));
            Debug.WriteLine(MinDate2(DateTime.MaxValue, dt0));
            Debug.WriteLine(MinDate2(DateTime.MaxValue, dt0.AddMinutes(1)));

            Debug.WriteLine("-");
        }

        public static DateTime? MinDate(DateTime? dt1, DateTime? dt2)
        {
            DateTime? minValue = null;
            if (dt1.HasValue && dt1.Value > DateTime.MinValue)
            {
                if (dt2.HasValue && dt2.Value > DateTime.MinValue)
                {
                    if (dt2.Value < dt1.Value)
                        minValue = dt2;
                    else
                        minValue = dt1;
                }
                else
                    minValue = dt1;

            }
            else if (dt2.HasValue)
            {
                minValue = dt2;
            }
            else
                minValue = dt1;

            return minValue;
        }

        public static DateTime? MinDate2(DateTime? dt1, DateTime? dt2)
        {
            //return (dt1.HasValue) ? ((dt2.HasValue) ? ((dt1.Value < dt2.Value) ? dt1 : dt2): dt1): dt2;
            if (dt1.HasValue && dt1.Value > DateTime.MinValue)
            {
                if (dt2.HasValue && dt2.Value > DateTime.MinValue)
                    return new DateTime(Math.Min(dt1.Value.Ticks, dt2.Value.Ticks));
                else
                    return dt1;
            }
            else
                return dt2;
        }
    }
}
