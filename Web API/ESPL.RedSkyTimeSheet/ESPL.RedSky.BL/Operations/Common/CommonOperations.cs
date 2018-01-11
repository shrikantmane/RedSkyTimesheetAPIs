using ESPL.RedSkyTimeSheet.BL.Models;
using ESPL.RedSkyTimeSheet.Lists;
using ESPL.SHAREPOINT.RESTSERVICE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ESPL.RedSkyTimeSheet.BL.Operations.Common
{
    public class CommonOperations
    {
        public static string GenerateIDsCAMLQuery(List<IDs> allValues, string fieldName, string valueType)
        {
            string query = string.Empty;
            if (allValues != null && allValues.Count > 0)
            {
                if (allValues.Count() == 1)
                {
                    query = string.Concat("<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[0].ID, "</Value></Eq>");
                }
                else if (allValues.Count() == 2)
                {
                    query = string.Concat("<Or>",
                                                "<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[0].ID, "</Value></Eq>",
                                                "<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[1].ID, "</Value></Eq>",
                                          "</Or>");
                }
                else
                {
                    query = string.Concat("<Or>",
                                               "<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[0].ID, "</Value></Eq>",
                                               "<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[1].ID, "</Value></Eq>",
                                         "</Or>");

                    for (int i = 2; i < allValues.Count(); i++)
                    {

                        query = string.Concat("<Or>", query);
                        query += string.Concat("<Eq><FieldRef Name='", fieldName, "' /><Value Type='", valueType, "'>", allValues[i].ID, "</Value></Eq>");
                        query += "</Or>";

                    }
                }
            }

            return query;
        }

        public static string GetFilterByMultipleValues(List<IDs> ids, string field)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ids.Count; i++)
            {
                sb.Append(string.Concat("(", field, " eq '", ids[i].ID, "')"));
                if (i != ids.Count - 1)
                {
                    sb.Append(" or ");
                }
            }

            return Convert.ToString(sb);
        }
    }
}
