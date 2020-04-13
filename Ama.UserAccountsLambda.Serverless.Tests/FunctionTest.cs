namespace Ama.UserAccountsLambda.Serverless.Tests
{
    using Xunit;
    using Amazon.Lambda.Core;
    using Amazon.Lambda.TestUtilities;
    using Amazon.Lambda.APIGatewayEvents;
    using Ama.UserAccountsLambda.Serverless;
    using Microsoft.Extensions.DependencyInjection;
    using Ama.UserAccountsLambda.Application;
    using MediatR;

    [Collection("UserAccountsCollection")]
    public class FunctionTest
    {
        [Fact]
        public void TetGetMethod()
        {
            var services = new ServiceCollection();
            var applicationAssembly = new AssemblyApplication().GetAssembly();
            services.AddMediatR(applicationAssembly);

            Functions functions = new Functions(services);

            var request = new APIGatewayProxyRequest()
            {
                Body = "{\"UserId\":1}",
                HttpMethod = "GET",
                Path = "/"
            };

            var context = new TestLambdaContext();

            var response = functions.Get(request, context).GetAwaiter().GetResult();

            Assert.NotNull(response);
        }
    }
}
