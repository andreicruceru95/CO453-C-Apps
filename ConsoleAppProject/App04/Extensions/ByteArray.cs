using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04.Extensions
{
    public static class ByteArray
    {
        public static string RenderImage(this byte[] array)
        {
            if (array == null)
            {
                return string.Empty;
            }
            return "data:image; base64," + Convert.ToBase64String(array);
        }
    }
}
