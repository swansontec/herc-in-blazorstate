namespace HercPwa2.Server.Features.Base
{
  using System;

  public class BaseException : Exception
  {
    public BaseException(string aMessage) : base(aMessage) { }
  }
}