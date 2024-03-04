using BlazorPerformanceTuningDemos.Client.DemoData;
using Havit.Blazor.Components.Web.Services.DataStores;

namespace BlazorPerformanceTuningDemos.Client.DataCaching;

public interface IEmployeesDataStore : IDictionaryStaticDataStore<int, EmployeeDto>
{
}
