namespace Ynab.Api.Client.Models;

/// <summary>A map of loan account periodic values (e.g. interest rates) keyed by date.</summary>
public sealed class LoanAccountPeriodicValue : Dictionary<string, long>;
