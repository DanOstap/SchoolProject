using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace SchoolFrom.Model
{
    public class Candidate : Candidate_Father
    {
        [BsonId]
        public string Id { get; set; }
        public string Name_SubName { get; set; }
        public string Tel { get; set; }
        public DateTime Birthday { get; set; }
        public int IdCart { get; set; }
        public DateTime IdCart_End_Time { get; set; }
        public int IdCart_Code { get; set; }
        public string Social_status { get; set; }
        public string Physics_problems { get; set; }
        public string Hobby { get; set; }
        public string Crative { get; set; } = "Ні";
        public string Achivements { get; set; } = "Ні";

    }
}
