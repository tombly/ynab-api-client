using System.Text.RegularExpressions;

namespace Ynab.Api.Client.Tests;

/// <summary>
/// Verifies that the client stays in sync with the OpenAPI spec committed at the
/// repo root (open_api_spec.yaml). These tests are the safety net for the
/// spec-diff maintenance process described in UPDATING.md: after applying an API
/// update, they fail if any spec operation is missing from the client or the
/// client exposes an operation the spec no longer defines.
/// </summary>
public class SpecCoverageTests
{
    private static string FindRepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !File.Exists(Path.Combine(dir.FullName, "open_api_spec.yaml")))
            dir = dir.Parent;
        Assert.NotNull(dir);
        return dir.FullName;
    }

    private static string SpecPath => Path.Combine(FindRepoRoot(), "open_api_spec.yaml");

    private static IReadOnlySet<string> SpecOperationIds()
    {
        var spec = File.ReadAllText(SpecPath);
        var ids = Regex.Matches(spec, @"^\s*operationId:\s*(\w+)\s*$", RegexOptions.Multiline)
            .Select(m => m.Groups[1].Value)
            .ToHashSet();
        Assert.NotEmpty(ids);
        return ids;
    }

    private static string ToClientMethodName(string operationId)
        => char.ToUpperInvariant(operationId[0]) + operationId[1..] + "Async";

    private static IReadOnlySet<string> InterfaceMethodNames()
        => typeof(IYnabApiClient).GetMethods()
            .Where(m => m.Name.EndsWith("Async", StringComparison.Ordinal))
            .Select(m => m.Name)
            .ToHashSet();

    [Fact]
    public void Every_spec_operation_has_a_client_method()
    {
        var missing = SpecOperationIds()
            .Select(ToClientMethodName)
            .Where(name => !InterfaceMethodNames().Contains(name))
            .Order()
            .ToList();

        Assert.True(missing.Count == 0,
            $"Operations in open_api_spec.yaml with no corresponding IYnabApiClient method: {string.Join(", ", missing)}");
    }

    [Fact]
    public void Every_client_method_has_a_spec_operation()
    {
        var expected = SpecOperationIds().Select(ToClientMethodName).ToHashSet();
        var stale = InterfaceMethodNames()
            .Where(name => !expected.Contains(name))
            .Order()
            .ToList();

        Assert.True(stale.Count == 0,
            $"IYnabApiClient methods with no corresponding operation in open_api_spec.yaml: {string.Join(", ", stale)}");
    }

    [Fact]
    public void Client_builds_urls_from_plans_paths_not_legacy_budgets_paths()
    {
        var clientSource = File.ReadAllText(Path.Combine(FindRepoRoot(), "YnabApiClient.cs"));
        Assert.Contains(@"$""plans/", clientSource);
        Assert.DoesNotContain("budgets", clientSource);
    }

    [Fact]
    public void Package_version_notes_match_spec_version()
    {
        var spec = File.ReadAllText(SpecPath);
        var specVersion = Regex.Match(spec, @"^\s*version:\s*([\d.]+)\s*$", RegexOptions.Multiline).Groups[1].Value;

        var csproj = File.ReadAllText(Path.Combine(FindRepoRoot(), "Ynab.Api.Client.csproj"));
        Assert.Contains($"YNAB API v{specVersion}", csproj);
    }
}
