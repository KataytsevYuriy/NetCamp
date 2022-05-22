﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Vector
    {
        int[] array;
        public Vector(int n)
        {
            array = new int[n];
        }
        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
        public void InitRandom(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b + 1);
            }
        }
        public void InitPoliandr(int a, int b)
        {
            int middle = array.Length / 2 + array.Length % 2;
            Random random = new Random();
            for (int i = 0; i < middle; i++)
            {
                int val = random.Next(a, b + 1);
                array[i] = val;
                array[array.Length - 1 - i] = val;
            }
        }
        public void InitShufle()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int val = 0;
                do
                {
                    val = random.Next(1, array.Length + 1);
                } while (!array.Contains(val));
                array[i] = val;
            }
        }
        public Pair[] CalculateFreq()
        {
            Pair[] pairs = new Pair[array.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }
            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = new Pair(pairs[i].Number, pairs[i].Freq);
            }
            return result;
        }
        public bool IsPoliand()
        {
            int lenght = array.Length;
            int middle = array.Length / 2 + 1;
            for (int i = 0; i < middle; i++)
            {
                if (!(array[i] == array[lenght - 1 - i])) return false;
            }
            return true;
        }
        public void ReverseMassive()
        {
            int lenght = array.Length;
            int halfLenght = lenght / 2;
            int temp = 0;
            for (int i = 0; i < halfLenght; i++)
            {
                temp = array[i];
                array[i] = array[lenght - i];
                array[lenght - 1] = temp;
            }
        }
        public Pair BiggestPair()
        {
            Pair[] pairs = CalculateFreq();
            Pair result = new Pair(0, 0);
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i].Freq > result.Freq)
                {
                    result = pairs[i];
                }
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;
        }
    }
}
