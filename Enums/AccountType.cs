namespace Ynab.Api.Client;

/// <summary>
/// The type of account
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AccountType
{

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"checking")]
    Checking = 0,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"savings")]
    Savings = 1,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"cash")]
    Cash = 2,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"creditCard")]
    CreditCard = 3,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"lineOfCredit")]
    LineOfCredit = 4,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"otherAsset")]
    OtherAsset = 5,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"otherLiability")]
    OtherLiability = 6,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"mortgage")]
    Mortgage = 7,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"autoLoan")]
    AutoLoan = 8,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"studentLoan")]
    StudentLoan = 9,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"personalLoan")]
    PersonalLoan = 10,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"medicalDebt")]
    MedicalDebt = 11,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"otherDebt")]
    OtherDebt = 12,

}