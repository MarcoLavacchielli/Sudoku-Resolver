using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Matrix<T> : IEnumerable<T>
{
    T[] internalMatrix;
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Capacity { get; private set; }

    public T this[int x, int y]
    {
        get
        {
            return internalMatrix[x + y * Width];
        }
        set
        {
            internalMatrix[x + y * Width] = value;
        }
    }

    public Matrix(int _width, int _height)
    {
        Initialize(_width, _height);
    }

    void Initialize(int _width, int _height)
    {
        Width = _width;
        Height = _height;
        Capacity = _width * _height;
        internalMatrix = new T[Capacity];

        for (int i = 0; i < Capacity; i++)
        {
            internalMatrix[i] = default(T);
        }
    }

    public Matrix(T[,] _copyFrom)
    {
        Initialize(_copyFrom.GetLength(0), _copyFrom.GetLength(1));

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                this[i, j] = _copyFrom[i, j];
            }
        }
    }

    public Matrix<T> Clone()
    {
        Matrix<T> aux = new Matrix<T>(Width, Height);

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                aux[i, j] = this[i, j];
            }
        }

        return aux;
    }

    public void SetRangeTo(int x0, int y0, int x1, int y1, T item)
    {
        for (int i = x0; i <= x1; i++)
        {
            for (int j = y0; j <= y1; j++)
            {
                this[i, j] = item;
            }
        }
    }

    public List<T> GetRange(int x0, int y0, int x1, int y1)
    {
        List<T> range = new List<T>();

        for (int i = x0; i <= x1; i++)
        {
            for (int j = y0; j <= y1; j++)
            {
                range.Add(this[i, j]);
            }
        }

        return range;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Capacity; i++)
        {
            yield return internalMatrix[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}