namespace Tests.Testing
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Xunit;

    public abstract class WhenTestingData<TContext, TFactory> : WhenTesting,
        IClassFixture<DataContextFixture<TContext, TFactory>>
        where TContext : DbContext
        where TFactory : IDesignTimeDbContextFactory<TContext>, new()
    {
        protected WhenTestingData(TContext context)
        {
            this.Context = context;
            this.DeferDispose(this.Context);
        }

        protected TContext Context { get; }
    }
}