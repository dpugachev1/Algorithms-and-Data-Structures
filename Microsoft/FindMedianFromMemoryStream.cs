using System;
using System.Collections.Generic;

public class MedianFinder
{

    /** initialize your data structure here. */
    SortedSet<Tuple<int>> _low;
    SortedSet<Tuple<int>> _hi;

    public MedianFinder()
    {

        //Max Heap to store lower half
        _low = new SortedSet<Tuple<int>>(Comparer<Tuple<int>>.Create((x, y) => {

            if (ReferenceEquals(x, y))
                return 0;

            int c = x.Item1.CompareTo(y.Item1);
            return c == 0 ? 1 : c; // 1 For Max Heap, Remove(Max) will work properly
        }));

        //Min Heap to store higher half
        _hi = new SortedSet<Tuple<int>>(Comparer<Tuple<int>>.Create((x, y) => {

            if (ReferenceEquals(x, y))
                return 0;

            int c = x.Item1.CompareTo(y.Item1);
            return c == 0 ? -1 : c; // -1 For Min Heap, Remove(Min) will work properly
        }));

    }

    public void AddNum(int num)
    {

        _low.Add(new Tuple<int>(num));

        _hi.Add(_low.Max);
        _low.Remove(_low.Max);

        if (_low.Count < _hi.Count)
        {
            _low.Add(_hi.Min);
            _hi.Remove(_hi.Min);
        }

    }

    public double FindMedian()
    {

        return _low.Count == _hi.Count ?
            ((double)(_low.Max.Item1) + _hi.Min.Item1) / 2 : _low.Max.Item1;

    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */