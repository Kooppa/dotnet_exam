using System.Text.Json.Serialization;

namespace exam.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Inventory
    {
        Admin = 1,

        Customer = 2,

        Seller = 3
    }
}