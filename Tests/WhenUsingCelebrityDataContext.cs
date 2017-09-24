namespace Tests
{
    using Celebrity.Data;
    using Testing;

    public class WhenUsingCelebrityDataContext : WhenTestingData<CelebrityDataContext, CelebrityDataContextFactory>
    {
        public WhenUsingCelebrityDataContext(CelebrityDataContext context) : base(context)
        {
        }
    }
}