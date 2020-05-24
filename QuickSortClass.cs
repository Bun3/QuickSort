using System;
using System.Collections.Generic;

namespace CSharpTechnic
{
    class QuickSortClass
    {
        public static void QuickSort(List<string> list, int start, int end)
        {
            //원소 개수가 한개 이하면 반환
            if (start >= end) return;

            int pivot = start; //정렬할 때 기준 인덱스
            int left = pivot + 1; //정렬할 구역에서 제일 왼쪽 인덱스 
            int right = end;  //정렬할 구역에서 제일 오른쪽 인덱스

            while (left <= right) //left가 right를 넘지 않았을 때
            {
                while (left < end && CompareTo(list[left], list[pivot]) != -1) left++; //pivot보다 left가 더 작으면 ++
                while (right > start && CompareTo(list[right], list[pivot]) != 1) right--; //pivot보다 right가 더 크면 --
                Swap(list, left >= right ? pivot : left, right); //위치가 같거나 엇갈리면 pivot과 right를 아니면 left와 right를 스왑
            }

            //마지막에 pivot과 right를 바꾸고 while을 빠져나왔으므로 right가 중간
            QuickSort(list, start, right - 1); //중간으로부터 왼쪽 다시 정렬
            QuickSort(list, right + 1, end); //중간으로부터 오른쪽 다시 정렬
        }

        //앞의 문자열이 더 크면 -1, 문자열이 같으면 0, 뒤의 문자열이 더 크면 1 반환
        private static int CompareTo(string lhs, string rhs)
        {
            if (lhs == rhs) return 0; //두개가 같을 때
            else if (lhs.Length > rhs.Length) return -1; //앞이 더 클 때 
            else if (lhs.Length < rhs.Length) return 1; //뒤가 더 클 때
            else if (lhs.Length == rhs.Length) //두 문자열의 길이가 같을 때
            {
                int index = GetStringCompareIndex(lhs, rhs); //비교할 인덱스 반환
                int left = Convert.ToInt32(lhs[index]); //비교할 왼쪽 문자열의 char 아스키 코드
                int right = Convert.ToInt32(rhs[index]); //비교할 오른쪽 문자열의 char 아스키 코드

                if (Math.Abs(left - right) == 32) return (left - right) / 32; //같은 문자일 때 소문자가 더 작도록 반환 
                else //다른 문자일 때 대소문자 구별없이 크기 비교
                {
                    left = left >= 97 ? left - 32 : left;
                    right = right >= 97 ? right - 32 : right;
                    return left > right ? -1 : 1;
                }
            }
            return 0;
        }

        //두개의 문자열 중에서 크기를 비교할 인덱스를 찾아 반환.
        private static int GetStringCompareIndex(string lhs, string rhs, int i = 0)
        {
            if (lhs.Length != rhs.Length || lhs == rhs) return -1;
            return lhs[i] != rhs[i] ? i : GetStringCompareIndex(lhs, rhs, ++i);
        }

        //두개의 문자열 변환
        private static void Swap(List<string> list, int lhs, int rhs)
        {
            if (lhs == rhs || list[lhs] == list[rhs]) return;
            string tmp = list[lhs];
            list[lhs] = list[rhs];
            list[rhs] = tmp;
        }

        private static void Main()
        {
            List<string> list = new List<string>() { "apple", "cat", "banana", "nanana", "bat", "Bat", "Cat", "wanana", "Nanana", "aat" };

            QuickSort(list, 0, list.Count - 1);

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }

    }
}
