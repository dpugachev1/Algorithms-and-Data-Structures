using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    //NOTE: Heap code is not entirely mine
    public enum HeapType
    {
        MinHeap,
        MaxHeap
    }

    public class Heap<T>
    {
        private readonly HeapType type;
        private readonly List<T> elements;
        private readonly IComparer<T> comparer;

        public Heap(HeapType heapType, IComparer<T> comp = null)
        {
            type = heapType;
            elements = new List<T>();

            if (comp != null)
            {
                comparer = comp;
            }
            else
            {
                comparer = Comparer<T>.Default;
            }
        }

        public Heap(HeapType heapType, List<T> list, IComparer<T> comp = null)
        {
            type = heapType;
            elements = list;

            if (comp != null)
            {
                comparer = comp;
            }
            else
            {
                comparer = Comparer<T>.Default;
            }

            if (list.Count > 1)
            {
                HeapifyUp(list.Count - 1);
            }
        }

        private int Parent(int idx) => (idx - 1) / 2;
        private int Left(int idx) => idx * 2 + 1;
        private int Right(int idx) => idx * 2 + 2;

        private bool HasLeft(int idx) => Left(idx) < elements.Count;
        private bool HasRight(int idx) => Right(idx) < elements.Count;

        public bool IsEmpty() => !elements.Any();
        public int Count => elements.Count;
        public T Peek() => elements[0];

        private void Swap(int a, int b)
        {
            var temp = elements[a];
            elements[a] = elements[b];
            elements[b] = temp;
        }

        public void Push(T num)
        {
            elements.Add(num);
            if (elements.Count > 1) HeapifyUp(elements.Count - 1);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is empty");
            }

            var temp = elements[0];
            Swap(0, elements.Count - 1);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);
            return temp;
        }

        private void HeapifyUp(int idx)
        {
            while (idx >= 0)
            {
                var p = Parent(idx);

                if (type.Equals(HeapType.MaxHeap) && comparer.Compare(elements[p], elements[idx]) < 0 ||
                    type.Equals(HeapType.MinHeap) && comparer.Compare(elements[p], elements[idx]) > 0)
                {
                    Swap(p, idx);
                    idx = p;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int idx)
        {
            int leftIdx;
            int rightIdx;
            int targetIdx;

            while (HasLeft(idx))
            {
                leftIdx = Left(idx);
                rightIdx = Right(idx);
                targetIdx = leftIdx;

                if (type.Equals(HeapType.MaxHeap) && HasRight(idx) && comparer.Compare(elements[rightIdx], elements[leftIdx]) > 0 ||
                    type.Equals(HeapType.MinHeap) && HasRight(idx) && comparer.Compare(elements[rightIdx], elements[leftIdx]) < 0)
                {
                    targetIdx = rightIdx;
                }

                if (type.Equals(HeapType.MaxHeap) && comparer.Compare(elements[targetIdx], elements[idx]) > 0 ||
                    type.Equals(HeapType.MinHeap) && comparer.Compare(elements[targetIdx], elements[idx]) < 0)
                {
                    Swap(idx, targetIdx);
                    idx = targetIdx;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
