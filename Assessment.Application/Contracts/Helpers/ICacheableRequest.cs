﻿namespace Assessment.Application.Contracts.Helpers
{
    public interface ICacheableRequest
    {
        public string GetCacheKey();
        public double GetCacheDurationInMinutes();
    }
}
