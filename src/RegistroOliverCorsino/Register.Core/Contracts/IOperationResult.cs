namespace Core.Contracts
{
    /// <summary>
    /// Represents a generic operation result.
    /// </summary>
    /// <typeparam name="T">Represents an entity that could be use for this Operation Result.</typeparam>
    public interface IOperationResult<T>
    {
        string Message { get; }
        bool Success { get; }
        T Entity { get; }
    }
}
