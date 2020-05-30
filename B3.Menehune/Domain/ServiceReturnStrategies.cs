namespace B3.Menehune.Domain
{
    public enum ServiceReturnStrategies
    {
        DefaultPassThrough,
        Return500Error,
        NeverReturn,
        Random
    }
}
