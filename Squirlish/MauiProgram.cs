using System.Reflection;
using CommunityToolkit.Maui;
using MediatR;
using Squirlish.Domain.Collections;
using Squirlish.Views;
using Squirlish.ViewModels;
using Squirlish.Data;
using Squirlish.Data.Repositories;

namespace Squirlish;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.RegisterAppServices()
            .RegisterViewModels()
            
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerifBold");
				fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "Poppins");
				fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");
            });

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IPath, DbPath>();
        mauiAppBuilder.Services.AddDbContext<DatabaseContext>();

        mauiAppBuilder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        mauiAppBuilder.Services.AddSingleton<ICollectionsRepository, CollectionsRepository>();
        mauiAppBuilder.Services.AddSingleton<IInventory, Inventory>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<HomeViewModel>();
        mauiAppBuilder.Services.AddTransient<LearnViewModel>();
        mauiAppBuilder.Services.AddTransient<CollectionsViewModel>();

        mauiAppBuilder.Services.AddTransient<HomePage>();
        mauiAppBuilder.Services.AddTransient<LearnPage>();
        mauiAppBuilder.Services.AddTransient<CollectionsPage>();

        return mauiAppBuilder;
    }
}