using CommunityToolkit.Maui;
using DevExpress.Maui;
using DisplayViewDelay.Core.Database;
using DisplayViewDelay.Helpers;
using DisplayViewDelay.Pages;
using DisplayViewDelay.ViewModels;
using DisplayViewDelayDatabase.Core;
using Microsoft.Extensions.Logging;
using Sharpnado.Tabs;

namespace DisplayViewDelay
{
    public static partial class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressCollectionView()
                .UseMauiCommunityToolkit()
                .UseSharpnadoTabs(loggerEnable: false, debugLogEnable: false)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Configuration should occur before creating the DatabaseContext to ensure a valid AppDataDirectory is set
            DatabaseConstants.AppDataDirectory = GetDatabasePath();
            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddSingleton<IErrorHandlingService, ErrorHandlingService>();

            // Build the service provider to access registered services
            var serviceProvider = builder.Services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<DatabaseContext>();
            var errorHandlingService = serviceProvider.GetRequiredService<IErrorHandlingService>();
            var databaseService = new DatabaseService(dbContext, errorHandlingService);
            builder.Services.AddSingleton<IDatabaseService>(databaseService);


            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();


            DevExpress.Maui.CollectionView.Initializer.Init();

            ConfigurePlatformServices(builder);


            var app = builder.Build();

            ServiceHelper.Initialize(app.Services);

            return app;
        }

        /// <summary>
        /// // Defines a method that will be implemented in the platform specific files
        /// </summary>
        /// <param name="builder">Builder to register platform specific services</param>
        static partial void ConfigurePlatformServices(MauiAppBuilder builder);

        public static string GetDatabasePath()
        {
            var databasePath = FileSystem.AppDataDirectory;

            SQLitePCL.Batteries_V2.Init();

            // Ensure the directory exists; create it if it doesn't
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }

            return databasePath;
        }
    }
}
