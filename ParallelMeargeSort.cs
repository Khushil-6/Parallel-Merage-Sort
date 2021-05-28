using System;
using System.Threading;


class ParallelMeargeSort {         
	static void Main(string[] args)
	{
			var start = DateTime.Now;

				var arr = new int[] { 5, 3, 1, 7, 8, 5, 3, 2, 6, 7, 9, 3, 2, 4, 2, 1 };
				Console.Write("Orignal Array: " + string.Join(" ", arr) + '\n');
				Sort(arr, 0, arr.Length, new int[arr.Length]);
				Console.Write("Sorted Array: " + string.Join(" ", arr));
				// Console.Write(BitConverter.ToString(arr));
				for (int i = 1; i < arr.Length; ++i)
				{
					if (arr[i] > arr[i])
					{
						System.Diagnostics.Debug.Assert(false);
						throw new Exception("Sort was incorrect");
					}
				}

	}
	static void Sort(int[] arr, int leftPos, int rightPos, int[] tempArr)
	{
		var len = rightPos - leftPos;
		if (len < 2)
			return;
		if (len == 2)
		{
			if (arr[leftPos] > arr[leftPos + 1])
			{
				var t = arr[leftPos];
				arr[leftPos] = arr[leftPos + 1];
				arr[leftPos + 1] = t;
			}
			return;
		}
		var rStart = leftPos+len/2;
		var t1 = new Thread(delegate() { Sort(arr, leftPos, rStart, tempArr); });
		var t2 = new Thread(delegate() { Sort(arr, rStart, rightPos, tempArr); });
		t1.Start();
		t2.Start();
		t1.Join();
		t2.Join();
		var l = leftPos;
		var r = rStart;
		var z = leftPos;
		while (l<rStart && r<rightPos)
		{
			if (arr[l] < arr[r])
			{
				tempArr[z] = arr[l];
				l++;
			}
			else
			{
				tempArr[z] = arr[r];
				r++;
			}
			z++;
		}
		if (l < rStart)
			Array.Copy(arr, l, tempArr, z, rStart - l);
		else
			Array.Copy(arr, r, tempArr, z, rightPos - r);
		Array.Copy(tempArr, leftPos, arr, leftPos, rightPos - leftPos);
	}
}
