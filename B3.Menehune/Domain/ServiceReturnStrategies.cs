namespace B3.Menehune.Domain
{
    public enum ServiceReturnStrategies
    {
        SleepingPassThrough,
        Return500Error,
        NeverReturn,
        Random
    }
}
