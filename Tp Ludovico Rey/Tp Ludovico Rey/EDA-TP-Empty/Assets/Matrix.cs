﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
	//IMPLEMENTAR: ESTRUCTURA INTERNA- DONDE GUARDO LOS DATOS?
	private int _width;
	private int _height;
	private int _capacity;
	private T[] _data;

	public int Width => _width;
	public int Height => _height;
	public int Capacity => _capacity;

	public Matrix(int width, int height)
	{
		//IMPLEMENTAR: constructor

		_width = width;
		_height = height;
		_capacity = width * height;

		_data = new T[_capacity];
	}

	public Matrix(T[,] copyFrom)
	{
		//IMPLEMENTAR: crea una version de Matrix a partir de una matriz básica de C#

		_capacity = copyFrom.Length;
		_width = copyFrom.GetLength(0);
		_height = copyFrom.GetLength(1);

		_data = new T[_capacity];

		for (int y = 0; y < _height; y++)
		{
			for (int x = 0; x < _width; x++)
			{
				this[x, y] = copyFrom[x, y];
			}
		}
	}

	public Matrix<T> Clone()
	{
		Matrix<T> aux = new Matrix<T>(Width, Height);
		//IMPLEMENTAR

		for (int y = 0; y < _height; y++)
		{
			for (int x = 0; x < _width; x++)
			{
				aux[x, y] = this[x, y];
			}
		}

		return aux;
	}

	public void ResetFromIndex(int xIndex, int yIndex)
	{
		int desireIndex = xIndex + _height * yIndex;

		T[] newData = new T[_capacity];

		for (int i = 0; i < desireIndex; i++)
		{
			newData[i] = _data[i];
		}

		_data = new T[_capacity];
		for (int j = 0; j < newData.Length; j++)
		{
			_data[j] = newData[j];
		}
	}

	public void SetRangeTo(int x0, int y0, int x1, int y1, T item)
	{
		//IMPLEMENTAR: iguala todo el rango pasado por parámetro a item
	}

	//Todos los parametros son INCLUYENTES
	public List<T> GetRange(int x0, int y0, int x1, int y1)
	{
		List<T> l = new List<T>();
		//IMPLEMENTAR

		for (int x = x0; x < x1; x++)
		{
			for (int y = y0; y < y1; y++)
			{
				l.Add(this[x, y]);
			}
		}

		return l;
	}

	//Para poder igualar valores en la matrix a algo
	public T this[int x, int y]
	{
		//IMPLEMENTAR
		get => _data[x + _height * y];
		//IMPLEMENTAR
		set => _data[x + _height * y] = value;
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (var data in _data)
		{
			//IMPLEMENTAR
			yield return data;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
