using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfTest();
            Part1();
        }

        private static void SelfTest()
        {
            foreach (var input in Input.TestData)
            {
                var result = Decode(input.data);

                Debug.Assert(result.column == input.column);
                Debug.Assert(result.row == input.row);
                Debug.Assert(result.seatId == input.seatId);
            }
        }

        private static (int row, int column, int seatId) Decode(string data)
        {
            Queue<char> queue = new(data.ToCharArray());

            byte row = DecodeBits(queue, 7, 'B', 'F');
            byte col = DecodeBits(queue, 3, 'R', 'L');

            return (row, col, (row * 8) + col);
        }

        private static byte DecodeBits(Queue<char> queue, int bits, char upperChar, char lowerChar)
        {
            byte lower = 0;
            byte upper = bits switch { 7 => 127, 3 => 7, _ => throw new ArgumentException("invalid bit choice", nameof(bits)) };

            byte selected = 0;
            for (int i = 0; i < bits; i++)
            {
                char value = queue.Dequeue();

                var deltaF = (upper - lower) / 2f;
                var delta = (byte)Math.Ceiling(deltaF);

                if (value == upperChar)
                {
                    lower += delta;
                    selected = lower;
                }
                else if (value == lowerChar)
                {
                    upper -= delta;
                    selected = upper;
                }
                else
                {
                    Debug.Assert(false);
                }
            }

            return selected;
        }

        private static void Part1()
        {
            System.Console.WriteLine(Input.Data.Select(Decode).Max(x => x.seatId));
        }
    }
}