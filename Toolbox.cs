using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox
{

	public static List<T> Shuffle<T>(List<T> lst, int times=222)
	{

		int idx1 = Random.Range(0, lst.Count);
		int idx2 = Random.Range(0, lst.Count);

		T temp;

		for (int i = 0; i < times; i++) {
			temp = lst[idx1];

			lst[idx1] = lst[idx2];

			lst[idx2] = temp;


			idx1 = Random.Range(0, lst.Count);
			idx2 = Random.Range(0, lst.Count);

		}


		return lst;
	}




	public static string LstToStr(List<int> lst)
	{

		string result = "";

		for (int i = 0; i < lst.Count; i++)
		{
			result += (lst[i]);


			if (i != lst.Count - 1) {
				result += (", ");
			}


		}

		return result;

	}


	public static string[] SortArrByArr(string[] arrStr, int[] arrInt)
	{
		int[] intCopy = (int[])arrInt.Clone();
		System.Array.Sort(intCopy);

		string[] strCopy = new string[arrStr.Length];


		for (int i = 0; i < intCopy.Length; i++)
		{
			int originalIdx = System.Array.IndexOf(arrInt, intCopy[i]);

			strCopy[i] = arrStr[originalIdx];

			arrStr[originalIdx] = "";
			arrInt[originalIdx] = -1;


		}


		return strCopy;
	}

	public static int[] Sort(int[] arr) {
		System.Array.Sort(arr);
		return arr;
	}

	


}
