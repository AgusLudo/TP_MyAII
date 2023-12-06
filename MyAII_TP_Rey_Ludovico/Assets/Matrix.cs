using System;
using System.Collections;
using System.Collections.Generic;

public class Matrix<T> : IEnumerable<T>
{
    private T[,] _data;

    public Matrix(int width, int height)
    {
        Width = width;
        Height = height;
        Capacity = width * height;
        _data = new T[width, height];
    }

    public Matrix(T[,] copyFrom) : this(copyFrom.GetLength(0), copyFrom.GetLength(1))
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _data[x, y] = copyFrom[x, y];
            }
        }
    }

    public Matrix<T> Clone()
    {
        return new Matrix<T>(_data);
    }

    public void SetRangeTo(int x0, int y0, int x1, int y1, T item)
    {
        for (int x = x0; x <= x1; x++)
        {
            for (int y = y0; y <= y1; y++)
            {
                _data[x, y] = item;
            }
        }
    }

    public List<T> GetRange(int x0, int y0, int x1, int y1)
    {
        List<T> result = new List<T>();
        for (int x = x0; x <= x1; x++)
        {
            for (int y = y0; y <= y1; y++)
            {
                result.Add(_data[x, y]);
            }
        }
        return result;
    }

    public T this[int x, int y]
    {
        get { return _data[x, y]; }
        set { _data[x, y] = value; }
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Capacity { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in _data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}