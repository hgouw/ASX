using System;

namespace ASX.Common
{
    public static class FileExtension
    {
        public static bool IsCsvExtension(this string fileName)
        {
            if (fileName.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsExcelExtension(this string fileName)
        {
            if (fileName.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase) ||
                fileName.EndsWith(".xlsx", StringComparison.CurrentCultureIgnoreCase) ||
                fileName.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsPdfExtension(this string fileName)
        {
            if (fileName.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsPowerPointExtension(this string fileName)
        {
            if (fileName.EndsWith(".ppt", StringComparison.CurrentCultureIgnoreCase) ||
                fileName.EndsWith(".pptx", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsTxtExtension(this string fileName)
        {
            if (fileName.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsWordExtension(this string fileName)
        {
            if (fileName.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase) ||
                fileName.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }
    }
}