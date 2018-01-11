using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPL.RedSkyTimeSheet.Lists
{
    class Generic
    {
    }

    public class BaseID
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
    }

    /// <summary>
    /// ModelBase class is holds all comman properties to distribut in child class
    /// </summary>
    public class Base : BaseID
    {
        [JsonProperty("Created")]
        public DateTime Created { get; set; }

        [JsonProperty("Modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("Author")]
        public User _CreatedBy { set { CreatedBy = value; } }
        [JsonProperty("CreatedBy")]
        public User CreatedBy { get; private set; }

        [JsonProperty("Editor")]
        public User _ModifiedBy { set { ModifiedBy = value; } }
        [JsonProperty("ModifiedBy")]
        public User ModifiedBy { get; private set; }
    }

    /// <summary>
    /// This model holds properties required from sharepoint user.
    /// </summary>
    public class User : BaseID
    {
        [JsonProperty("Title")]
        public string _Name { set { Name = value; } }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Users
    {
        [JsonProperty("results")]
        public User[] AllUsers { get; set; }
    }

    /// <summary>
    /// Generic method for id value pair
    /// </summary>
    public class Lookup : BaseID
    {
        public string Value { get; set; }
    }

    public class Status : BaseID
    {
        [JsonProperty("Employee_x0020_Status")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class LeaveTypeLookup : BaseID
    {
        [JsonProperty("Leave_x0020_Type")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }
    public class ServiceDeskIdLookup : BaseID
    {
        [JsonProperty("Service_x0020_Desk_x0020_Id")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }
    public class TitleLookup : BaseID
    {
        [JsonProperty("Title")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class ClientNameLookup : BaseID
    {
        [JsonProperty("Client_x0020_Name")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class ClientTypeLookup : BaseID
    {
        [JsonProperty("Client_X0020_Type")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class ProjectCategoryLookup : BaseID
    {
        [JsonProperty("Category")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class HolidayTypeLookup : BaseID
    {
        [JsonProperty("Type_x0020_Name")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class DepartmentLookup : BaseID
    {
        [JsonProperty("Department")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class ConcernLookup : BaseID
    {
        [JsonProperty("Predefined_x0020_Concern")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class MaritalStatusLookup : BaseID
    {
        [JsonProperty("Name")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class Designation : BaseID
    {
        [JsonProperty("Designation")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class StatusLookup : BaseID
    {
        [JsonProperty("Status")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class CurrencyLookup : BaseID
    {
        [JsonProperty("Code")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }
    
    public class FinancialYearLookup : BaseID
    {
      
        [JsonProperty("Title")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }
    
    
    public class TransactionIDLookup : BaseID
    {
        [JsonProperty("Transaction_x0020_ID")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }
    public class FieldIDLookup : BaseID
    {
        [JsonProperty("ID")]
        public string _Value { set { Value = value; } }
        [JsonProperty("Value")]
        public string Value { get; private set; }
    }

    public class ObjectToListConvertor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<User>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var obj = token["results"];
            if (obj == null)
                return null;
            User[] allusers = obj.ToObject<User[]>();
            return allusers.ToList<User>();

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
