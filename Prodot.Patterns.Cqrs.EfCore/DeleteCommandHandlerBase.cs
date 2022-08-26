namespace Prodot.Patterns.Cqrs.EfCore;

public abstract class DeleteCommandHandlerBase<TQuery, TModel, TIdentifier, TIdentifierValue, TContext, TEntity, TEntityIdentifier> : IQueryHandler<TQuery, Unit>
    where TQuery : DeleteCommand<TModel, TIdentifier, TIdentifierValue, TQuery>
    where TModel : ModelBase<TIdentifier, TIdentifierValue>
    where TIdentifier : Identifier<TIdentifierValue, TIdentifier>, new()
    where TContext : DbContext
    where TEntity : class, IIdentifiableEntity<TEntityIdentifier>
{
    private readonly IDbContextFactory<TContext> _contextFactory;
    private readonly IMapper _mapper;

    protected DeleteCommandHandlerBase(IMapper mapper, IDbContextFactory<TContext> contextFactory)
    {
        _mapper = mapper;
        _contextFactory = contextFactory;
    }

    public IQueryHandler<TQuery, Unit> Successor { get; set; } = default!;

    public async Task<Option<Unit>> RunQueryAsync(TQuery query, CancellationToken cancellationToken)
    {
        using (var context = await _contextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false))
        {
            var entityId = _mapper.Map<TEntityIdentifier>(query.Id);

            var entity = await context.Set<TEntity>()
               .FirstOrDefaultAsync(cp => cp.Id!.Equals(entityId), cancellationToken)
               .ConfigureAwait(false);

            if (entity == null)
            {
                return Option.None;
            }

            context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return Unit.Value;
    }
}
