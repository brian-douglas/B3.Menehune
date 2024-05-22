namespace B3.Menehune.Domain
{
    public class MenehuneState
    {
        #region Singleton
        private static readonly MenehuneState _instance = new MenehuneState();

        static MenehuneState() {}

        private MenehuneState() {}

        public static MenehuneState Instance => _instance;
        #endregion

        private ServiceReturnStrategies _returnStrategy;

        public ServiceReturnStrategies ReturnStrategy
        {
            get => _returnStrategy != ServiceReturnStrategies.Random ? _returnStrategy : GetRandom();
            set => _returnStrategy = value;
        }

        private ServiceReturnStrategies GetRandom()
        {
            var maxValue = Enum.GetNames(typeof(ServiceReturnStrategies)).Length;
            var randInt = new Random().Next(0, maxValue-1);

            var matchedValue = (ServiceReturnStrategies) randInt;

            return matchedValue == ServiceReturnStrategies.Random ? ServiceReturnStrategies.SleepingPassThrough : matchedValue;
        }
    }
}
