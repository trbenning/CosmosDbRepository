namespace CosmosDbRepository.Substitute
{
    public interface ICosmosDbRepositorySubstitute
    {
        void SubstituteStoredProcedureResponse(string id, object result);
    }
}
