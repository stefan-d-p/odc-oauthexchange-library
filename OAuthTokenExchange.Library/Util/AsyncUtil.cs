namespace Without.Systems.OAuthTokenExchange.Util;

public static class AsyncUtil
{
    private static readonly TaskFactory taskFactory = new TaskFactory(
        CancellationToken.None,
        TaskCreationOptions.None,
        TaskContinuationOptions.None,
        TaskScheduler.Default);

    public static TResult RunSync<TResult>(Func<Task<TResult>> task) =>
        taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}