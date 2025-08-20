namespace common.modelViews
{
    public record ValidationError(params String[] Error)
    {
        public readonly List<String> ErrorList = [.. Error];
    }
}