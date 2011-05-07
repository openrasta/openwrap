﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenWrap.Commands;
using OpenWrap.PackageModel;
using OpenWrap.Repositories;

namespace OpenWrap.PackageManagement
{
    internal class PackageGacConflictResult : PackageOperationResult
    {
        readonly IEnumerable<AssemblyName> _assemblyNames;
        readonly IPackageInfo _packageInfo;

        public PackageGacConflictResult(IPackageInfo packageInfo, IEnumerable<AssemblyName> assemblyNames)
        {
            _packageInfo = packageInfo;
            _assemblyNames = assemblyNames;
        }

        public override bool Success
        {
            get { return false; }
        }

        public override ICommandOutput ToOutput()
        {
            return
                    new Warning(
                            "{0} contains assemblies already present in the GAC. OpenWrap cannot override the GAC, for the version you just added to be used, you need to remove those assemblies from it.\r\n"
                            + _assemblyNames.Select(x => "\t - " + x.FullName).JoinString(Environment.NewLine),
                            _packageInfo.FullName);
        }
    }
}