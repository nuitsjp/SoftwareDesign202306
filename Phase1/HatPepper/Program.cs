using HatPepper.Infrastructure.Api;
using HatPepper.Infrastructure.Location;
using HatPepper.Infrastructure.Time;
using HatPepper.Presentation;
using HatPepper.UseCase;

// レストランを検索して表示する。
NearbyRestaurantsConsole console = 
    new(
        new FindNearbyRestaurants(
            new LocationProvider(),
            new TimeProvider(),
            new GourmetSearchApi()));
await console.FindRestaurantsAsync();