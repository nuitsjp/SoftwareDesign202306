using HatPepper.Infrastructure.Api;
using HatPepper.Infrastructure.Location;
using HatPepper.Infrastructure.Time;
using HatPepper.Presentation;
using HatPepper.UseCase;

// レストランを検索して表示する。
var console = 
    new NearbyRestaurantsConsole(
        new FindNearbyRestaurants(
            new LocationProvider(),
            new TimeProvider(),
            new GourmetSearchApi()));
await console.FindRestaurantsAsync();