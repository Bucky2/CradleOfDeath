using System;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEditor;

public class DBmongo : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<BsonDocument> collection;

    // Propiedad estática para acceder a una instancia única de la clase
    public static DBmongo Instance { get; private set; }

    // Asegúrate de que solo haya una instancia de esta clase
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.ehv4t.mongodb.net/?retryWrites=true&w=majority");

        db = client.GetDatabase("Unity");
        collection = db.GetCollection<BsonDocument>("player");

    }
    public void SaveScore(playerData playerInfo)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Name", playerInfo.Name);
        var update = Builders<BsonDocument>.Update
            .Set("TotalScore", playerInfo.TotalScore)
            .SetOnInsert("Name", playerInfo.Name);

        var result = collection.UpdateOne(filter, update, new UpdateOptions
        {
            IsUpsert = true
        });

        if (result.IsAcknowledged)
        {
            Debug.Log($"Registro actualizado o nuevo creado con éxito.");
        }
        else
        {
            Debug.LogError($"Error al actualizar el registro.");
        }
    }
}