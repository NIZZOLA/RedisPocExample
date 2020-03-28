using Microsoft.Extensions.Configuration;
using RedisDataRepository.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisDataRepository.Repository
{
    public class RedisRepository : IRedisRepository
    {
        private IDatabase _database;
        private readonly Lazy<ConnectionMultiplexer> Connection;

        public RedisRepository(IConfigurationRoot configuration)
        {
            var endpoint = configuration["Cache:Redis:Endpoint"];
            var options = ConfigurationOptions.Parse(endpoint);
            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));

            _database = Connection.Value.GetDatabase();
        }

        public string GetStringValue(string key)
        {
            return _database.StringGet(key);
        }

        public void SetStringValue(string key, string value, int timeOutHours)
        {
            _database.StringSet(key, value, new TimeSpan(timeOutHours, 0, 0));
        }

        public void DeleteStringValue(string key)
        {
            _database.KeyDelete(key);
        }
    }
}

