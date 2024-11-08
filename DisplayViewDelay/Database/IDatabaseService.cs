using DisplayViewDelayDatabase.Core;

namespace DisplayViewDelay.Core.Database
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Provides external access to the database through the DbContext.
        /// </summary>
        public DatabaseContext DatabaseContext { get; }

        /// <summary>
        /// Saves all changes to the database tables using the registered <see cref="DatabaseContext"/>.
        /// </summary>
        /// <returns>
        ///     <para><c>true</c> if the changes to the tables were saved successfully.</para>
        ///     <para><c>false</c> otherwise.</para>
        /// </returns>
        public bool SaveChanges();

        /// <summary>
        /// Saves changes exclusively to the specified table TEntity. Changes to other tables will be temporarily stored,
        /// and the original state will be restored after saving changes to the TEntity table.
        /// </summary>
        /// <typeparam name="TEntity">The type representing the table for which changes are to be saved.</typeparam>
        /// <returns>
        ///     <para><c>true</c> if the changes to the table TEntity were saved successfully.</para>
        ///     <para><c>false</c> otherwise.</para>
        /// </returns>
        public bool SaveChangesToSingleTable<TEntity>() where TEntity : class;
    }
}
