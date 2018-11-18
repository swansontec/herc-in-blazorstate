namespace Herc.Pwa.Shared
{
  public class RegularExpressions
  {

    /// <summary>
    /// Number: floating point(anchored)
    ///---------------------------------
    ///
    ///^[0-9]* (?:\.[0-9]+)?$
    ///
    ///Options: Case sensitive; Exact spacing; Dot doesn’t matchline breaks; ^$ don’t matchat linebreaks; Default linebreaks
    ///
    ///        Assert position at the beginning of the string «^»
    ///Match a single character in the range between “0” and “9” «[0-9]*»
    ///   Between zero and unlimited times, as many times as possible, giving back as needed(greedy) «*»
    ///Match the regular expression below «(?:\.[0-9]+)?»
    ///   Between zero and one times, as many times as possible, giving back as needed(greedy) «?»
    ///   Match the character “.” literally «\.»
    ///   Match a single character in the range between “0” and “9” «[0-9]+»
    ///      Between one and unlimited times, as many times as possible, giving back as needed(greedy) «+»
    ///Assert position at the end of the string, or before the line break at the end of the string, if any(carriage return and line feed, next line, line separator, paragraph separator) «$»
    ///Your regular expression may find zero-length matches
    ///   Java 8 allows a zero-length match at the position where the previous match ends.
    ///   Java 8 advances one character through the string before attempting the next match if the previous match was zero-length.
    public static string FloatingPointNumberNoSign(char aDecimalSeperator) => @"^[0-9]*(?:\" + $"{aDecimalSeperator}[0-9]+)?$";
  }
}
