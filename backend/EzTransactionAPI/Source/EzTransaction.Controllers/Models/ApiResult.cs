namespace EzTransaction.Controllers.Models;

using FluentValidation.Results;

public class ApiResult<T>
{
    public ApiResult(IEnumerable<ValidationFailure> errors)
    {
        this.Errors = errors.Select(x => x.ErrorMessage).ToArray();
    }

    public ApiResult(T data)
    {
        this.Data = data;
    }

    public T? Data { get; init; }

    public string[]? Errors { get; init; }
}