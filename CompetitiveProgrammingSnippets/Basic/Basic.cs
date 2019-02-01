using System;
using System.IO;
using __PROJECT__;

#pragma warning disable CS0219
#pragma warning disable CS0414

namespace Basic
{
    using __int__ = Int32;

    public class IO
    {
        void StreamScanner()
        {
            Func<string, string> String = s => s;
            var __X__ = 0;
            var __Y__ = 0;

            var ss = new StreamScanner(new StreamReader(Console.OpenStandardInput()));
            //$sss
            ss.Next(String)
                //$sss
                ;
            //$sss1
            ss.Next(String, __X__)
                //$sss1
                ;
            //$sss2
            ss.Next(String, __X__, __Y__)
                //$sss2
                ;

            //$ssn
            ss.Next(__int__.Parse)
                //$ssn
                ;
            //$ssn1
            ss.Next(__int__.Parse, __X__)
                //$ssn1
                ;
            //$ssn2
            ss.Next(__int__.Parse, __X__, __Y__)
                //$ssn2
                ;

            {
                //$vsss
                var __N__ = ss.Next(String);
                //$vsss
            }
            {
                //$vsss1
                var __N__ = ss.Next(String, __X__);
                //$vsss1
            }
            {
                //$vsss2
                var __N__ = ss.Next(String, __X__, __Y__);
                //$vsss2
            }

            {
                //$vssn
                var __N__ = ss.Next(__int__.Parse);
                //$vssn
            }
            {
                //$vssn1
                var __N__ = ss.Next(__int__.Parse, __X__);
                //$vssn1
            }
            {
                //$vssn2
                var __N__ = ss.Next(__int__.Parse, __X__, __Y__);
                //$vssn2
            }
        }

        void StreamWriter()
        {
            var ____ = "NONE";
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            //$sww
            sw.WriteLine( /*$SELECTED$*/ /*$END$*/);
            //$sww
            //$swww
            sw.Write( /*$SELECTED$*/ /*$END$*/____);
            //$swww
        }
    }

    public class Iterator
    {
        void For2()
        {
            var __upper1__ = 0;
            var __upper2__ = 0;

            //$for2
            for (var __index1__ = 0; __index1__ < __upper1__; __index1__++)
            {
                for (var __index2__ = 0; __index2__ < __upper2__; __index2__++)
                {
                    /*$SELECTED$*/ /*$END$*/
                }
            }
            //$for2
        }
    }

    public class DxDy4
    {
        //$dd4
        readonly int[] dx = {0, 1, 0, -1};
        readonly int[] dy = {1, 0, -1, 0};
        readonly int dl = 4;
        //$dd4

        void DD4()
        {
            //$dd4s
            var dx = new[] {0, 1, 0, -1};
            var dy = new[] {1, 0, -1, 0};
            var dl = 4;
            //$dd4s
        }
    }

    public class DxDy8
    {
        //$dd8
        readonly int[] dx = {0, 1, 0, -1, 1, 1, -1, -1};
        readonly int[] dy = {1, 0, -1, 0, 1, -1, 1, -1};
        readonly int dl = 8;
        //$dd8

        void DD8()
        {
            //$dd8s
            var dx = new[] {0, 1, 0, -1, 1, 1, -1, -1};
            var dy = new[] {1, 0, -1, 0, 1, -1, 1, -1};
            var dl = 8;
            //$dd8s
        }
    }

    public class IsInsideFunc
    {
        const int __H__ = 114;
        const int __W__ = 514;
        //$isin
        readonly Func<__int__, __int__, bool> IsInside = (x, y) => 0 <= x && x < __W__ && 0 <= y && y < __H__;
        //$isin

        void IsIn()
        {
            //$isins
            Func<__int__, __int__, bool> isInside = (x, y) => 0 <= x && x < __W__ && 0 <= y && y < __H__;
            //$isins
        }
    }
}