using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.Lists
{
    public class ListURLs
    {
        public static string RestUrlList(string listName)
        {
            return string.Format("/_api/web/lists/GetByTitle('{0}')", listName);
        }
        public static string RestUrlListItemWithQuery(string listName,bool isQueryRequired)
        {
            if (isQueryRequired)
            {
                Type myType = typeof(SelectExpandListFields);
                string selectExpandListName = listName.Replace(" ", string.Empty);
                if (myType.GetField(selectExpandListName) == null)
                    return string.Concat(RestUrlList(listName), "/items?$select=*");
                else
                    return string.Concat(RestUrlList(listName), "/items", myType.GetField(selectExpandListName).GetValue(null));
            }
            else
            {
                return string.Concat(RestUrlList(listName), "/items");
            }
        }
        public static string RestUrlListGetItem(string listName)
        {
            return string.Concat(RestUrlList(listName), "/getitems");
        }
    }
}
