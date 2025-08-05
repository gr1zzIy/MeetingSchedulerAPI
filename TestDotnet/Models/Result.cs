namespace TestDotnet.Models;

/// <summary>
/// Узагальнений результат операції, який може містити або успішне значення, або помилку.
/// Дозволяє елегантно обробляти результати операцій, що можуть завершитися з помилкою.
/// </summary>
/// <summary>
/// Generic operation result that can contain either a success value or an error.
/// Allows elegant handling of operations that might fail.
/// </summary>
/// <param name="T">
///     Тип успішного значення
///     Type of success value
/// </param>
/// <param name="E">
///     Тип помилки
///     Type of error
/// </param>
public class Result<T, E>
{
    public T? Value { get; }
    public E? Error { get; }
    public bool IsSuccess { get; }

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    private Result(E error)
    {
        Error = error;
        IsSuccess = false;
    }

    public static Result<T, E> Success(T value) => new(value);
    public static Result<T, E> Failure(E error) => new(error);

    public TResult Match<TResult>(Func<T, TResult> onSuccess, Func<E, TResult> onFailure)
        => IsSuccess ? onSuccess(Value!) : onFailure(Error!);
}