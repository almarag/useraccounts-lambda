using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace Ama.UserAccountsLambda.Serverless
{
    using System;
    using System.Threading.Tasks;
    using Ama.UserAccountsLambda.Application.Users.Queries.GetUserById;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public class Functions
    {
        private readonly IMediator _mediator;
        private readonly IConfigurationRoot _configuration;
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
            var startupLambda = new StartupLambda();
            _configuration = startupLambda.GetConfiguration();
            _services = startupLambda.AddLambdaServices(_configuration);

            _provider = _services.BuildServiceProvider();
            _mediator = _provider.GetService<IMediator>();
        }

        /// <summary>
        /// Unit Test constructor (to include custom IServiceCollection)
        /// </summary>
        /// <param name="services"></param>
        public Functions(IServiceCollection services)
        {
            _provider = services.BuildServiceProvider();
            _mediator = _provider.GetService<IMediator>();
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            try
            {
                var queryRequest = JsonConvert.DeserializeObject<GetUserByIdQueryRequest>(request.Body);
                var queryResponse = JsonConvert.SerializeObject(await _mediator.Send(queryRequest));

                return new APIGatewayProxyResponse()
                {
                    StatusCode = 200,
                    Body = queryResponse
                };
            }
            catch (Exception)
            {
                return new APIGatewayProxyResponse()
                {
                    StatusCode = 500,
                    Body = "Internal Server Error"
                };
            }
        }
    }
}
