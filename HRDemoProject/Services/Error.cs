namespace HRDemoProject.Services
{
    public record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);

        public static readonly Error NullValue = new("Error.NullValue", "Value is null.");

        public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", "Validation unsuccessful");
    }
}
