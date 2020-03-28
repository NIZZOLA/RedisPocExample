using System;
using System.Collections.Generic;
using System.Text;

namespace RedisDataRepository.Interface
{
    public interface IRedisRepository
    {
        string GetStringValue(string key);
        void SetStringValue(string key, string value, int timeOutHours);
        void DeleteStringValue(string key);
    }
}
