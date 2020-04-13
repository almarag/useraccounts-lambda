namespace Ama.UserAccountsLambda.Application.Users.Queries.GetUserById
{
    using MediatR;

    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public int UserId { get; set; }
    }
}
