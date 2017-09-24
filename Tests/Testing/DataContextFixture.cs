namespace Tests.Testing
{
    using Celebrity.Core.Reliability;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DataContextFixture<TContext, TFactory> : Disposable
        where TContext : DbContext
        where TFactory : IDesignTimeDbContextFactory<TContext>, new()
    {
        public DataContextFixture()
        {
            var factory = new TFactory();
            this.DataContext = factory.CreateDbContext(new string[0]);
        }

        public TContext DataContext { get; }

        protected override void Release()
        {
            this.DataContext.Dispose();
        }
    }
}