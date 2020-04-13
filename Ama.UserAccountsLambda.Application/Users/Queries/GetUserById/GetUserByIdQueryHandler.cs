namespace Ama.UserAccountsLambda.Application.Users.Queries.GetUserById
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        public Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserByIdQueryResponse()
            {
                UserId = 1,
                UserName = "Test"
            });
        }
    }
}
