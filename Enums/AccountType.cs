namespace Ynab.Api.Client;

/// <summary>
/// The type of account
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AccountType
{

    [System.Runtime.Serialization.EnumMember(Value = @"checking")]
    Checking = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"savings")]
    Savings = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"cash")]
    Cash = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"creditCard")]
    CreditCard = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"lineOfCredit")]
    LineOfCredit = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"otherAsset")]
    OtherAsset = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"otherLiability")]
    OtherLiability = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"mortgage")]
    Mortgage = 7,

    [System.Runtime.Serialization.EnumMember(Value = @"autoLoan")]
    AutoLoan = 8,

    [System.Runtime.Serialization.EnumMember(Value = @"studentLoan")]
    StudentLoan = 9,

    [System.Runtime.Serialization.EnumMember(Value = @"personalLoan")]
    PersonalLoan = 10,

    [System.Runtime.Serialization.EnumMember(Value = @"medicalDebt")]
    MedicalDebt = 11,

    [System.Runtime.Serialization.EnumMember(Value = @"otherDebt")]
    OtherDebt = 12,

}