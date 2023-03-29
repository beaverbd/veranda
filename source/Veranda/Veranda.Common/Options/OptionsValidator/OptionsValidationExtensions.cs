using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Veranda.Common.Options.OptionsValidator;
public static class OptionsValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateOptions<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(s=>
            new FluentValidationOptions<TOptions>(optionsBuilder.Name, s.GetRequiredService<IValidator<TOptions>>()));
        return optionsBuilder;
    }
}

public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IValidator<TOptions> _validator;
    
    public FluentValidationOptions(string? name, IValidator<TOptions> validator)
    {
        _validator = validator;
        Name = name;
    }
    
    public string? Name { get; }
    
    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        if (Name != null && name != Name) 
            return ValidateOptionsResult.Skip;

        ArgumentNullException.ThrowIfNull(options);


        var validationResult = _validator.Validate(options);
        if(validationResult.IsValid)
            return ValidateOptionsResult.Success;

        var errors = validationResult.Errors.Select(e =>
            $"Options validation failed for '{e.PropertyName}' with the error '{e.ErrorMessage}'").ToList();
        return ValidateOptionsResult.Fail(errors);
    }
}
