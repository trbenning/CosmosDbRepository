using CosmosDbRepository.Types;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CosmosDbRepository
{
    public interface ICosmosDbRepository
    {
        string Id { get; }
        Type Type { get; }
        Task<string> AltLink { get; }
        Task Init();
    }

    public interface ICosmosDbRepository<T>
        : ICosmosDbRepository
    {
        Task<T> AddAsync(T entity, RequestOptions requestOptions = null);
        Task<T> GetAsync(T entity, RequestOptions requestOptions = null);
        Task<T> GetAsync(DocumentId itemId, RequestOptions requestOptions = null);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IQueryable<T>> clauses = null, FeedOptions feedOptions = null);
        Task<CosmosDbRepositoryPagedResults<T>> FindAsync(int pageSize, string continuationToken, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IQueryable<T>> clauses = null, FeedOptions feedOptions = null);
        Task<IList<U>> SelectAsync<U>(Expression<Func<T, U>> selector, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<CosmosDbRepositoryPagedResults<U>> SelectAsync<U>(int pageSize, string continuationToken, Expression<Func<T, U>> selector, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<IList<U>> SelectAsync<U, V>(Expression<Func<V, U>> selector, Func<IQueryable<T>, IQueryable<V>> whereClauses = null, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<CosmosDbRepositoryPagedResults<U>> SelectAsync<U, V>(int pageSize, string continuationToken, Expression<Func<V, U>> selector, Func<IQueryable<T>, IQueryable<V>> whereClauses, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<IList<U>> SelectManyAsync<U>(Expression<Func<T, IEnumerable<U>>> selector, Func<IQueryable<T>, IQueryable<T>> whereClauses = null, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<CosmosDbRepositoryPagedResults<U>> SelectManyAsync<U>(int pageSize, string continuationToken, Expression<Func<T, IEnumerable<U>>> selector, Func<IQueryable<T>, IQueryable<T>> whereClauses = null, Func<IQueryable<U>, IQueryable<U>> selectClauses = null, FeedOptions feedOptions = null);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IQueryable<T>> clauses = null, FeedOptions feedOptions = null);
        Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IQueryable<T>> clauses = null, FeedOptions feedOptions = null);
        Task<T> UpsertAsync(T entity, RequestOptions requestOptions = null);
        Task<T> ReplaceAsync(T entity, RequestOptions requestOptions = null);
        Task<bool> DeleteDocumentAsync(DocumentId itemId, RequestOptions requestOptions = null);
        Task<bool> DeleteDocumentAsync(T entity, RequestOptions requestOptions = null);
        Task<bool> DeleteAsync(RequestOptions requestOptions = null);
        Task<TResult> ExecuteStoredProcedure<TResult>(string id, params dynamic[] args);
    }
}