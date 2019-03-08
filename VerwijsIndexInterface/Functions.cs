using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Denion.WebService.VerwijsIndex
{
    public static class Functions
    {
        static Regex VehicleRegEx = new Regex("[^a-z0-9]+", RegexOptions.IgnoreCase);

        /// <summary>
        /// Strips of everything but tekst
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public static string StripVehicleId(this string vehicleId)
        {
            return VehicleRegEx.Replace(RemoveDiacritics(vehicleId).ToUpper(), "");
        }

        /// <summary>
        /// Replace extended characters with the basic ones
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static String RemoveDiacritics(String s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public static List<string> ValidTypes = new List<string>();
        public static bool IsValidType(string token)
        {
            return ValidTypes.Contains(token.ToUpper());
        }

        public static List<string> ValidAreaManagerIds = new List<string>();
        public static bool IsValidAreaManagerId(string areaManagerId)
        {
            return ValidAreaManagerIds.Contains(areaManagerId.ToUpper());
        }
        /// <summary>
        /// returns smallest date
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
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
                minValue = dt2;
            else
                minValue = dt1;

            return minValue;
        }

        public static string ToLongString(object o)
        {
            StringBuilder sb = new StringBuilder();

            foreach (System.Reflection.PropertyInfo prop in o.GetType().GetProperties())
            {
                sb.Append(prop.Name + ": " + prop.GetValue(o, null) + Environment.NewLine);
            }
            return sb.ToString();
        }

        public static long GenerateUniqueId() {
            Random r = new Random();
            return long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + r.Next());
        }
    }

    public struct DateTimeRange
    {
        #region Construction
        public DateTimeRange(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("Invalid range edges.");
            }
            _Start = start;
            _End = end;
        }
        #endregion

        #region Properties
        private DateTime _Start;

        public DateTime Start
        {
            get { return _Start; }
            private set { _Start = value; }
        }
        private DateTime _End;

        public DateTime End
        {
            get { return _End; }
            private set { _End = value; }
        }
        #endregion

        #region Operators
        public static bool operator ==(DateTimeRange range1, DateTimeRange range2)
        {
            return range1.Equals(range2);
        }

        public static bool operator !=(DateTimeRange range1, DateTimeRange range2)
        {
            return !(range1 == range2);
        }
        public override bool Equals(object obj)
        {
            if (obj is DateTimeRange)
            {
                var range1 = this;
                var range2 = (DateTimeRange)obj;
                return range1.Start == range2.Start && range1.End == range2.End;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Querying
        public bool Intersects(DateTimeRange range)
        {
            var type = GetIntersectionType(range);
            return type != IntersectionType.None;
        }
        public bool IsInRange(DateTime date)
        {
            return (date >= this.Start) && (date <= this.End);
        }
        public IntersectionType GetIntersectionType(DateTimeRange range)
        {
            if (this == range)
            {
                return IntersectionType.RangesEqauled;
            }
            else if (IsInRange(range.Start) && IsInRange(range.End))
            {
                return IntersectionType.ContainedInRange;
            }
            else if (IsInRange(range.Start))
            {
                return IntersectionType.StartsInRange;
            }
            else if (IsInRange(range.End))
            {
                return IntersectionType.EndsInRange;
            }
            else if (range.IsInRange(this.Start) && range.IsInRange(this.End))
            {
                return IntersectionType.ContainsRange;
            }
            return IntersectionType.None;
        }
        public DateTimeRange GetIntersection(DateTimeRange range)
        {
            var type = this.GetIntersectionType(range);
            if (type == IntersectionType.RangesEqauled || type == IntersectionType.ContainedInRange)
            {
                return range;
            }
            else if (type == IntersectionType.StartsInRange)
            {
                return new DateTimeRange(range.Start, this.End);
            }
            else if (type == IntersectionType.EndsInRange)
            {
                return new DateTimeRange(this.Start, range.End);
            }
            else if (type == IntersectionType.ContainsRange)
            {
                return this;
            }
            else
            {
                return default(DateTimeRange);
            }
        }
        #endregion


        public override string ToString()
        {
            return Start.ToString() + " - " + End.ToString();
        }
    }
    public enum IntersectionType
    {
        /// <summary>
        /// No Intersection
        /// </summary>
        None = -1,
        /// <summary>
        /// Given range ends inside the range
        /// </summary>
        EndsInRange,
        /// <summary>
        /// Given range starts inside the range
        /// </summary>
        StartsInRange,
        /// <summary>
        /// Both ranges are equaled
        /// </summary>
        RangesEqauled,
        /// <summary>
        /// Given range contained in the range
        /// </summary>
        ContainedInRange,
        /// <summary>
        /// Given range contains the range
        /// </summary>
        ContainsRange,
    }
}
