namespace webapi.Utils
{
    public static class UtilsClass
    {
        public static DateOnly ToDateOnly(this DateTime datetime)
            => DateOnly.FromDateTime(datetime);

        public static T GetDifference<T>(T oldData, T newData)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite && prop.Name != "Id");
            T result = oldData;
            foreach (var prop in properties)
            {
                if (prop.GetValue(newData, null) != prop.GetValue(oldData, null))
                    prop.SetValue(result, prop.GetValue(newData, null));
                else
                    prop.SetValue(result, null);
                //var value = prop.GetValue(source, null);
                //if (value is int)
                //    if ((int)value == 0)
                //        continue;
                //if (value != null)
                //    prop.SetValue(target, value, null);
            }
            return result;
        }
        public static T GetDifference<T>(T oldData, T newData, string foreignKey)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && 
            prop.CanWrite && 
            prop.Name != "Id" && 
            prop.Name != foreignKey);

            T result = oldData;
            foreach (var prop in properties)
            {
                if (prop.GetValue(newData, null) != prop.GetValue(oldData, null))
                    prop.SetValue(result, prop.GetValue(newData, null));
                else
                    prop.SetValue(result, null);
                //var value = prop.GetValue(source, null);
                //if (value is int)
                //    if ((int)value == 0)
                //        continue;
                //if (value != null)
                //    prop.SetValue(target, value, null);
            }

            return result;
        }

    }
}
