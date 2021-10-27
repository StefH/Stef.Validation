using System;

namespace Stef.Validation
{
    /// <summary>
    /// An attribute used by SonarCloud to mark the parameter that is validated for null in the method.
    ///
    /// <seealso href="https://rules.sonarsource.com/csharp/tag/convention/RSPEC-3900"/>
    /// </summary>
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}