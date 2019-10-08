using System.Collections.Generic;
using System.Dynamic;

namespace Corsinvest.UrBackup.Api.Helpers
{
    /// <summary>
    /// Object helper
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Property exists
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool PropertyExists(this object obj, string name)
        {
            if (obj == null) { return false; }
            return (obj is ExpandoObject) ?
                ((IDictionary<string, object>)obj).ContainsKey(name) :
                obj.GetType().GetProperty(name) != null;
        }

    }
}
