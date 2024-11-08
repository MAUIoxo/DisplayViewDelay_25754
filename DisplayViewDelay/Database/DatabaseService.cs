using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DisplayViewDelayDatabase.Core;

namespace DisplayViewDelay.Core.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _dbContext;

        private readonly IErrorHandlingService _errorHandlingService;


        /// <inheritdoc />
        public DatabaseContext DatabaseContext { get => _dbContext; }


        public DatabaseService(DatabaseContext dbContext, IErrorHandlingService errorHandlingService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _errorHandlingService = errorHandlingService ?? throw new ArgumentNullException(nameof(errorHandlingService));
        }


        /// <inheritdoc />
        public bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException updateException)
            {
                _errorHandlingService.HandleDatabaseError(updateException);
                return false;
            }
            catch (Exception ex)
            {
                _errorHandlingService.HandleGeneralError(ex);
                return false;
            }

            return true;

        }

        /// <inheritdoc />
        public bool SaveChangesToSingleTable<TEntity>() where TEntity : class
        {
            try
            {
                var originalChanges = _dbContext.ChangeTracker.Entries()
                            .Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType()) && x.State != EntityState.Unchanged)
                            .GroupBy(x => x.State)
                            .ToList();

                // Reset all changes that are not in the table of the given TEntity
                foreach (var entry in _dbContext.ChangeTracker.Entries().Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType())))
                {
                    entry.State = EntityState.Unchanged;
                }


                try
                {
                    _dbContext.SaveChanges();
                }
                catch
                {
                    // Restore the original changes in case of any problems
                    RestoreOriginalChanges(originalChanges);
                    throw;
                }

                RestoreOriginalChanges(originalChanges);
            }
            catch (DbUpdateException updateException)
            {
                _errorHandlingService.HandleDatabaseError(updateException);
                return false;
            }
            catch (Exception ex)
            {
                _errorHandlingService.HandleGeneralError(ex);
                return false;
            }

            return true;
        }

        private void RestoreOriginalChanges(List<IGrouping<EntityState, EntityEntry>> originalStates)
        {
            foreach (var state in originalStates)
            {
                foreach (var entry in state)
                {
                    entry.State = state.Key;
                }
            }
        }
    }
}
