using FluentValidation.Results;

namespace ContactsApi;

public class BaseResponse
{
    public List<string> Errors { get; } = new();
    public bool Success => !Errors.Any();

    public BaseResponse()
    { }

    public BaseResponse(string error)
    {
        Errors.Add(error);
    }

    public BaseResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add(error.ErrorMessage);
        }
    }
}

public class BaseResponse<T> : BaseResponse
{
    public T? Result { get; set; }

    public BaseResponse()
    {
        
    }

    public BaseResponse(string error)
        :base(error)
    {
        
    }

    public BaseResponse(T result)
    {
        Result = result;
    }

    public BaseResponse(ValidationResult validationResult)
        :base(validationResult)
    { }
}
