using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorTechniques.Client.Components
{
  public partial class Duration : ComponentBase
  {
    [CascadingParameter] private EditContext CascadedEditContext { get; set; }
    [Parameter] public EventCallback<TimeSpan> ValueChanged { get; set; }
    [Parameter] public string Id { get; set; } = "Duration";
    [Parameter] public Expression<Func<TimeSpan>> ValueExpression { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; }
    [Parameter]
    public TimeSpan Value
    {
      get => _value;
      set
      {
        Hours = _value.Hours;
        Minutes = _value.Minutes;

        if (_value == value) return;

        _value = value;
        ValueChanged.InvokeAsync(_value);
        CascadedEditContext?.NotifyFieldChanged(_fieldIdentifier);
      }
    }

    private TimeSpan _value;
    private FieldIdentifier _fieldIdentifier;
    private int Hours { get; set; }
    private int Minutes { get; set; }

    private string _fieldCssClasses => CascadedEditContext?.FieldCssClass(_fieldIdentifier) ?? "";

    protected override void OnInitialized()
    {
      _fieldIdentifier = FieldIdentifier.Create(ValueExpression);
    }

    private void HoursOnBlur(FocusEventArgs e)
    {
      Value = new TimeSpan(Hours, Minutes, 0);
    }

    private void MinutesOnBlur(FocusEventArgs e)
    {
      Value = new TimeSpan(Hours, Minutes, 0);
    }
  }
}
