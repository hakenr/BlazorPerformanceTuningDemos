namespace BlazorPerformanceTuningDemos.Client.TooManyEvents;

public class Debouncer : IDisposable
{
	private CancellationTokenSource _debounceCancellationTokenSource = null;
	private bool _disposed;

	/// <summary>
	/// Starts the debouncing.
	/// </summary>
	/// <param name="millisecondsDelay">The delay in milliseconds for debouncing.</param>
	/// <param name="actionAsync">The asynchronous action to be executed. The <see cref="CancellationToken"/> gets canceled if the method is called again.</param>
	public async Task DebounceAsync(int millisecondsDelay, Func<CancellationToken, Task> actionAsync)
	{
		try
		{
			if (_debounceCancellationTokenSource != null)
			{
				_debounceCancellationTokenSource?.Cancel();
				_debounceCancellationTokenSource?.Dispose();
			}

			_debounceCancellationTokenSource = new CancellationTokenSource();

			await Task.Delay(millisecondsDelay, _debounceCancellationTokenSource.Token);

			await actionAsync(_debounceCancellationTokenSource.Token);
		}
		catch (TaskCanceledException)
		{
			// NOOP
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				if (_debounceCancellationTokenSource != null)
				{
					_debounceCancellationTokenSource?.Cancel();
					_debounceCancellationTokenSource?.Dispose();
				}
			}

			_disposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}
}