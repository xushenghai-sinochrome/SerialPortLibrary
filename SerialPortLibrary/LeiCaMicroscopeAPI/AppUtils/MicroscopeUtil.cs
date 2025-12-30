using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtils
{
    class MicroscopeUtil
    {
        public static string ConvertToString(List<int> buffer, string space = " ", string tail = "\r")
        {
            try
            {
                if(buffer.Count <= 0)
                    return default(string);
                StringBuilder StringBuffer = new StringBuilder();
                foreach (int data in buffer)
                {
                    StringBuffer.Append(data.ToString());
                    StringBuffer.Append(space);
                }
                StringBuffer.Remove(StringBuffer.Length - space.Length, space.Length);
                StringBuffer.Append(tail);
                return StringBuffer.ToString();
            }
            catch (Exception) { }
            return default(string);

        }
        public static string MicroscopeCommand(int ID, string parameter)
        {
            try
            {
                string buffer = ID.ToString() + " " + parameter + "\r";
                return buffer;
            }catch(Exception)
            {
                return null;
            }
        }
        public static int ConvertToInt(object buffer)
        {
            try
            {
                if (buffer == null)
                    return default(int);
                if (buffer.GetType() == typeof(int))
                    return (int)buffer;
                return Convert.ToInt32(buffer);
            }
            catch (Exception)
            {
                return default(int);
            }
        }
        public static int ConvertObjective(string buffer)
        {
            try
            {
                if (string.IsNullOrEmpty(buffer))
                    return default(int);
                return Convert.ToInt32(buffer);
            }catch(Exception){
                return default(int) ;
            }
        }
        public static List<int> Parser(string buffer, string space = " ")
        {
            List<int> Array = new List<int>();
            try
            {
                if (string.IsNullOrEmpty(buffer))
                    return Array;
                String[]  Buffer = buffer.Split(space.ToCharArray());
                foreach(string data in Buffer)
                {
                    Array.Add(MicroscopeUtil.ConvertObjective(data));
                }
            }
            catch (Exception)
            { }
            return Array;
        }
        public static String[] ConvertStringList(string buffer, string space = " ")
        {
            try
            {
                if (string.IsNullOrEmpty(buffer))
                    return default(String[]);
                String[] Buffer = buffer.Split(space.ToCharArray());
                return Buffer;
            }
            catch (Exception)
            { }
            return default(String[]);

        }
        public static int  StringListIndexOf(string[] buffer, string data)
        {
            int index = -1;
            int count = 0;
            foreach(string S in buffer)
            {
                if(S.ToLower() == data.ToLower())
                {
                    index = count;
                    break;
                }
                count += 1;
            }

            return index;
        }
    }
}
