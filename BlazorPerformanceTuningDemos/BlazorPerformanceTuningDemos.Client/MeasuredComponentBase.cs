using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorPerformanceTuningDemos.Client
{
	public abstract class MeasuredComponentBase : ComponentBase
	{
		private Stopwatch _stopwatch;

		protected MeasuredComponentBase()
		{
			_stopwatch = new Stopwatch();
			_stopwatch.Start();

			DumpMeasurementPoint("ctor");
		}

		protected override void OnInitialized()
		{
			DumpMeasurementPoint();
		}

		protected override void OnParametersSet()
		{
			DumpMeasurementPoint();
		}

		protected override Task OnAfterRenderAsync(bool firstRender)
		{
			DumpMeasurementPoint(measurementPointNameSuffix: $"(firstRender: {firstRender})");

			return base.OnAfterRenderAsync(firstRender);
		}

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			DumpMeasurementPoint();

			base.BuildRenderTree(builder);
		}

		protected void DumpMeasurementPoint([CallerMemberName] string measurementPointName = null, string measurementPointNameSuffix = null)
		{
			Console.WriteLine($"[Measurement:{this.GetType().Name}.{measurementPointName}{measurementPointNameSuffix}] {_stopwatch.ElapsedMilliseconds}ms elapsed from previous measurement.");
			_stopwatch.Restart();
		}
	}
}
