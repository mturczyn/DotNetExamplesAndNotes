using System.Text;

namespace DotNetExamplesAndNotes.ConsoleApp.RecordPrintMembers;

record Person(string FirstName, string LastName);

record PersonWithNumbers(string FirstName, string LastName, string[] PhoneNumbers);

record PersonWithMemberPrint(string FirstName, string LastName, string[] PhoneNumbers)
{
    protected virtual bool PrintMembers(StringBuilder stringBuilder)
    {
        StringBuilderHelpers.AppendPropertyWithValue(stringBuilder, nameof(FirstName), FirstName);
        StringBuilderHelpers.AppendPropertyWithValue(stringBuilder, nameof(LastName), LastName);
        StringBuilderHelpers.AppendPropertyWithValuesArray(stringBuilder, nameof(PhoneNumbers), PhoneNumbers);
        return true;
    }
}

sealed record PersonWithMemberPrintSealed(string FirstName, string LastName, string[] PhoneNumbers)
{
    private bool PrintMembers(StringBuilder stringBuilder)
    {
        StringBuilderHelpers.AppendPropertyWithValue(stringBuilder, nameof(FirstName), FirstName);
        StringBuilderHelpers.AppendPropertyWithValue(stringBuilder, nameof(LastName), LastName);
        StringBuilderHelpers.AppendPropertyWithValuesArray(stringBuilder, nameof(PhoneNumbers), PhoneNumbers);
        return true;
    }
}
