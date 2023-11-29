using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class playerData 
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("TotalScore")]
    public int TotalScore { get; set; }


}
