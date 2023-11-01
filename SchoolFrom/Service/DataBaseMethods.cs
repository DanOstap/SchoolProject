using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficeOpenXml;
using SchoolFrom.Model;
using System.Reflection;

namespace SchoolFrom.Service
{
    public class DataBaseMethods
    {
        private readonly Connection _DataBaseModel;
        private readonly IMongoCollection<Candidate> _DataBaseCollection;
        public DataBaseMethods(IOptions<Connection> _option)
        {
            MongoClient client = new MongoClient(_option.Value.DataBase_Url);
            IMongoDatabase database = client.GetDatabase(_option.Value.DataBase_Name);
            _DataBaseCollection = database.GetCollection<Candidate>(_option.Value.DataBase_Collection);
        }
        public async Task<Candidate> InsertCandidate(Candidate _model)
        {
            _DataBaseCollection.InsertOneAsync(_model);
            return _model;
        }
        public async Task<List<Candidate>> GetAllCandidates()
        {
            return await _DataBaseCollection.Find(_ => true).ToListAsync();
        }
    }
}
