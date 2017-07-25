﻿// Decompiled with JetBrains decompiler
// Type: Nintenlord.Event_Assembler.Core.Code.Preprocessors.Directives.Include
// Assembly: Core, Version=9.10.4713.28131, Culture=neutral, PublicKeyToken=null
// MVID: 65F61606-8B59-4B2D-B4B2-32AA8025E687
// Assembly location: E:\crazycolorz5\Dropbox\Unified FE Hacking\ToolBox\EA V9.12.1\Core.exe

using Nintenlord.Utility;

namespace Nintenlord.Event_Assembler.Core.Code.Preprocessors.Directives
{
  internal class Include : IDirective, INamed<string>, IParameterized
  {
    public string Name
    {
      get
      {
        return "include";
      }
    }

    public bool RequireIncluding
    {
      get
      {
        return true;
      }
    }

    public int MinAmountOfParameters
    {
      get
      {
        return 1;
      }
    }

    public int MaxAmountOfParameters
    {
      get
      {
        return 1;
      }
    }

    public CanCauseError Apply(string[] parameters, IDirectivePreprocessor host)
    {
      string file = Nintenlord.Event_Assembler.Core.IO.IOHelpers.FindFile(host.Input.CurrentFile, parameters[0]);
      if (file.Length <= 0)
        return CanCauseError.Error("File " + parameters[0] + " not found.");
      host.Input.OpenSourceFile(file);
      return CanCauseError.NoError;
    }
  }
}
