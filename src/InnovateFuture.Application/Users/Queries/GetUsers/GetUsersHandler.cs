using System.Linq.Expressions;
using MediatR;
using InnovateFuture.Domain.Entities;
using InnovateFuture.Infrastructure.Users.Persistence.Interfaces;

namespace InnovateFuture.Application.Users.Queries.GetUsers;
public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;
    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<User, bool>> queryPredicate;
        var queriesEmpty = query.GetType().GetProperties().All(p=>p.GetValue(query)==null);
        if (queriesEmpty)
        {
            queryPredicate = u => true; // Fetch all users
        }
        else
        {
            // Build predicate based on query conditions
            queryPredicate = u =>
                (query.CognitoUuid == null || u.CognitoUuid == query.CognitoUuid) &&
                (string.IsNullOrEmpty(query.Email) || u.Email == query.Email) &&
                (string.IsNullOrEmpty(query.FullName) || u.FullName == query.FullName) &&
                (string.IsNullOrEmpty(query.Phone) || u.Phone == query.Phone) &&
                (!query.Birthday.HasValue || u.Birthday == query.Birthday);
        }

        var users = await _userRepository.GetAnyAsync(queryPredicate);
        
        return users;
    }
}

