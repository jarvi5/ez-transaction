namespace EzTransaction.Services.Models;

using FluentValidation.Results;

public class ServiceResult<T>
    where T : class
{
    public T? Result { get; set; }

    public List<ValidationFailure>? Errors { get; set; }

    public static implicit operator ServiceResult<T>(T? data) => new ServiceResult<T> { Result = data };

    public static implicit operator ServiceResult<T>(List<ValidationFailure>? errors) => new ServiceResult<T> { Errors = errors };
}