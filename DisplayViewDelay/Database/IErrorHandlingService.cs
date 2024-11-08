using Microsoft.EntityFrameworkCore;

namespace DisplayViewDelay.Core.Database
{
    public interface IErrorHandlingService
    {
        /// <summary>
        /// Adds a callback method for handling errors associated with the specified error code.
        /// Error codes correspond to values from the relevant error enum.
        /// </summary>
        /// <param name="errorCode">The numeric representation of the error code.</param>
        /// <param name="callback">
        ///     A callback function that takes a <see cref="DbUpdateException"/> as input and returns a <see cref="Task"/>.
        ///     This callback is executed when an error with the specified error code occurs.
        /// </param>
        public void AddErrorCallback(int errorCode, Func<DbUpdateException, Task> callback);

        /// <summary>
        /// Handles a database error represented by a <see cref="DbUpdateException"/>.
        /// This method is intended to be used as a centralized error-handling mechanism for database-related issues.
        /// </summary>
        /// <param name="updateException">The <see cref="DbUpdateException"/> representing the database error.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task HandleDatabaseError(DbUpdateException updateException);

        /// <summary>
        /// Handles a general exception that may occur during database operations.
        /// This method serves as a centralized error-handling mechanism for non-specific exceptions.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to be handled.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task HandleGeneralError(Exception exception);
    }
}
