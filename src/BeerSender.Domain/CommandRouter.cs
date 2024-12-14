namespace BeerSender.Domain;

public class CommandRouter(IEventStore eventStore, IServiceProvider serviceProvider)
{
    private readonly IEventStore _eventStore = eventStore;

    public void HandleCommand(object command)
    {
        var commandType = command.GetType();

        var handlerType = typeof(CommandHandler<>).MakeGenericType(commandType);

        var handler = serviceProvider.GetService(handlerType);

        var methodInfo = handlerType.GetMethod(nameof(CommandHandler<object>.Handle));

        methodInfo?.Invoke(handler, [command]);
        
        // By saving changes here we allow nesting of commands.
        _eventStore.SaveChanges();
    }
}