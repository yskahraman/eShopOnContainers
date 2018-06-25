﻿using System;
using System.Threading.Tasks;
using eShopOnContainers.Core.Services.RequestProvider;

namespace eShopOnContainers.Core.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "api/v1/l/locations";

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(eShopOnContainers.Core.Models.Location.Location newLocReq, string token)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.GatewayMarketingEndpoint);
            builder.Path = ApiUrlBase;
            string uri = builder.ToString();
            await _requestProvider.PostAsync(uri, newLocReq, token);
        }
    }
}