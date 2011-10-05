﻿using System;
using OpenWrap.Repositories;

namespace Tests
{
    public class MemoryRepositoryFactory : IRemoteRepositoryFactory
    {
        public Func<string, IPackageRepository> FromUserInput = input=>null;
        IPackageRepository IRemoteRepositoryFactory.FromUserInput(string directoryPath)
        {
            return FromUserInput(directoryPath);
        }

        public Func<string, IPackageRepository> FromToken = input => null;
        IPackageRepository IRemoteRepositoryFactory.FromToken(string token)
        {
            return FromToken(token);
        }
    }
}