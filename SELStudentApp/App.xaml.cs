using SELStudentApp.Core.Services;
using SELStudentApp.Presentation.Schedule;
using SELStudentApp.ViewModels;
using Uno.Extensions.Configuration.Internal;
using Uno.Resizetizer;

namespace SELStudentApp;
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) =>
                {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Warning);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging
                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                }, enableUnoLogging: true)
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                .ConfigureServices((context, services) =>
                {
                    var config = context.Configuration.GetSection("AppConfig").Get<AppConfig>();
                    if (config.ServerUrl is null)
                        throw new InvalidOperationException("ServerUrl is not found in configuration file.");

                    services.AddSingleton(new HttpClient()
                    {
                        BaseAddress = new Uri(config.ServerUrl),
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                    services.AddSingleton<INetworkService, NetworkService>();
                    services.AddSingleton<ISettingsService, SettingsService>();
                    services.AddSingleton<IAuthService, AuthService>();
                    services.AddSingleton<IDashboardService, DashboardService>();
                    services.AddSingleton<IScheduleService, ScheduleService>();
                    services.AddSingleton<ICurriculumService, CurriculumService>();
                })
                .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>();
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap<Shell, ShellViewModel>(),
            new ViewMap<LoginPage, LoginViewModel>(),
            new ViewMap<DashboardPage, DashboardViewModel>(),
            new ViewMap<ProfilePage, ProfileViewModel>(),
            new ViewMap<TodaySchedulePage, ScheduleViewModel>(),
            new ViewMap<SemesterSchedulePage, ScheduleViewModel>(),
            new ViewMap<CurriculumPage, CurriculumViewModel>(),
            new DataViewMap<ClassDetailPage, ClassDetailViewModel, ScheduleItemViewModel>()
        );

        routes.Register(
            new RouteMap("", View: views.FindByViewModel<ShellViewModel>(), Nested:
            [
                new RouteMap("Login", View: views.FindByViewModel<LoginViewModel>()),
                new RouteMap("Dashboard", View: views.FindByViewModel<DashboardViewModel>()),
                new RouteMap("Profile", View: views.FindByViewModel<ProfileViewModel>()),
                new RouteMap("Curriculum", View: views.FindByViewModel<CurriculumViewModel>()),
                new RouteMap("TodaySchedule", View: views.FindByView<TodaySchedulePage>()),
                new RouteMap("SemesterSchedule", View: views.FindByView<SemesterSchedulePage>()),
                new RouteMap("ClassDetail", View: views.FindByViewModel<ClassDetailViewModel>())
            ])
        );
    }
}
