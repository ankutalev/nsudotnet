using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LinesCounter {
    public class StateMachine {
        private static readonly IConfigurationRoot Config;
        private const int LineBeginState = 1;
        private const int SingleCommentAtStartLineState = 2;
        private const int MultilineCommentAtStartLineState = 3;
        private const int MeaningfulLineState = 4;
        private const int MultilineCommentAtStartEndState = 5;
        private const int SingleCommentState = 6;
        private const int MultilineCommentInMeaningfulLineState = 7;

        private readonly Dictionary<int, Dictionary<byte[], int>> _transitions =
            new Dictionary<int, Dictionary<byte[], int>>();

        private bool _meaningAfterMultiEnd;
        private int _meaningfulLinesCounter;
        private int _singleLineCommentsCounter;
        private int _multiLineCommentsCounter;
        private int _emptyStringsCounter;
        private readonly string _singleComment;
        private readonly string _openComment;
        private readonly string _closeComment;
        private int _currentState = LineBeginState;
        private byte[] _parsingLine;
        private readonly byte[] _notMatchedTransition = {0};
        private readonly List<byte[]> _tokens;
        private int _currentPosition;

        static StateMachine() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            Config = builder.Build();
        }

        public StateMachine(string langExtension) {
            _singleComment = Config[$"SingleLine:{langExtension}"];
            _openComment = Config[$"MultiLine:{langExtension}:OpenComment"];
            _closeComment = Config[$"MultiLine:{langExtension}:CloseComment"];
            _tokens = new List<byte[]>();
            if (_singleComment != null)
                _tokens.Add(Encoding.ASCII.GetBytes(_singleComment));
            if (_openComment != null)
                _tokens.Add(Encoding.ASCII.GetBytes(_openComment));
            if (_closeComment != null)
                _tokens.Add(Encoding.ASCII.GetBytes(_closeComment));
            _tokens.Add(Encoding.ASCII.GetBytes(Environment.NewLine));
            _tokens.Sort((x, y) => y.Length.CompareTo(x.Length));
            CreateBeginStateTransitions();
            CreateSingleCommentAtStartTransition();
            CreateSingleCommentTransition();
            CreateMultiCommentTransition();
            CreateMultiCommentInMeaningTransition();
            CreateMeaningfulStateTransition();
            CreateCommentEndTransition();
        }

        public void ParseDate(byte[] date, int readed) {
            _parsingLine = date;
            _currentPosition = 0;
            
            for (_currentPosition = 0; _currentPosition  < readed -2;) {
                  var  transition = NextTransition();
                   var nextState = _transitions[_currentState][transition];
                IncrementCounters(_currentState, nextState, transition);
                _currentState = nextState;
                _currentPosition += transition.Length;
            }
        }

        private byte[] NextTransition() {
            foreach (var token in _tokens) {
                var matched = !token.Where((t, i) => _parsingLine[_currentPosition + i] != t).Any();
                if (!matched) continue;
                if (_transitions[_currentState].ContainsKey(token))
                    return token;
            }

            return _notMatchedTransition;
        }


        private void CreateBeginStateTransitions() {
            _transitions[LineBeginState] = new Dictionary<byte[], int>(new ByteArrayComparer()) {
                [Encoding.ASCII.GetBytes(" ")] = LineBeginState,
                [Encoding.ASCII.GetBytes(Environment.NewLine)] = LineBeginState,
                [_notMatchedTransition] = MeaningfulLineState
            };
            if (_singleComment != null)
                _transitions[LineBeginState][Encoding.ASCII.GetBytes(_singleComment)] = SingleCommentAtStartLineState;
            if (_openComment != null)
                _transitions[LineBeginState][Encoding.ASCII.GetBytes(_openComment)] = MultilineCommentAtStartLineState;
        }

        private void CreateSingleCommentAtStartTransition() {
            _transitions.Add(SingleCommentAtStartLineState, new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[SingleCommentAtStartLineState][Encoding.ASCII.GetBytes(Environment.NewLine)] = LineBeginState;
            _transitions[SingleCommentAtStartLineState][_notMatchedTransition] = SingleCommentAtStartLineState;
        }

        private void CreateSingleCommentTransition() {
            _transitions.Add(SingleCommentState, new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[SingleCommentState][Encoding.ASCII.GetBytes(Environment.NewLine)] = LineBeginState;
            _transitions[SingleCommentState][_notMatchedTransition] = SingleCommentState;
        }

        private void CreateMeaningfulStateTransition() {
            _transitions.Add(MeaningfulLineState, new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[MeaningfulLineState][Encoding.ASCII.GetBytes(Environment.NewLine)] = LineBeginState;
            _transitions[MeaningfulLineState][_notMatchedTransition] = MeaningfulLineState;
            if (_singleComment != null)
                _transitions[MeaningfulLineState][Encoding.ASCII.GetBytes(_singleComment)] = SingleCommentState;
            if (_openComment != null)
                _transitions[MeaningfulLineState][Encoding.ASCII.GetBytes(_openComment)] =
                    MultilineCommentInMeaningfulLineState;
        }

        private void CreateMultiCommentTransition() {
            _transitions.Add(MultilineCommentAtStartLineState, new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[MultilineCommentAtStartLineState][Encoding.ASCII.GetBytes(Environment.NewLine)] =
                MultilineCommentAtStartLineState;
            _transitions[MultilineCommentAtStartLineState][_notMatchedTransition] = MultilineCommentAtStartLineState;
            _transitions[MultilineCommentAtStartLineState][Encoding.ASCII.GetBytes(_closeComment)] =
                MultilineCommentAtStartEndState;
        }

        private void CreateMultiCommentInMeaningTransition() {
            _transitions.Add(MultilineCommentInMeaningfulLineState,
                new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[MultilineCommentInMeaningfulLineState][Encoding.ASCII.GetBytes(Environment.NewLine)] =
                MultilineCommentAtStartLineState;
            _transitions[MultilineCommentInMeaningfulLineState][_notMatchedTransition] =
                MultilineCommentInMeaningfulLineState;
            _transitions[MultilineCommentInMeaningfulLineState][Encoding.ASCII.GetBytes(_closeComment)] =
                LineBeginState;
        }

        private void CreateCommentEndTransition() {
            _transitions.Add(MultilineCommentAtStartEndState, new Dictionary<byte[], int>(new ByteArrayComparer()));
            _transitions[MultilineCommentAtStartEndState][Encoding.ASCII.GetBytes(Environment.NewLine)] =
                LineBeginState;
            _transitions[MultilineCommentAtStartEndState][_notMatchedTransition] = MeaningfulLineState;
            _transitions[MultilineCommentAtStartEndState][Encoding.ASCII.GetBytes(_openComment)] =
                MultilineCommentAtStartLineState;
            _transitions[MultilineCommentAtStartEndState][Encoding.ASCII.GetBytes(_singleComment)] =
                SingleCommentAtStartLineState;
        }


        private void IncrementCounters(int prevState, int nextState, byte[] symbols) {
            switch (nextState) {
                case SingleCommentAtStartLineState:
                    if (prevState != SingleCommentAtStartLineState)
                        _singleLineCommentsCounter++;
                    break;

                case SingleCommentState:
                    if (prevState != SingleCommentState)
                        _singleLineCommentsCounter++;
                    break;

                case MultilineCommentInMeaningfulLineState:
                    if (prevState != MultilineCommentInMeaningfulLineState)
                        _meaningfulLinesCounter++;
                    break;

                case MultilineCommentAtStartLineState:
                    if (prevState != MultilineCommentAtStartLineState)
                        _multiLineCommentsCounter++;
                    break;

                case MeaningfulLineState:
                    if (prevState == MultilineCommentAtStartEndState) {
                        _meaningfulLinesCounter++;
                        _meaningAfterMultiEnd = true;
                    }

                    break;

                case LineBeginState:
                    switch (prevState) {
                        case SingleCommentState:
                            _meaningfulLinesCounter++;
                            break;
                        case MeaningfulLineState:
                            if (!_meaningAfterMultiEnd)
                                _meaningfulLinesCounter++;
                            _meaningAfterMultiEnd = false;
                            break;
                        case LineBeginState:
                            if (symbols[0] != ' ' || symbols[0] != '\t')
                                _emptyStringsCounter++;
                            break;
                        default:
                            return;
                    }

                    break;

                default:
                    return;
            }
        }

        public void PrintResults() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("EMPTY LINES  {0} ", _emptyStringsCounter);
            Console.WriteLine("MEANINGFULL LINES  :{0}", _meaningfulLinesCounter);
            Console.WriteLine("MULTULILINE LINES  : {0}", _multiLineCommentsCounter);
            Console.WriteLine("SINGLE LINES   {0}  ", _singleLineCommentsCounter);
            Console.ResetColor();
        }

        public void Clear() {
            _currentPosition = 0;
            _currentState = LineBeginState;
        }
    }
}

public class ByteArrayComparer : IEqualityComparer<byte[]> {
    public bool Equals(byte[] left, byte[] right) {
        if (left == null || right == null) {
            return left == right;
        }

        if (left.Length != right.Length) {
            return false;
        }

        return !left.Where((t, i) => t != right[i]).Any();
    }

    public int GetHashCode(byte[] key) {
        return key == null ? 0 : key.Aggregate(0, (current, cur) => current + cur);
    }
}