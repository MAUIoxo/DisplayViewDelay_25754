using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DisplayViewDelay.Core.Database
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        /// <summary>
        /// Private dictionary to store error callbacks associated with specific error codes.
        /// The key is the numeric representation of the error code, and the value is the corresponding callback function
        /// that handles a <see cref="DbUpdateException"/>.
        /// </summary>
        private Dictionary<int, Func<DbUpdateException, Task>> _errorCallbacks = new Dictionary<int, Func<DbUpdateException, Task>>();


        /// <inheritdoc/>
        public void AddErrorCallback(int errorCode, Func<DbUpdateException, Task> callback)
        {
            _errorCallbacks[errorCode] = callback;
        }

        /// <inheritdoc/>
        public async Task HandleDatabaseError(DbUpdateException updateException)
        {
            var sqlException = updateException.GetBaseException() as SqliteException;
            if (sqlException == null)
            {
                await App.Current.MainPage.DisplayAlert("AppTitle", "Exception Message", "OK");
            }


            if (_errorCallbacks.TryGetValue(sqlException.SqliteExtendedErrorCode, out var callback))
            {
                await callback(updateException);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("AppResources.", "Exception Message", "OK");
            }
        }

        /// <inheritdoc/>
        public async Task HandleGeneralError(Exception exception)
        {
            await App.Current.MainPage.DisplayAlert("AppTitle", "Exception Message", "OK");
        }
    }
}
