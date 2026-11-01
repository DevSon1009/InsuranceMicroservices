using System;
using MediatR;

namespace PolicyService.Api.Events;

public class PolicyHolderInfo
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class PolicyCreated : INotification
{
    public string PolicyNumber { get; set; } = string.Empty;
    public PolicyHolderInfo PolicyHolder { get; set; } = new();
}

public class PolicyTerminated : INotification
{
    public string PolicyNumber { get; set; } = string.Empty;
    public DateTime PolicyTo { get; set; }
    public decimal AmountToReturn { get; set; }
}