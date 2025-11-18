using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Bps.Core.Aspects.Postsharp.GenericAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Bps.BpsBase.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Bps.BpsBase.Business")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.GN.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.GN.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.GN.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.GN.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.ST.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.ST.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.ST.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.ST.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SA.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SA.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SA.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SA.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.DovkurManager", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.DovkurManager", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.DovkurManager", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.DovkurManager", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.XX.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.XX.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.XX.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.XX.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.WM.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.WM.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.WM.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.WM.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.UA.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.UA.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.UA.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.UA.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.IS.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.IS.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.IS.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.IS.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.CR.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.CR.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.CR.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.CR.*", AttributeTargetMembers = "Ncch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SP.*", AttributeTargetMembers = "Cch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SP.*", AttributeTargetMembers = "Cch_*_NLog")]

[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: true, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SP.*", AttributeTargetMembers = "Ncch_*_Log")]
[assembly: GenericAspect(typeof(DatabaseLogger), typeof(MemoryCacheManager), useLog: false, useCache: false, AttributeTargetTypes = "Bps.BpsBase.Business.Concrete.Managers.SP.*", AttributeTargetMembers = "Ncch_*_NLog")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("27dea96c-2ed7-40ce-b36d-c24f387d4171")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
