using FluentValidation;

namespace Veranda.Common.Options;
public class DbOptions : IServiceOptions
{
    public string Name => "DbOptions";
    public string ConnectionString { get; set; } = null!;
}

public class DbOptionsValidator : AbstractValidator<DbOptions>
{
    public DbOptionsValidator()
    {
        RuleFor(x=>x.ConnectionString)
            .NotEmpty().WithMessage("Connection string is required. If you're using AddPostgres<> extension please define 'DbOptions::ConnectionString' section in your app settings");
    }
}
