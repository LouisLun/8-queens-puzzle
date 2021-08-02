using System;
using System.Collections.Generic;

namespace _8_queens_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input number:");
            int n = Convert.ToInt32(Console.ReadLine());
            var results = solution(n);
            Console.WriteLine();

            int c = 0;
            foreach (var e in results) {
                Console.WriteLine("// Solution {0}", ++c);
                foreach (var e1 in e) {
                    Console.WriteLine(e1);
                }
                Console.WriteLine();
            }
        }

        public static List<List<string>> solution(int n)
        {
            List<List<string>> results = new List<List<string>>();
            List<char[]> result = new List<char[]>();

            for (int i = 0; i < n; ++i) {
                char[] temp = new char[n];
                for (int j = 0; j < n; ++j) {
                    temp[j] = '.';
                }
                result.Add(temp);
            }

            backtrack(results, result, 0, n);

            return results;
        }

        private static void backtrack(List<List<string>> results, List<char[]> result, int x, int n)
        {
            for (int j = 0; j < n; ++j) {
                if (isValid(result, x, j, n)) {
                    result[x][j] = 'Q';
                    if (x == n - 1) {
                        showResult(results, result);
                    } else {
                        backtrack(results, result, x + 1, n);
                    }
                    result[x][j] = '.';
                }
            }
        }

        private static bool isValid(List<char[]> result, int x, int y, int n)
        {
            for (int i = 0; i < x; ++i) {
                if (result[i][y] == 'Q') {
                    return false;
                }
            }

            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; --i, --j) {
                if (result[i][j] == 'Q') {
                    return false;
                }
            }

            for (int i = x - 1, j = y + 1; i >= 0 && j < n; --i, ++j) {
                if (result[i][j] == 'Q') {
                    return false;
                }
            }
            return true;
        }

        private static void showResult(List<List<string>> results, List<char[]> result)
        {
            List<string> list = new List<string>();
            foreach (char[] ele in result) {
                list.Add(new string(ele));
            }
            results.Add(list);
        }
    }
}

