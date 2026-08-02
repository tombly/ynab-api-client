using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The type of account</summary>
public enum AccountType
{
    [JsonStringEnumMemberName("checking")]
    Checking,

    [JsonStringEnumMemberName("savings")]
    Savings,

    [JsonStringEnumMemberName("cash")]
    Cash,

    [JsonStringEnumMemberName("creditCard")]
    CreditCard,

    [JsonStringEnumMemberName("lineOfCredit")]
    LineOfCredit,

    [JsonStringEnumMemberName("otherAsset")]
    OtherAsset,

    [JsonStringEnumMemberName("otherLiability")]
    OtherLiability,

    [JsonStringEnumMemberName("mortgage")]
    Mortgage,

    [JsonStringEnumMemberName("autoLoan")]
    AutoLoan,

    [JsonStringEnumMemberName("studentLoan")]
    StudentLoan,

    [JsonStringEnumMemberName("personalLoan")]
    PersonalLoan,

    [JsonStringEnumMemberName("medicalDebt")]
    MedicalDebt,

    [JsonStringEnumMemberName("otherDebt")]
    OtherDebt,
}