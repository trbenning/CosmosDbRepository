﻿using System.Threading.Tasks;

namespace CosmosDbRepository
{
    public interface ICosmosDb
    {
        Task<string> SelfLinkAsync { get; }
        ICosmosDbRepository<T> Repository<T>();
        ICosmosDbRepository<T> Repository<T>(string id);
    }
}
