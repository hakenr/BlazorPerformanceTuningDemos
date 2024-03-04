using BlazorPerformanceTuningDemos.Client.DemoData;
using Havit.Blazor.Components.Web.Services.DataStores;

namespace BlazorPerformanceTuningDemos.Client.DataCaching;

// NuGet: Havit.Blazor.Components.Web
// https://github.com/havit/Havit.Blazor/blob/master/Havit.Blazor.Components.Web/Services/DataStores/DictionaryStaticDataStore.cs
public class EmployeesDataStore : DictionaryStaticDataStore<int, EmployeeDto>, IEmployeesDataStore
{
	private readonly IDemoDataService _demoDataService;

	public EmployeesDataStore(IDemoDataService demoDataService)
	{
		_demoDataService = demoDataService;
	}

	protected override Func<EmployeeDto, int> KeySelector => (employee) => employee.Id;
	protected override bool ShouldRefresh() => false; // just hit F5 :-D

	protected async override Task<IEnumerable<EmployeeDto>> LoadDataAsync()
	{
		return await _demoDataService.GetAllEmployeesAsync();
	}
}
