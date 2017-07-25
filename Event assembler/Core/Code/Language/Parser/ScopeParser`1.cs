﻿// Decompiled with JetBrains decompiler
// Type: Nintenlord.Event_Assembler.Core.Code.Language.Parser.ScopeParser`1
// Assembly: Core, Version=9.10.4713.28131, Culture=neutral, PublicKeyToken=null
// MVID: 65F61606-8B59-4B2D-B4B2-32AA8025E687
// Assembly location: E:\crazycolorz5\Dropbox\Unified FE Hacking\ToolBox\EA V9.12.1\Core.exe

using Nintenlord.Event_Assembler.Core.Code.Language.Expression;
using Nintenlord.Event_Assembler.Core.Code.Language.Lexer;
using Nintenlord.IO;
using Nintenlord.IO.Scanners;
using Nintenlord.Parser;
using System.Collections.Generic;

namespace Nintenlord.Event_Assembler.Core.Code.Language.Parser
{
  internal sealed class ScopeParser<T> : Nintenlord.Parser.Parser<Token, Scope<T>>
  {
    private readonly IParser<Token, IEnumerable<IExpression<T>>> statementsParser;
    private readonly IParser<Token, Token> scopeStartParser;
    private readonly IParser<Token, Token> scopeEndParser;

    public ScopeParser(IParser<Token, IEnumerable<IExpression<T>>> statementsParser, IParser<Token, Token> scopeStartParser, IParser<Token, Token> scopeEndParser)
    {
      this.statementsParser = statementsParser;
      this.scopeStartParser = scopeStartParser;
      this.scopeEndParser = scopeEndParser;
    }

    protected override Scope<T> ParseMain(IScanner<Token> scanner, out Match<Token> match)
    {
      List<IExpression<T>> expressions = new List<IExpression<T>>();
      match = new Match<Token>(scanner);
      FilePosition position = scanner.Current.Position;
      do
      {
        Match<Token> match1;
        IEnumerable<IExpression<T>> collection = this.statementsParser.Parse(scanner, out match1);
        match += match1;
        if (!match.Success)
          return (Scope<T>) null;
        expressions.AddRange(collection);
        this.scopeStartParser.Parse(scanner, out match1);
        if (match1.Success)
        {
          match += match1;
          Scope<T> scope = this.Parse(scanner, out match1);
          match += match1;
          if (match.Success)
          {
            expressions.Add((IExpression<T>) scope);
            this.scopeEndParser.Parse(scanner, out match1);
            match += match1;
          }
          else
            goto label_6;
        }
        else
          goto label_8;
      }
      while (match.Success);
      goto label_7;
label_6:
      return (Scope<T>) null;
label_7:
      return (Scope<T>) null;
label_8:
      return new Scope<T>(expressions, position);
    }
  }
}
