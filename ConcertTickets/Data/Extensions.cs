namespace ConcertTickets
{
    public static class Extensions
    {
        public static object CheckUpdateObject(object originalObj, object updateObj)
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                if (property.Name == "ConcertId")
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                        .GetValue(originalObj, null));
                }
                if (property.GetValue(updateObj, null) == null)
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                        .GetValue(originalObj, null));
                }
            }
            return updateObj;
        }
    }
}
